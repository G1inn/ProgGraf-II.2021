using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using ProgGraf;
using ProgGraf.Model;
using ProgGraf.Model.Objects;
using System.Collections;
using System.Threading;

namespace ProgGraf_Form
{
    public partial class Form1 : Form
    {
        Ventana ventana; Escenario nivel = new Escenario();
        public Form1()
        {
            InitializeComponent();
        }
        private void RunGame()
        {
            var nativeWindowSettings = new NativeWindowSettings()
            {
                Size = new Vector2i(800, 600),
                Title = "Aprendiendo OpenTK",

                Flags = ContextFlags.ForwardCompatible,
            };

            using (ventana = new Ventana(GameWindowSettings.Default, nativeWindowSettings))
            {

                ventana.nivel = nivel;
                ventana.Run();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            nivel.AddObject("obj1", new Casa(new Vector3(2.0f, 1.0f, -4.0f)));
            nivel.AddObject("obj2", new Casa(new Vector3(0.0f, 0.0f, -8.0f)));
            nivel.AddObject("obj3", new Casa(new Vector3(-2.0f, -1.0f, -6.0f)));

            Thread _thread = new Thread(new ThreadStart(RunGame));
            _thread.Start();

            foreach (var item in nivel.objetos.Keys)
            {
                comboBox1.Items.Add(item);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}