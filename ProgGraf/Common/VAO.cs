using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Common
{
    public class VAO
    {
        private int renderID;

        public VAO()
        {
            renderID = GL.GenVertexArray();
        }

        /*~VerticesArreglo()
        {
            GL.DeleteVertexArray(renderID);
        }*/

        public void eliminarArreglo()
        {
            GL.DeleteVertexArray(renderID);
        }

        public void añadirBuffer(Shader shader)
        {
            enlazar();

            //var location = shader.GetAttribLocation("aPosition");
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void enlazar()
        {
            GL.BindVertexArray(renderID);
        }

        public void desenlazar()
        {
            GL.BindVertexArray(0);
        }
    }
}
