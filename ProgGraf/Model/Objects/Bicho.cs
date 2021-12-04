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
    public class Bicho : Objeto
    {
        public Figura cuerpo; public Vector3 posCuerpo;

        public Bicho(Vector3 _pos)
        {
            string cuerpoDataString = File.ReadAllText("../../../../ProgGraf/res/Bicho/cuerpoData.txt");
            Data jsonDataC = JsonSerializer.Deserialize<Data>(cuerpoDataString);
            float[] vertCuerpo = jsonDataC.ParserVertices(_pos);
            uint[] indCuerpo = jsonDataC.Indices;
            pos = _pos;

            posCuerpo = new Vector3(0, 0, 0);
            cuerpo = new Figura(posCuerpo,
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shader.frag", vertCuerpo, indCuerpo);
            figuras.Add("cuerpo", cuerpo);
        }
    }
}
