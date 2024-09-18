using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS_BIBLIOTECA
{
    public static class DataManager
    {
        private static string rutaLibros = "libros.json";
        private static string rutaUsuarios = "usuarios.json";
        private static string rutaPrestamos = "prestamos.json";

        // Métodos para Libros
        public static List<libro> CargarLibros()
        {
            if (File.Exists(rutaLibros))
            {
                string json = File.ReadAllText(rutaLibros);
                return JsonConvert.DeserializeObject<List<libro>>(json);
            }
            else
            {
                return new List<libro>();
            }
        }

        public static void GuardarLibros(List<libro> libros)
        {
            string json = JsonConvert.SerializeObject(libros, Formatting.Indented);
            File.WriteAllText(rutaLibros, json);
        }

        // Métodos para Usuarios
        public static List<Usuario> CargarUsuarios
        {
            get
            {
                if (File.Exists(rutaUsuarios))
                {
                    string json = File.ReadAllText(rutaUsuarios);
                    return JsonConvert.DeserializeObject<List<Usuario>>(json);
                }
                else
                {
                    return new List<Usuario>();
                }
            }
        }

        public static void GuardarUsuarios(List<Usuario> usuarios)
        {
            string json = JsonConvert.SerializeObject(usuarios, Formatting.Indented);
            File.WriteAllText(rutaUsuarios, json);
        }

        // Métodos para Préstamos
        public static List<Prestamo> CargarPrestamos()
        {
            if (File.Exists(rutaPrestamos))
            {
                string json = File.ReadAllText(rutaPrestamos);
                return JsonConvert.DeserializeObject<List<Prestamo>>(json);
            }
            else
            {
                return new List<Prestamo>();
            }
        }

        public static void GuardarPrestamos(List<Prestamo> prestamos)
        {
            string json = JsonConvert.SerializeObject(prestamos, Formatting.Indented);
            File.WriteAllText(rutaPrestamos, json);
        }

        public static void EliminarLibro(int id)
        {
            // Cargar la lista actual de libros
            List<libro> libros = CargarLibros();

            // Buscar el libro a eliminar
            libro libroAEliminar = libros.FirstOrDefault(l => l.Id == id);

            // Si se encuentra el libro, eliminarlo
            if (libroAEliminar != null)
            {
                libros.Remove(libroAEliminar);

                // Guardar la lista actualizada de libros en el archivo JSON
                GuardarLibros(libros);
            }
        }

        public static void EliminarUsuario(int idUsuario)
        {
            List<Usuario> usuarios = CargarUsuarios;
            usuarios.RemoveAll(u => u.Id == idUsuario); // Eliminar usuario por Id
            GuardarUsuarios(usuarios); // Guardar la lista actualizada en el archivo JSON
        }
        public static void EliminarPrestamo(int id)
        {
            List<Prestamo> prestamos = CargarPrestamos();
            prestamos.RemoveAll(p => p.Id == id); // Eliminar préstamo por Id
            GuardarPrestamos(prestamos); // Guardar la lista actualizada en el archivo JSON
        }


    }
}
