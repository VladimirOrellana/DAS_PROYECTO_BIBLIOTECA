using System;

public class Prestamo
{
    public int Id { get; set; }
    public int LibroId { get; set; }
    public int UsuarioId { get; set; }
    public DateTime FechaPrestamo { get; set; }
    public DateTime FechaDevolucion { get; set; }
    public bool Devuelto { get; set; } // Nueva propiedad para indicar si el préstamo ha sido devuelto

    public Prestamo(int id, int libroId, int usuarioId)
    {
        Id = id;
        LibroId = libroId;
        UsuarioId = usuarioId;
        Devuelto = false; // Inicialmente no devuelto
    }
}
