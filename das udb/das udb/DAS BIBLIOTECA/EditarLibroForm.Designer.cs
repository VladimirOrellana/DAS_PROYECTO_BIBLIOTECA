using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class EditarLibroForm : Form
    {
        private int idLibro; // Variable para almacenar el ID del libro actual

        public EditarLibroForm(int idLibro)
        {
            InitializeComponent();
            this.idLibro = idLibro;

            // Cargar la información del libro con base en el id
            CargarDatosLibro();
        }

        private void CargarDatosLibro()
        {
            // Cargar todos los libros
            List<libro> libros = DataManager.CargarLibros();

            // Buscar el libro correspondiente por ID
            libro libroAEditar = libros.FirstOrDefault(l => l.Id == idLibro);

            if (libroAEditar != null)
            {
                // Rellenar los campos del formulario con la información del libro
                txtTitulo.Text = libroAEditar.Titulo;
                txtAutor.Text = libroAEditar.Autor;
                txtAnioPublicacion.Text = libroAEditar.Año.ToString();
                txtGenero.Text = libroAEditar.Genero;
                txtSinopsis.Text = libroAEditar.Sinopsis;
            }
            else
            {
                MessageBox.Show("Libro no encontrado.");
                this.Close();
            }
        }

        private Button btnGuardar;
        private TextBox txtSinopsis;
        private TextBox txtGenero;
        private TextBox txtAnioPublicacion;
        private TextBox txtAutor;
        private TextBox txtTitulo;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
    }

}