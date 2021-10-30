using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Windowing.GraphicsLibraryFramework;
using ProgGraf.Common;
using ProgGraf.Model;
using ProgGraf.Model.Objects;
using ProgGraf.Model.Stages;

namespace ProgGraf
{
    public class Ventana : GameWindow
    {
        public Escenario nivel;

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

            nivel = new Nivel();

            _view = Matrix4.LookAt(new Vector3(0.0f, 0.0f, 3.0f),new Vector3(0.0f, 0.0f, 0.0f),new Vector3(0.0f, 1.0f, 0.0f));
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {            
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var model = Matrix4.Identity;

            nivel.SetObjectMatrixes(model, _view, _projection);
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
