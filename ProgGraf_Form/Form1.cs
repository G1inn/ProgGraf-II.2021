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

                ventana.nivel = nivel; ventana.sel = ""; ventana.parteSel = "";
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
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            ventana.sel = (string)comboBox1.SelectedItem;
            ventana.parteSel = "";

            comboBox2.Items.Clear();

            Objeto o = (Objeto)nivel.objetos[ventana.sel];
            foreach (DictionaryEntry item in o.figuras)
            {
                comboBox2.Items.Add(item.Key);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            ventana.parteSel = (string)comboBox2.SelectedItem;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ventana.a = (float) trackBar1.Value / 10;
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            ventana.c = (float)trackBar3.Value / 10;
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            ventana.b = (float)trackBar2.Value / 10;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            ventana.transSel = "traslacion";
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            ventana.transSel = "rotacion";
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            ventana.transSel = "escalacion";
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}