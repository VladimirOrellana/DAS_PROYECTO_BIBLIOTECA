using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Cargar y mostrar la lista de libros cuando se abre el formulario
            ActualizarListaLibros();

            // Crear las columnas de Editar y Eliminar si no existen
            if (!dataGridViewLibros.Columns.Contains("Editar"))
            {
                DataGridViewButtonColumn editarColumn = new DataGridViewButtonColumn
                {
                    Name = "Editar",
                    HeaderText = "Editar",
                    Text = "Editar",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewLibros.Columns.Add(editarColumn);
            }

            if (!dataGridViewLibros.Columns.Contains("Eliminar"))
            {
                DataGridViewButtonColumn eliminarColumn = new DataGridViewButtonColumn
                {
                    Name = "Eliminar",
                    HeaderText = "Eliminar",
                    Text = "Eliminar",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewLibros.Columns.Add(eliminarColumn);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir el formulario para agregar un nuevo libro
            AgregarLibroForm agregarLibroForm = new AgregarLibroForm();
            agregarLibroForm.ShowDialog();

            // Actualizar la lista de libros en el DataGridView después de agregar un libro
            ActualizarListaLibros();
        }

        private void ActualizarListaLibros()
        {
            // Cargar los libros desde el archivo JSON
            List<libro> libros = DataManager.CargarLibros();

            // Limpiar la fuente de datos del DataGridView
            dataGridViewLibros.DataSource = null;

            // Asignar la lista de libros como fuente de datos del DataGridView
            dataGridViewLibros.DataSource = libros;
        }

        private void ActualizarListaUsuarios()
        {
            // Cargar los usuarios desde el archivo JSON
            List<Usuario> usuarios = DataManager.CargarUsuarios;

            // Limpiar la fuente de datos del DataGridView
            dataGridViewLibros.DataSource = null;

            // Asignar la lista de usuarios como fuente de datos del DataGridView
            dataGridViewLibros.DataSource = usuarios;
        }

        private void ActualizarListaPrestamos()
        {
            List<Prestamo> prestamos = DataManager.CargarPrestamos();
            List<libro> libros = DataManager.CargarLibros();
            List<Usuario> usuarios = DataManager.CargarUsuarios;


            dataGridViewLibros.DataSource = prestamos;


        }

        private void dataGridViewLibros_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Evitar errores si se hace clic en la fila de encabezado
            if (e.RowIndex < 0) return;

            // Verificar si se hizo clic en el botón Editar
            if (e.ColumnIndex == dataGridViewLibros.Columns["Editar"].Index)
            {
                // Verificar el tipo de datos en el DataGridView
                if (dataGridViewLibros.DataSource is List<libro> libros)
                {
                    // Obtener el ID del libro seleccionado
                    int idLibro = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Abrir el formulario de edición con los datos del libro seleccionado
                    EditarLibroForm editarLibroForm = new EditarLibroForm(idLibro);
                    editarLibroForm.ShowDialog();

                    // Actualizar la lista de libros después de la edición
                    ActualizarListaLibros();
                }
                else if (dataGridViewLibros.DataSource is List<Usuario> usuarios)
                {
                    // Obtener el ID del usuario seleccionado
                    int idUsuario = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Abrir el formulario de edición con los datos del usuario seleccionado
                    EditarUsuarioForm editarUsuarioForm = new EditarUsuarioForm(idUsuario);
                    editarUsuarioForm.ShowDialog();

                    // Actualizar la lista de usuarios después de la edición
                    ActualizarListaUsuarios();
                }
                else if (dataGridViewLibros.DataSource is List<Prestamo> prestamos)
                {
                    // Obtener el ID del préstamo seleccionado
                    int idPrestamo = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Abrir el formulario de edición con los datos del préstamo seleccionado
                    EditarPrestamoForm editarPrestamoForm = new EditarPrestamoForm(idPrestamo);
                    editarPrestamoForm.ShowDialog();

                    // Actualizar la lista de préstamos después de la edición
                    ActualizarListaPrestamos();
                }
            }
            // Verificar si se hizo clic en el botón Eliminar
            else if (e.ColumnIndex == dataGridViewLibros.Columns["Eliminar"].Index)
            {
                if (dataGridViewLibros.DataSource is List<libro> libros)
                {
                    // Obtener el ID del libro seleccionado
                    int idLibro = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este libro?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Eliminar el libro del archivo JSON
                        DataManager.EliminarLibro(idLibro);

                        // Actualizar la lista de libros después de eliminar
                        ActualizarListaLibros();
                    }
                }
                else if (dataGridViewLibros.DataSource is List<Usuario> usuarios)
                {
                    // Obtener el ID del usuario seleccionado
                    int idUsuario = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este usuario?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Eliminar el usuario del archivo JSON
                        DataManager.EliminarUsuario(idUsuario);

                        // Actualizar la lista de usuarios después de eliminar
                        ActualizarListaUsuarios();
                    }
                }
                else if (dataGridViewLibros.DataSource is List<Prestamo> prestamos)
                {
                    // Obtener el ID del préstamo seleccionado
                    int idPrestamo = (int)dataGridViewLibros.Rows[e.RowIndex].Cells["Id"].Value;

                    // Confirmar eliminación
                    var confirmResult = MessageBox.Show("¿Estás seguro de eliminar este préstamo?", "Confirmar eliminación", MessageBoxButtons.YesNo);

                    if (confirmResult == DialogResult.Yes)
                    {
                        // Eliminar el préstamo del archivo JSON
                        DataManager.EliminarPrestamo(idPrestamo);

                        // Actualizar la lista de préstamos después de eliminar
                        ActualizarListaPrestamos();
                 
                    
                    }

                }


            }
        }

        private void btnRegistrarUsuario_Click(object sender, EventArgs e)
        {
            GestionarUsuarioForm registrarUsuarioForm = new GestionarUsuarioForm();
            registrarUsuarioForm.ShowDialog();
        }

        private void Libros_Click(object sender, EventArgs e)
        {
            ActualizarListaLibros();
        }

        private void Usuarios_Click(object sender, EventArgs e)
        {
            ActualizarListaUsuarios();
        }

        private void btnEstadisticas_Click(object sender, EventArgs e)
        {
            Form grafico = new grafico();
            grafico.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("button2_Click clickeado.");
        }
        private void button2_Click(object sender, EventArgs e)
            {
                // Implementa la lógica que desees para el botón aquí.
                MessageBox.Show("button2_Click clickeado.");
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void Prestamos_Click(object sender, EventArgs e)
        {
            ActualizarListaPrestamos();
        }

        private void btnRegistrarPrestamo_Click(object sender, EventArgs e)
        {
            RegistrarPrestamoForm registrarPrestamoForm = new RegistrarPrestamoForm();
            registrarPrestamoForm.ShowDialog();
        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnConsultarLibros_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscarLibro_Click_1(object sender, EventArgs e)
        {
            string inputId = textBoxBusqueda.Text;
            if (int.TryParse(inputId, out int libroId))
            {
                List<libro> libros = DataManager.CargarLibros();
                var libroEncontrado = libros.FirstOrDefault(l => l.Id == libroId);

                if (libroEncontrado != null)
                {
                    string infoLibro = $"ID: {libroEncontrado.Id}\n" +
                                   $"Título: {libroEncontrado.Titulo}\n" +
                                   $"Autor: {libroEncontrado.Autor}\n" +
                                   $"Año de Publicación: {libroEncontrado.AnioPublicacion}\n" +
                                   $"Género: {libroEncontrado.Genero}\n" +
                                   $"Disponibilidad: {(libroEncontrado.Disponible ? "Disponible" : "No Disponible")}";
                    MessageBox.Show(infoLibro, "Libro Encontrado");
                }
                else
                {
                    MessageBox.Show("Libro no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un ID válido.");
            }
        }

        private void btnBuscarUsuario_Click_1(object sender, EventArgs e)
        {
            string inputId = textBoxBusqueda.Text;
            if (int.TryParse(inputId, out int usuarioId))
            {
                List<Usuario> usuarios = DataManager.CargarUsuarios;
                var usuarioEncontrado = usuarios.FirstOrDefault(u => u.Id == usuarioId);

                if (usuarioEncontrado != null)
                {
                    string infoUsuario = $"ID: {usuarioEncontrado.Id}\n" +
                                     $"Nombre: {usuarioEncontrado.Nombre}\n" +
                                     $"Apellido: {usuarioEncontrado.Apellido}\n" +
                                     $"Email: {usuarioEncontrado.Email}\n" +
                                     $"Teléfono: {usuarioEncontrado.Telefono}\n" +
                                     $"Estado: {(usuarioEncontrado.Activo ? "Activo" : "Inactivo")}";
                    MessageBox.Show(infoUsuario, "Usuario Encontrado");
                }
                else
                {
                    MessageBox.Show("Usuario no encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un ID válido.");
            }
        }

        private void btnGestionarUsuario_Click(object sender, EventArgs e)
        {
            // Crear una instancia del formulario de gestión de usuario
            GestionarUsuarioForm gestionarUsuarioForm = new GestionarUsuarioForm();

            // Mostrar el formulario como un diálogo modal
            gestionarUsuarioForm.ShowDialog();
        }
    }
}




