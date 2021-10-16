using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgGraf.Common
{
    public class Shader
    {
        public readonly int Programa;
        private readonly Dictionary<string, int> _ubicaciones;

        public Shader(string vertRuta, string fragRuta)
        {
            var shaderFuente = File.ReadAllText(vertRuta);
            var vertexShader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertexShader, shaderFuente);
            CompilarShader(vertexShader);

            shaderFuente = File.ReadAllText(fragRuta);
            var fragmentShader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragmentShader, shaderFuente);
            CompilarShader(fragmentShader);

            Programa = GL.CreateProgram();

            GL.AttachShader(Programa, vertexShader);
            GL.AttachShader(Programa, fragmentShader);
            EnlazarPrograma(Programa);

            GL.DetachShader(Programa, vertexShader);
            GL.DetachShader(Programa, fragmentShader);
            GL.DeleteShader(fragmentShader);
            GL.DeleteShader(vertexShader);

            GL.GetProgram(Programa, GetProgramParameterName.ActiveUniforms, out var numberOfUniforms);
            _ubicaciones = new Dictionary<string, int>();
            for (var i = 0; i < numberOfUniforms; i++)
            {
                var key = GL.GetActiveUniform(Programa, i, out _, out _);

                var location = GL.GetUniformLocation(Programa, key);

                _ubicaciones.Add(key, location);
            }
        }
        private static void CompilarShader(int shader)
        {
            GL.CompileShader(shader);

            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code != (int)All.True)
            {
                var infoLog = GL.GetShaderInfoLog(shader);
                throw new Exception($"Un error ocurió al compilar el Shader({shader}).\n\n{infoLog}");
            }
        }
        private static void EnlazarPrograma(int programa)
        {
            GL.LinkProgram(programa);

            GL.GetProgram(programa, GetProgramParameterName.LinkStatus, out var code);
            if (code != (int)All.True)
            {
                throw new Exception($"Un error ocurió al enlazar el Programa({programa})");
            }
        }
        public void Usar()
        {
            GL.UseProgram(Programa);
        }
        public int GetAttribLocation(string attribName)
        {
            return GL.GetAttribLocation(Programa, attribName);
        }

        /// <summary>
        /// Set a uniform int on this shader.
        /// </summary>
        /// <param name="name">El nombre del uniform</param>
        /// <param name="data">La data a setear</param>
        public void SetInt(string name, int data)
        {
            GL.UseProgram(Programa);
            GL.Uniform1(_ubicaciones[name], data);
        }
        /// <summary>
        /// Set a uniform float on this shader.
        /// </summary>
        public void SetFloat(string name, float data)
        {
            GL.UseProgram(Programa);
            GL.Uniform1(_ubicaciones[name], data);
        }
        /// <summary>
        /// Set a uniform Matrix4 on this shader
        /// </summary>
        /// <remarks>
        ///   <para>
        ///   The matrix is transposed before being sent to the shader.
        ///   </para>
        /// </remarks>
        public void SetMatrix4(string name, Matrix4 data)
        {
            GL.UseProgram(Programa);
            GL.UniformMatrix4(_ubicaciones[name], true, ref data);
        }
        /// <summary>
        /// Set a uniform Vector3 on this shader.
        /// </summary>
        public void SetVector3(string name, Vector3 data)
        {
            GL.UseProgram(Programa);
            GL.Uniform3(_ubicaciones[name], data);
        }
    }
}
