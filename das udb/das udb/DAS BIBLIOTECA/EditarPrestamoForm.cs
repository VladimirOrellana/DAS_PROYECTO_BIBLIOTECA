using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class EditarPrestamoForm : Form
    {
        private int _idPrestamo;
        private Prestamo _prestamo;

        public EditarPrestamoForm(int idPrestamo)
        {
            InitializeComponent();
            _idPrestamo = idPrestamo;
        }

        private void EditarPrestamoForm_Load(object sender, EventArgs e)
        {
            // Cargar los datos del préstamo
            CargarDatosPrestamo();
        }

        private void CargarDatosPrestamo()
        {
            // Cargar los préstamos desde el DataManager
            List<Prestamo> prestamos = DataManager.CargarPrestamos();
            _prestamo = prestamos.FirstOrDefault(p => p.Id == _idPrestamo);

            if (_prestamo != null)
            {
                // Cargar los datos del préstamo en los controles
                textBoxLibroId.Text = _prestamo.LibroId.ToString();
                textBoxUsuarioId.Text = _prestamo.UsuarioId.ToString();
                textBoxNombre.Text = DataManager.CargarUsuarios.FirstOrDefault(u => u.Id == _prestamo.UsuarioId)?.Nombre ?? "";
                textBoxTitulo.Text = DataManager.CargarLibros().FirstOrDefault(l => l.Id == _prestamo.LibroId)?.Titulo ?? "";
                dateTimePickerFechaPrestamo.Value = _prestamo.FechaPrestamo;
                dateTimePickerFechaDevolucion.Value = (DateTime)_prestamo.FechaDevolucion;
            }
        }

        private void buttonGuardar_Click(object sender, EventArgs e)
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

            // Actualizar el préstamo
            if (_prestamo != null)
            {
                _prestamo.LibroId = libroId;
                _prestamo.UsuarioId = usuarioId;
                _prestamo.FechaPrestamo = fechaPrestamo;
                _prestamo.FechaDevolucion = fechaDevolucion;

                // Guardar los cambios
                List<Prestamo> prestamos = DataManager.CargarPrestamos();
                prestamos = prestamos.Where(p => p.Id != _idPrestamo).ToList();
                prestamos.Add(_prestamo);
                DataManager.GuardarPrestamos(prestamos);
            }

            // Cerrar el formulario
            this.Close();
        }

        private void buttonCancelar_Click(object sender, EventArgs e)
        {
            // Cerrar el formulario sin guardar cambios
            this.Close();
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

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
