using OpenTK.Mathematics;
using ProgGraf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ProgGraf.Model.Objects
{
    public class Libro : Objeto
    {
        public Figura cubierta; public Vector3 posCubierta;
        public Figura contraportada; public Vector3 posContraportada;
        public Figura lomo; public Vector3 posLomo;        
        public Libro (Vector3 _pos)
        {
            string cubiertaDataString = File.ReadAllText("../../../../ProgGraf/res/Libro/cubierta_contraportadaData.txt");
            Data jsonDataCubierta = JsonSerializer.Deserialize<Data>(cubiertaDataString);
            float[] vertCubierta = jsonDataCubierta.ParserVertices(_pos);
            uint[] indCubierta = jsonDataCubierta.Indices;

            string contraportadaDataString = File.ReadAllText("../../../../ProgGraf/res/Libro/cubierta_contraportadaData.txt");
            Data jsonDataContraportada = JsonSerializer.Deserialize<Data>(contraportadaDataString);
            float[] vertContraportada = jsonDataContraportada.ParserVertices(_pos);
            uint[] indContraportada = jsonDataContraportada.Indices;

            string lomoDataString = File.ReadAllText("../../../../ProgGraf/res/Libro/lomoData.txt");
            Data jsonDataLomo = JsonSerializer.Deserialize<Data>(lomoDataString);
            float[] vertLomo = jsonDataLomo.ParserVertices(_pos);
            uint[] indLomo = jsonDataLomo.Indices;

            pos = _pos;

            posCubierta = new Vector3(0, 0, 0.1f);
            cubierta = new Figura(posCubierta,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shaderC.frag", vertCubierta, indCubierta);
            posContraportada = new Vector3(0, 0, -0.1f);
            contraportada = new Figura(posContraportada,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shaderC.frag", vertContraportada, indContraportada);
            posLomo = new Vector3(0, 0, 0);
            lomo = new Figura(posLomo,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shaderC.frag", vertLomo, indLomo);
            figuras.Add("cubierta", cubierta);
            figuras.Add("contraportada", contraportada);
            figuras.Add("lomo", lomo);
        }
    }
}
