using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ProgGraf.Common;
using ProgGraf.Model;
using ProgGraf.Model.Objects;

namespace ProgGraf
{
    public class Ventana : GameWindow
    {
        /*Cuadrado cuadrado;
        Piramide piramide;*/
        Casa casa;

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

            /*cuadrado = new Cuadrado(new Vector3(0.0f, 0.0f, 0.0f));
            piramide = new Piramide(new Vector3(0.0f, 0.7f, 0.0f));*/
            casa = new Casa(new Vector3(0.0f, 0.0f, 0.0f));

            _view = Matrix4.LookAt(new Vector3(0.0f, 0.0f, -3.0f),new Vector3(0.0f, 0.0f, 0.0f),new Vector3(0.0f, 1.0f, 0.0f));
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {            
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var model = Matrix4.Identity;

            /*cuadrado._shader.SetMatrix4("model", model);
            cuadrado._shader.SetMatrix4("view", _view);
            cuadrado._shader.SetMatrix4("projection", _projection);
            cuadrado.Dibujar();

            piramide._shader.SetMatrix4("model", model);
            piramide._shader.SetMatrix4("view", _view);
            piramide._shader.SetMatrix4("projection", _projection);
            piramide.Dibujar();*/
            casa.SetMatrixes(model, _view, _projection);
            casa.Dibujar();


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
