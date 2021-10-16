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
    public class Piramide : Figura
    {
        public override void SetShader()
        {
            _shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shaderP.frag");
            _shader.Usar();
        }
        public Piramide(Vector3 centro)
        {
            _vertices = new float[]{
                 0.5f + centro.X, 0.0f + centro.Y,  0.5f + centro.Z, // top right
                 0.5f + centro.X, 0.0f + centro.Y, -0.5f + centro.Z, // bottom right
                -0.5f + centro.X, 0.0f + centro.Y,  0.5f + centro.Z, // bottom left
                -0.5f + centro.X, 0.0f + centro.Y, -0.5f + centro.Z, // top left

                 0.0f + centro.X, 0.3f + centro.Y,  0.0f + centro.Z,
            };
            _indices = new uint[]
            {
                0, 1, 4, 
                0, 2, 4,
                2, 3, 4,
                3, 1, 4,
            };
            cantidadDeVertices = _vertices.Length / 3;
            cantidadDeIndices = _indices.Length;

            _vbo = new VBO(_vertices, _vertices.Length);
            _vao = new VAO();
            _vao.añadirBuffer(_shader);
            _ebo = new EBO(_indices, _indices.Length);

            SetShader();
        }
        public void Dibujar()
        {
            _shader.Usar();
            _vao.enlazar();
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}
