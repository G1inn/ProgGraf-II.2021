using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using ProgGraf.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model
{
    public class Figura
    {
        public float[] _vertices;
        public uint[] _indices;
        public int cantidadDeVertices;
        public int cantidadDeIndices;
        public void SetShader(string _vertRuta, string _fragRuta)
        {
            _shader = new Shader(_vertRuta, _fragRuta);
            _shader.Usar();
        }
        public void Dibujar()
        {
            _shader.Usar();
            _vao.enlazar();
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }
        public void SetVertices(float[] vertices)
        {
            _vertices = vertices;
        }
        public void SetIndices(uint[] indices)
        {
            _indices = indices;
        }

        public VBO _vbo;
        public VAO _vao;
        public Shader _shader;
        public EBO _ebo;    

        public Figura(Vector3 centro, string vertRuta, string fragRuta, float[] vertices, uint[] indices)
        {
            _vertices = vertices;
            _indices = indices;

            cantidadDeVertices = _vertices.Length / 3;
            cantidadDeIndices = _indices.Length;

            _vbo = new VBO(_vertices, _vertices.Length);
            _vao = new VAO();
            _vao.añadirBuffer(_shader);
            _ebo = new EBO(_indices, _indices.Length);

            SetShader(vertRuta, fragRuta);
        }
    }
}
