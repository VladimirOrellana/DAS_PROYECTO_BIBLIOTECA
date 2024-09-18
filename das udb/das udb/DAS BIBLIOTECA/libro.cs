using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAS_BIBLIOTECA
{
    public class libro
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public int Año { get; set; }
        public string Genero { get; set; }
        public bool Disponible { get; set; }
        public string Sinopsis { get; set; }
        public object AnioPublicacion { get; internal set; }

        //construtor
        public libro(int id, string titulo, int año, string genero , string sinopsis, string autor) 
        {
            Id = id;
            Titulo = titulo;
            Autor = autor;
            Año = año;
            Genero=genero;
            Sinopsis = sinopsis;
            Disponible=true;
        }
        
    }

}
