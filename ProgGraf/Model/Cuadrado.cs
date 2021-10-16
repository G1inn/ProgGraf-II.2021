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
    public class Cuadrado : Figura
    {
        public override void SetShader()
        {
            _shader = new Shader("../../../Shaders/shader.vert", "../../../Shaders/shader.frag");
            _shader.Usar();
        }
        public Cuadrado(Vector3 centro)
        {
            _vertices = new float[]{
                 0.5f + centro.X,  0.5f + centro.Y, 0.0f + centro.Z, // top right
                 0.5f + centro.X, -0.5f + centro.Y, 0.0f + centro.Z, // bottom right
                -0.5f + centro.X, -0.5f + centro.Y, 0.0f + centro.Z, // bottom left
                -0.5f + centro.X,  0.5f + centro.Y, 0.0f + centro.Z, // top left
            };
            _indices = new uint[]
            {
                // Note that indices start at 0!
                0, 1, 3, // The first triangle will be the bottom-right half of the triangle
                1, 2, 3  // Then the second will be the top-right half of the triangle
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
