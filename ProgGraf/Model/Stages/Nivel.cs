using OpenTK.Mathematics;
using ProgGraf.Model.Objects;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Model.Stages
{
    public class Nivel : Escenario
    {
        Objeto casa1;
        Objeto casa2;
        Objeto casa3;

        public Nivel()
        {
            casa1 = new Casa(new Vector3(1.0f, 1.0f, -4.0f));
            casa2 = new Casa(new Vector3(0.0f, 0.0f, -8.0f));
            casa3 = new Casa(new Vector3(-2.0f, -1.0f, -6.0f));

            objetos.Add("obj1", casa1);
            objetos.Add("obj2", casa2);
            objetos.Add("obj3", casa3);
        }
    }
}
