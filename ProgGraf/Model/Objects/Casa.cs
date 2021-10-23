using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model.Objects
{
    public class Casa
    {
        Vector3 pos;
        Figura techo;
        Figura front;
        Figura back;
        Figura left;
        Figura right;

        List<Figura> figuras = new List<Figura>();

        public Casa(Vector3 _pos)
        {
            pos = _pos;
            front = new Cuadrado(new Vector3(0.0f + pos.X, 0.0f + pos.Y, 0.5f + pos.Z));
            back = new Cuadrado(new Vector3( 0.0f + pos.X, 0.0f + pos.Y, -0.5f + pos.Z));
            left = new Cuadrado(new Vector3(-0.5f + pos.X, 0.0f + pos.Y,  0.0f + pos.Z));
            right = new Cuadrado(new Vector3(0.5f + pos.X, 0.0f + pos.Y,  0.0f + pos.Z));
            techo = new Piramide(new Vector3(0.0f + pos.X, 0.7f + pos.Y, 0.0f + pos.Z));

            figuras.Add(front);
            figuras.Add(back);
            figuras.Add(left);
            figuras.Add(right);
            figuras.Add(techo);
        }

        public void SetMatrixes(Matrix4 model, Matrix4 _view, Matrix4 _projection )
        {
            foreach (var figura in figuras)
            {
                if (figura == left || figura == right)
                {
                    model = Matrix4.CreateRotationY(MathHelper.DegreesToRadians(90f));
                    figura._shader.SetMatrix4("model", model);
                    figura._shader.SetMatrix4("view", _view);
                    figura._shader.SetMatrix4("projection", _projection);
                }
                else
                {
                    figura._shader.SetMatrix4("model", model);
                    figura._shader.SetMatrix4("view", _view);
                    figura._shader.SetMatrix4("projection", _projection);

                }
            }
        }

        public void Dibujar()
        {
            foreach (var figura in figuras)
            {
                figura.Dibujar();
            }
        }
    }
}
