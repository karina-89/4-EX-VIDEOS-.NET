using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioVideos
{
    public class classUsuario
    {
        public string Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string Password { get; set; }
        public DateTime FechaRegistro { get; set; }

        public List<classVideo> Videos { get; set; }

        public classUsuario(string Usuario, string Password)
        {
            this.Usuario = Usuario;
            this.Password = Password;
            this.FechaRegistro = DateTime.Now;
            this.Videos = new List<classVideo>();
        }

        public classUsuario(string Usuario, string Password, string Nombre, string Apellidos)
        {
            this.Usuario = Usuario;
            this.Password = Password;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.FechaRegistro = DateTime.Now;
            this.Videos = new List<classVideo>();
        }

        public void AddVideo(classVideo NuevoVideo)
        {
            this.Videos.Add(NuevoVideo);
        }
    }
}
