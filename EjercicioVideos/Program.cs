using System;
using System.Collections.Generic;
using System.Linq;

namespace EjercicioVideos
{
    class Program
    {
        static List<classUsuario> userList;
        static classUsuario currentUser;

        static void Main(string[] args)
        {
            userList = new List<classUsuario>();
            RellenarDatos();

            string userName = string.Empty;
            string userPassword = string.Empty;

            bool userError = true;
            while (userError)
            {
                Console.Clear();
                Console.WriteLine("PROGRAMA DE VIDEOS");
                Console.WriteLine("Login");
                Console.WriteLine("----------------------------------");
                Console.Write("Nombre de usuario: ");
                userName = Console.ReadLine();

                Console.Write("Password: ");
                userPassword = Console.ReadLine();

                if (!userList.Where(u => u.Usuario == userName && u.Password == userPassword).Any())
                {
                    Console.WriteLine("Usuario y/o contraseña incorrecta.");
                    Console.WriteLine("Presione cualquier tecla para continuar.");
                    Console.ReadKey();
                }
                else
                    userError = false;
            }

            currentUser = userList.Where(u => u.Usuario == userName && u.Password == userPassword).FirstOrDefault();

            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }

        static void RellenarDatos()
        {
            classUsuario nUser = new classUsuario("jperez", "1234", "Juan", "Pérez");
            classVideo nVideo = new classVideo("Saltando a la comba", "https://pepe1.videos.com/saltando");
            nVideo.AddTag("Saltando");
            nVideo.AddTag("Ejercicio");
            nVideo.AddTag("Deporte");
            nUser.AddVideo(nVideo);

            nVideo = new classVideo("Levantando pesas", "https://pepe1.videos.com/pesas");
            nVideo.AddTag("Pesas");
            nVideo.AddTag("Entrenamiento");
            nUser.AddVideo(nVideo);
            userList.Add(nUser);

            nUser = new classUsuario("mgimenez", "4321", "Marta", "Giménez");
            nVideo = new classVideo("Canelones ricos", "https://youtube.com/watch?v=sdf89dEFser2");
            nVideo.AddTag("Comida");
            nVideo.AddTag("Cocina casera");
            nUser.AddVideo(nVideo);

            nVideo = new classVideo("La mejor forma de organizar camisetas", "https://youtube.com/watch?v=weroipER223j");
            nVideo.AddTag("Armarios");
            nVideo.AddTag("Organizar");
            nUser.AddVideo(nVideo);
            userList.Add(nUser);
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("PROGRAMA DE VIDEOS");
            Console.WriteLine($"Bienvenido {currentUser.Nombre} {currentUser.Apellidos}");
            Console.WriteLine("Menú principal");
            Console.WriteLine("----------------------------------");
            Console.WriteLine("1. Añadir video");
            Console.WriteLine("2. Mis videos");
            Console.WriteLine("0. Salir");
            Console.Write("Elija una opción: ");

            switch (Console.ReadLine())
            {
                case "1":
                    AddVideoMenu();
                    return true;
                case "2":
                    VerVideos();
                    return true;
                case "0":
                    return false;
                default:
                    return true;
            }
        }

        private static void AddVideoMenu()
        {
            string strTitulo = string.Empty;
            string strURL = string.Empty;
            Console.Clear();
            Console.WriteLine("PROGRAMA DE VIDEOS");
            Console.WriteLine("Añadir video");
            Console.WriteLine("----------------------------------");
            Console.Write("Título: ");
            bool isOK = false;
            while (!isOK)
            {
                strTitulo = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(strTitulo))
                {
                    Console.WriteLine("El título no puede estar en blanco.");
                    Console.Write("Título: ");
                }
                else
                    isOK = true;
            }
            
            Console.Write("URL: ");
            isOK = false;
            while (!isOK)
            {
                strURL = Console.ReadLine().Trim();
                if (string.IsNullOrEmpty(strURL))
                {
                    Console.WriteLine("La URL no puede estar en blanco.");
                    Console.Write("URL: ");
                }
                else
                    isOK = true;
            }
            classVideo nVideo = new classVideo(strTitulo, strURL);

            Console.WriteLine("Tags: (cada TAG en una línea, dejelo en blanco para terminar)");
            bool showTags = true;
            while (showTags)
            {
                string newTag = Console.ReadLine();
                if (string.IsNullOrEmpty(newTag))
                    showTags = false;
                else
                    nVideo.AddTag(newTag);
            }

            currentUser.AddVideo(nVideo);

            Console.WriteLine($"Video {strTitulo} añadido correctamente.");

            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }

        private static void VerVideos()
        {
            Console.Clear();
            Console.WriteLine("PROGRAMA DE VIDEOS");
            Console.WriteLine("Mis videos");
            Console.WriteLine("----------------------------------");
            foreach (var video in currentUser.Videos)
            {
                Console.WriteLine($"Video: {video.Titulo}, estado: {video.Estado}.");
                Console.WriteLine($"  URL: {video.URL}");
                Console.WriteLine($"  Tags: {string.Join(", ", video.Tags)}");
                Console.WriteLine("---");
            }
            
            Console.WriteLine("Presione cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
