using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class AgregarLibroForm : Form
    {
        private object txt;
        private object conexion;

        public AgregarLibroForm()
        {
            InitializeComponent();
        }

        private void AgregarLibroForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 1. Cargar la lista actual de libros
            List<libro> libros = DataManager.CargarLibros();

            // 2. Generar un nuevo ID para el libro
            int nuevoId = libros.Count > 0 ? libros[libros.Count - 1].Id + 1 : 1;

            // 3. Manejo de error para asegurar que el año sea un número válido
            int anioPublicacion;
            if (!int.TryParse(txtAnioPublicacion.Text, out anioPublicacion))
            {
                MessageBox.Show("Por favor, ingrese un año de publicación válido.");
                return;
            }

            // 4. Crear un nuevo objeto de tipo Libro, incluyendo la sinopsis
            libro nuevoLibro = new libro(
                nuevoId,                    // ID del libro
                txtTitulo.Text,             // Título
                anioPublicacion,            // Año de publicación
                txtGenero.Text,             // Género
                txtSinopsis.Text,           // Sinopsis 
                txtAutor.Text               // Autor
            );

            // 5. Agregar el nuevo libro a la lista
            libros.Add(nuevoLibro);

            // 6. Guardar la lista actualizada de libros en el archivo JSON
            DataManager.GuardarLibros(libros);

            // 7. Mostrar un mensaje de éxito
            MessageBox.Show("Libro agregado correctamente.");

            // 8. Cerrar el formulario
            this.Close();
        }

        private void txtAnioPublicacion_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtAutor_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBUSCAR_Click_1(object sender, EventArgs e)
        {
        }
    }
}
