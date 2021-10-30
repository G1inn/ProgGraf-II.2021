using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Common
{
    public class Data
    {
        public float[] Vertices { get; set; }
        public uint[] Indices { get; set; }

        public float[] ParserVertices(Vector3 _pos)
        {
            float[] vert = new float[Vertices.Length];
            for (int i = 0; i <= Vertices.Length - 3; i = i + 3)
            {
                vert[i] = Vertices[i] + _pos.X;
                vert[i + 1] = Vertices[i + 1] + _pos.Y;
                vert[i + 2] = Vertices[i + 2] + _pos.Z;
            }
            return vert;
        }
    }
}
