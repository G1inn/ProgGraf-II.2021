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
        Ventana ventana; Thread _thread;
        Escenario nivel1 = new Escenario();
        public Escenario nivel2 = new Escenario(); Libro Libro = new Libro(new Vector3(3, -1, -4)); Bicho Bicho = new Bicho(new Vector3(-3f, -0.9f, -4));
        public Hashtable Escenarios = new Hashtable();

        public Guion guion;
        public Form1()
        {
            InitializeComponent();
            nivel2.AddObject("Libro", Libro); nivel2.AddObject("Bicho", Bicho);
            Escenarios.Add("nivel2", nivel2);
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
                ventana.nivel = nivel2;   guion = new Guion(nivel2); ventana.guion = guion;
                ventana.sel = ""; ventana.parteSel = "";
                ventana.Run();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            nivel1.AddObject("obj1", new Casa(new Vector3(2.0f, 1.0f, -4.0f)));
            nivel1.AddObject("obj2", new Casa(new Vector3(0.0f, 0.0f, -8.0f)));
            nivel1.AddObject("obj3", new Casa(new Vector3(-2.0f, -1.0f, -6.0f)));

            //nivel2.AddObject("Libro", new Libro(new Vector3(0, 0, 0)));

            Escenarios.Add("nivel1", nivel1);
            //Escenarios.Add("nivel2", nivel2);
            foreach (var item in Escenarios.Keys)
            {
                comboBox3.Items.Add(item);
            }

            _thread = new Thread(new ThreadStart(RunGame));
            _thread.Start();

            foreach (var item in nivel1.objetos.Keys)
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

            Objeto o = (Objeto)ventana.nivel.objetos[ventana.sel];
            foreach (DictionaryEntry item in o.figuras)
            {
                comboBox2.Items.Add(item.Key);
            }
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0; ventana.a = 0;
            trackBar2.Value = 0; ventana.b = 0;
            trackBar3.Value = 0; ventana.c = 0;
            comboBox1.Items.Clear();
            ventana.nivel = (Escenario)Escenarios[comboBox3.SelectedItem];
            foreach (var item in ventana.nivel.objetos.Keys)
            {
                comboBox1.Items.Add(item);
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            trackBar4.Enabled = true;
            guion.Selected = true;
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            guion.indice = (float)trackBar4.Value / 10;
        }
    }
}