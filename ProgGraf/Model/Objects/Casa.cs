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
            paredes = new Figura(new Vector3(pos.X, pos.Y, pos.Z),
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shader.frag", vertP, indP);
            techo = new Figura(new Vector3(pos.X, pos.Y, pos.Z),
                "../../../../ProgGraf/Shaders/shader.vert", "../../../../ProgGraf/Shaders/shaderP.frag", vertT, indT);
            figuras.Add("paredes", paredes);
            figuras.Add("techo", techo);
        }

        
    }
}
