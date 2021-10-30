// See https://aka.ms/new-console-template for more information
using OpenTK.Mathematics;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using ProgGraf;

Console.WriteLine("Hello, World!");

var nativeWindowSettings = new NativeWindowSettings()
{
    Size = new Vector2i(800, 600),
    Title = "Aprendiendo OpenTK",
    
    Flags = ContextFlags.ForwardCompatible,
};

using (var window = new Ventana(GameWindowSettings.Default, nativeWindowSettings))
{
    window.Run();
}   