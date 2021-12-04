using OpenTK.Mathematics;
using ProgGraf.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model
{
    public class Guion
    {
        public Hashtable movimientos = new Hashtable(); public bool Selected = false;
        public Escenario escena;
        public float indice;

        public Guion(Escenario escena)
        {
            this.escena = escena;
        }
        public void addMove(Movimiento move, String nombreMove)
        {
            movimientos.Add(nombreMove, move);
        }

        public void Start(float i, Matrix4 _view, Matrix4 _projection)
        {
            indice = i;
            Objeto libro = (Objeto)escena.objetos["Libro"];
            Objeto bicho = (Objeto)escena.objetos["Bicho"];
            Figura cubierta = (Figura)libro.figuras["cubierta"];
            Figura contraportada = (Figura)libro.figuras["contraportada"];

            var modelB = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-libro.pos.X, -libro.pos.Y, -libro.pos.Z));
            cubierta._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(-cubierta._centro.X, -cubierta._centro.Y, -cubierta._centro.Z));
            cubierta._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians((indice) * 10));
            cubierta._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(cubierta._centro.X, cubierta._centro.Y, cubierta._centro.Z));
            cubierta ._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(libro.pos.X, libro.pos.Y, libro.pos.Z));
            cubierta._shader.SetMatrix4("model", modelB);

            modelB = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-libro.pos.X, -libro.pos.Y, -libro.pos.Z));
            contraportada._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(-contraportada._centro.X, -contraportada._centro.Y, -contraportada._centro.Z));
            contraportada._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians((indice) * -10));
            contraportada._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(contraportada._centro.X, contraportada._centro.Y, contraportada._centro.Z));
            contraportada._shader.SetMatrix4("model", modelB);
            modelB = modelB * Matrix4.CreateTranslation(new Vector3(libro.pos.X, libro.pos.Y, libro.pos.Z));
            contraportada._shader.SetMatrix4("model", modelB);

            var modelA = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-bicho.pos.X, -bicho.pos.Y, -bicho.pos.Z));
            bicho.SetMatrixes(modelA, _view, _projection);
            modelA = modelA * Matrix4.CreateTranslation(indice / 2, 0, 0);
            bicho.SetMatrixes(modelA, _view, _projection);
            modelA = modelA * Matrix4.CreateTranslation(new Vector3(bicho.pos.X, bicho.pos.Y, bicho.pos.Z));
            bicho.SetMatrixes(modelA, _view, _projection);
        }
    }
}
