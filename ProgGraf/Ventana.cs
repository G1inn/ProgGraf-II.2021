using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ProgGraf.Common;
using ProgGraf.Model;
using ProgGraf.Model.Objects;
using System.Collections;

namespace ProgGraf
{
    public class Ventana : GameWindow
    {
        public Escenario nivel;

        private double tiempo;

        private Matrix4 _view;
        private Matrix4 _projection;
        public Ventana(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }
        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(1.2f, 0.3f, 8.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            nivel.InitBufers();

            _view = Matrix4.LookAt(new Vector3(0.0f, 0.0f, 3.0f),new Vector3(0.0f, 0.0f, 0.0f),new Vector3(0.0f, 1.0f, 0.0f));
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            tiempo += 80.0 * e.Time;

            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var model = Matrix4.Identity;  
            //Esto  se lo hace para que roten sobre sí mismos
            foreach (DictionaryEntry item in nivel.objetos)
            {
                Objeto objeto = (Objeto)item.Value;
                //var model2 = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-obj.pos.X, -obj.pos.Y, -obj.pos.Z));
                objeto.SetMatrixes(model, _view, _projection);
                //model2 = model2 * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(tiempo));
                //obj.SetMatrixes(model2, _view, _projection);
                //model2 = model2 * Matrix4.CreateTranslation(new Vector3(obj.pos.X, obj.pos.Y, obj.pos.Z));
                //obj.SetMatrixes(model2, _view, _projection);
            }
            Objeto obj = (Objeto) nivel.objetos["obj1"];
            Figura f = (Figura)obj.figuras["techo"];
            var model2 = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-obj.pos.X, -obj.pos.Y, -obj.pos.Z));
            //obj.SetMatrixes(model2, _view, _projection);
            f._shader.SetMatrix4("model", model2);
            model2 = model2 * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(tiempo));
            //obj.SetMatrixes(model2, _view, _projection);
            f._shader.SetMatrix4("model", model2);
            model2 = model2 * Matrix4.CreateTranslation(new Vector3(obj.pos.X, obj.pos.Y, obj.pos.Z));
            //obj.SetMatrixes(model2, _view, _projection);
            f._shader.SetMatrix4("model", model2);
            nivel.Dibujar();


            SwapBuffers();
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            var input = KeyboardState;

            if (input.IsKeyDown(Keys.Escape))
            {
                Close();
            }
        }
        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }
    }
}
