using ProgGraf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model
{
    public abstract class Figura
    {
        public float[] _vertices;
        public uint[] _indices;
        public int cantidadDeVertices;
        public int cantidadDeIndices;
        public abstract void SetShader();

        public VBO _vbo;
        public VAO _vao;
        public Shader _shader;
        public EBO _ebo;
    }
}
