using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class RegistrarPrestamoForm : Form
    {
        public RegistrarPrestamoForm()
        {
            InitializeComponent();
        }

        private void buttonGuardar_Click_1(object sender, EventArgs e)
        {
            // Verificar que los campos obligatorios no estén vacíos
            if (string.IsNullOrWhiteSpace(textBoxLibroId.Text) ||
                string.IsNullOrWhiteSpace(textBoxUsuarioId.Text) ||
                string.IsNullOrWhiteSpace(textBoxNombre.Text) ||
                string.IsNullOrWhiteSpace(textBoxTitulo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos antes de guardar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Obtener los datos ingresados
            int libroId = int.Parse(textBoxLibroId.Text);
            int usuarioId = int.Parse(textBoxUsuarioId.Text);
            DateTime fechaPrestamo = dateTimePickerFechaPrestamo.Value;
            DateTime fechaDevolucion = dateTimePickerFechaDevolucion.Value;

            // Crear un nuevo préstamo
            int nuevoId = ObtenerNuevoId(); // Método para obtener un nuevo ID, implementa según tus necesidades
            Prestamo nuevoPrestamo = new Prestamo(nuevoId, libroId, usuarioId)
            {
                FechaPrestamo = fechaPrestamo,
                FechaDevolucion = fechaDevolucion
            };

            // Guardar el nuevo préstamo
            List<Prestamo> prestamos = DataManager.CargarPrestamos();
            prestamos.Add(nuevoPrestamo);
            DataManager.GuardarPrestamos(prestamos);

            // Cerrar el formulario
            this.Close();
        }

        private void buttonCancelar_Click_1(object sender, EventArgs e)
        {
            // Cerrar el formulario sin guardar cambios
            this.Close();
        }

        private int ObtenerNuevoId()
        {
            // Método para obtener un nuevo ID para el préstamo
            List<Prestamo> prestamos = DataManager.CargarPrestamos();
            if (prestamos.Count == 0)
            {
                return 1; // Primer ID si no hay préstamos
            }
            return prestamos.Max(p => p.Id) + 1; // Incrementar el ID del último préstamo
        }

        private void textBoxLibroId_TextChanged(object sender, EventArgs e)
        {
            // Obtener el ID del libro ingresado
            if (int.TryParse(textBoxLibroId.Text, out int libroId))
            {
                // Buscar el libro correspondiente
                libro libro = DataManager.CargarLibros().FirstOrDefault(l => l.Id == libroId);
                if (libro != null)
                {
                    // Rellenar el título del libro
                    textBoxTitulo.Text = libro.Titulo;
                }
                else
                {
                    // Limpiar el campo si no se encuentra el libro
                    textBoxTitulo.Text = "";
                }
            }
            else
            {
                // Limpiar el campo si el ID ingresado no es válido
                textBoxTitulo.Text = "";
            }
        }

        private void textBoxUsuarioId_TextChanged(object sender, EventArgs e)
        {
            // Obtener el ID del usuario ingresado
            if (int.TryParse(textBoxUsuarioId.Text, out int usuarioId))
            {
                // Buscar el usuario correspondiente
                Usuario usuario = DataManager.CargarUsuarios.FirstOrDefault(u => u.Id == usuarioId);
                if (usuario != null)
                {
                    // Rellenar el nombre del usuario
                    textBoxNombre.Text = usuario.Nombre;
                }
                else
                {
                    // Limpiar el campo si no se encuentra el usuario
                    textBoxNombre.Text = "";
                }
            }
            else
            {
                // Limpiar el campo si el ID ingresado no es válido
                textBoxNombre.Text = "";
            }
        }

        private void dateTimePickerFechaPrestamo_ValueChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar eventos si es necesario
        }

        private void dateTimePickerFechaDevolucion_ValueChanged(object sender, EventArgs e)
        {
            // Aquí puedes manejar eventos si es necesario
        }

        private void RegistrarPrestamoForm_Load(object sender, EventArgs e)
        {
            // Inicialización si es necesario
        }
    }
}
