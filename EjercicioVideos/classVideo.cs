using System;
using System.Collections.Generic;
using System.Text;

namespace EjercicioVideos
{
    public class classVideo
    {
        public string Titulo { get; set; }
        public string URL { get; set; }
        public List<string> Tags { get; set; }
        public VideoStatus Estado { get; set; }

        public classVideo(string NuevoTitulo, string NuevaURL)
        {
            this.Titulo = NuevoTitulo;
            this.URL = NuevaURL;
            this.Tags = new List<string>();
            this.Estado = VideoStatus.Parado;
        }

        public void AddTag(string NuevoTag)
        {
            this.Tags.Add(NuevoTag);
        }

        public void CambiarEstado(VideoStatus NuevoEstado)
        {
            this.Estado = NuevoEstado;
        }
    }

    public enum VideoStatus
    {
        Parado,
        Reproduciendo,
        Pausado
    }
}
