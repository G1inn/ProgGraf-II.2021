using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Common
{
    public class VBO
    {
        private int renderID;

        public VBO(float[] vertices, int tamaño)
        {
            renderID = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, renderID);
            GL.BufferData(BufferTarget.ArrayBuffer, tamaño * sizeof(float), vertices, BufferUsageHint.StaticDraw);
        }

        /*~VerticesBuffer()
        {
            GL.DeleteBuffer(renderID);
        }*/

        public void eliminarBuffer()
        {
            GL.DeleteBuffer(renderID);
        }

        public void enlazar()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, renderID);
        }
        public void desenlazar()
        {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
        }
    }
}
