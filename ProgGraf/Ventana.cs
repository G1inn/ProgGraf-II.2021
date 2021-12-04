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
        public Escenario nivel; public float a, b, c; public string sel, parteSel, transSel; public Guion guion;

        private double tiempo;

        public Matrix4 _view;
        public Matrix4 _projection;
        public Ventana(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings)
            : base(gameWindowSettings, nativeWindowSettings)
        {
        }
        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(1.2f, 0.3f, 8.3f, 1.0f);

            GL.Enable(EnableCap.DepthTest);

            if (nivel != null)
            {
                nivel.InitBufers();
            }

            _view = Matrix4.LookAt(new Vector3(0.0f, 0.0f, 3.0f),new Vector3(0.0f, 0.0f, 0.0f),new Vector3(0.0f, 1.0f, 0.0f));
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size.X / (float)Size.Y, 0.1f, 100.0f);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            tiempo += 80.0 * e.Time;

            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            var model = Matrix4.Identity;
            if (nivel != null)
            {
                foreach (DictionaryEntry item in nivel.objetos)
                {
                    Objeto objeto = (Objeto)item.Value;
                    objeto.SetMatrixes(model, _view, _projection);
                }

                Objeto o = (Objeto)nivel.objetos[sel];
                if (parteSel == "")
                {
                    switch (transSel)
                    {
                        case "traslacion":
                            var modelA = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            o.SetMatrixes(modelA, _view, _projection);
                            modelA = modelA * Matrix4.CreateTranslation(a, b, c);
                            o.SetMatrixes(modelA, _view, _projection);
                            modelA = modelA * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            o.SetMatrixes(modelA, _view, _projection);
                            break;
                        case "rotacion":
                            var modelB = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            o.SetMatrixes(modelB, _view, _projection);
                            modelB = modelB * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(a * 50));
                            modelB = modelB * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(b * 50));
                            modelB = modelB * Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(c * 50));
                            o.SetMatrixes(modelB, _view, _projection);
                            modelB = modelB * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            o.SetMatrixes(modelB, _view, _projection);
                            break;
                        case "escalacion":
                            var modelC = model * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            o.SetMatrixes(modelC, _view, _projection);
                            modelC = modelC * Matrix4.CreateScale(1 + a, 1 + b, 1 + c);
                            o.SetMatrixes(modelC, _view, _projection);
                            modelC = modelC * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            o.SetMatrixes(modelC, _view, _projection);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    Figura f = (Figura)o.figuras[parteSel];
                    switch (transSel)
                    {
                        case "traslacion":
                            var modelA = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            f._shader.SetMatrix4("model", modelA);
                            modelA = modelA * Matrix4.CreateTranslation(a, b, c);
                            f._shader.SetMatrix4("model", modelA);
                            modelA = modelA * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            f._shader.SetMatrix4("model", modelA);
                            break;
                        case "rotacion":
                            var modelB = Matrix4.Identity * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            f._shader.SetMatrix4("model", modelB);
                            modelB = modelB * Matrix4.CreateTranslation(new Vector3(-f._centro.X, -f._centro.Y, -f._centro.Z));
                            f._shader.SetMatrix4("model", modelB);
                            modelB = modelB * Matrix4.CreateRotationX((float)MathHelper.DegreesToRadians(a * 50));
                            modelB = modelB * Matrix4.CreateRotationY((float)MathHelper.DegreesToRadians(b * 50));
                            modelB = modelB * Matrix4.CreateRotationZ((float)MathHelper.DegreesToRadians(c * 50));
                            f._shader.SetMatrix4("model", modelB);
                            modelB = modelB * Matrix4.CreateTranslation(new Vector3(f._centro.X, f._centro.Y, f._centro.Z));
                            f._shader.SetMatrix4("model", modelB);
                            modelB = modelB * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            f._shader.SetMatrix4("model", modelB);
                            break;
                        case "escalacion":
                            var modelC = model * Matrix4.CreateTranslation(new Vector3(-o.pos.X, -o.pos.Y, -o.pos.Z));
                            f._shader.SetMatrix4("model", modelC);
                            modelC = modelC * Matrix4.CreateTranslation(new Vector3(-f._centro.X, -f._centro.Y, -f._centro.Z));
                            f._shader.SetMatrix4("model", modelC);
                            modelC = modelC * Matrix4.CreateScale(1 + a, 1 + b, 1 + c);
                            f._shader.SetMatrix4("model", modelC);
                            modelC = modelC * Matrix4.CreateTranslation(new Vector3(f._centro.X, f._centro.Y, f._centro.Z));
                            f._shader.SetMatrix4("model", modelC);
                            modelC = modelC * Matrix4.CreateTranslation(new Vector3(o.pos.X, o.pos.Y, o.pos.Z));
                            f._shader.SetMatrix4("model", modelC);
                            break;
                        default:
                            break;
                    }
                }

                if (guion.Selected == true)
                {
                    guion.Start(guion.indice, _view, _projection);
                }

                nivel.Dibujar();
            }
            
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
