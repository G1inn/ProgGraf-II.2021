using OpenTK.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model
{
    public class Objeto
    {
        public Vector3 pos;
        //public List<Figura> figuras = new List<Figura>();
        public Hashtable figuras = new Hashtable();

        public void SetMatrixes(Matrix4 model, Matrix4 _view, Matrix4 _projection)
        {
            foreach (DictionaryEntry item in figuras)
            {
                Figura obj = (Figura)item.Value;
                obj._shader.SetMatrix4("model", model);
                obj._shader.SetMatrix4("view", _view);
                obj._shader.SetMatrix4("projection", _projection);
            }
        }

        public void Dibujar()
        {
            foreach (DictionaryEntry item in figuras)
            {
                Figura obj = (Figura)item.Value;
                obj.Dibujar();
            }
        }
        public void InitBuffers()
        {
            foreach (DictionaryEntry item in figuras)
            {
                Figura obj = (Figura)item.Value;
                obj.InitBuffers();
            }
        }
    }
}
