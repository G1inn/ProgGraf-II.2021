using OpenTK.Mathematics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model
{
    public class Escenario
    {
        public Hashtable objetos = new Hashtable();

        public Escenario()
        {
        }

        public void Dibujar()
        {
            foreach (DictionaryEntry item in objetos)
            {
                Objeto obj = (Objeto)item.Value;
                obj.Dibujar();
            }
        }

        public void SetObjectMatrixes(Matrix4 model, Matrix4 _view, Matrix4 _projection)
        {
            foreach (DictionaryEntry item in objetos)
            {
                Objeto obj = (Objeto)item.Value;
                obj.SetMatrixes(model, _view, _projection);
            }
        }

        public void AddObject(String x, Objeto objeto)
        {
            objetos.Add(x, objeto);
        }
        public void InitBufers()
        {
            foreach (DictionaryEntry item in objetos)
            {
                Objeto obj = (Objeto)item.Value;
                obj.InitBuffers();
            }
        }
    }
}
