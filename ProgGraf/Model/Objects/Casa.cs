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
    public class Casa : Objeto
    {
        public Figura paredes;
        public Figura techo;
        public Vector3 posPared;
        public Vector3 posTecho;

        public Casa(Vector3 _pos)
        {
            string paredesDataString = File.ReadAllText("../../../../ProgGraf/res/paredesData.txt");
            Data jsonDataP = JsonSerializer.Deserialize<Data>(paredesDataString);
            float[] vertP = jsonDataP.ParserVertices(_pos);
            uint[] indP = jsonDataP.Indices;

            string techoDataString = File.ReadAllText("../../../../ProgGraf/res/techoData.txt");
            Data jsonDataT = JsonSerializer.Deserialize<Data>(techoDataString);
            float[] vertT =jsonDataT.ParserVertices(_pos);
            uint[] indT = jsonDataT.Indices;

            pos = _pos;

            posPared = new Vector3(0, 0, 0);
            paredes = new Figura(posPared,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shader.frag", vertP, indP);
            posTecho = new Vector3(0, 0.7f, 0);
            techo = new Figura(posTecho,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shaderP.frag", vertT, indT);
            figuras.Add("paredes", paredes);
            figuras.Add("techo", techo);
        }

        
    }
}
