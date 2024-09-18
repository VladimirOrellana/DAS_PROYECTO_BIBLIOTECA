using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public class GestionarUsuarioForm : Form
    {
        private TextBox txtNombre;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtNombreUsuario; // Nuevo TextBox para Nombre de Usuario
        private TextBox txtContraseña; // Nuevo TextBox para Contraseña
        private ComboBox cmbTipoUsuario;
        private Button btnGuardar;
        private Label lblNombre;
        private Label lblDireccion;
        private Label lblEmail;
        private Label lblTipoUsuario;
        private Label lblNombreUsuario; // Nueva Label para Nombre de Usuario
        private Label lblContraseña; // Nueva Label para Contraseña
        private string rutaFotoSeleccionada;

        public GestionarUsuarioForm()
        {
            InicializarFormulario();
        }

        private void InicializarFormulario()
        {
            // Configurar el formulario
            this.Text = "Gestión de Usuario";
            this.Size = new Size(400, 600); // Aumentar el tamaño para los nuevos controles

            // Configurar imagen de fondo
            this.BackgroundImage = Properties.Resources.AGREGARLIBROS; // Imagen que agregaste en Resources
            this.BackgroundImageLayout = ImageLayout.Stretch; // Ajustar la imagen al tamaño del formulario

            // Crear y configurar los controles existentes
            lblNombre = new Label() { Text = "Nombre", Location = new Point(10, 20) };
            txtNombre = new TextBox() { Location = new Point(120, 20), Width = 200 };

            lblDireccion = new Label() { Text = "Dirección", Location = new Point(10, 60) };
            txtDireccion = new TextBox() { Location = new Point(120, 60), Width = 200 };

            lblEmail = new Label() { Text = "Email", Location = new Point(10, 100) };
            txtEmail = new TextBox() { Location = new Point(120, 100), Width = 200 };

            lblTipoUsuario = new Label() { Text = "Tipo Usuario", Location = new Point(10, 140) };
            cmbTipoUsuario = new ComboBox() { Location = new Point(120, 140), Width = 200 };
            cmbTipoUsuario.Items.AddRange(new string[] { "Estudiante", "Profesor", "Bibliotecario" });

            // Nuevos controles para Nombre de Usuario y Contraseña
            lblNombreUsuario = new Label() { Text = "Nombre de Usuario", Location = new Point(10, 180) };
            txtNombreUsuario = new TextBox() { Location = new Point(120, 180), Width = 200 };

            lblContraseña = new Label() { Text = "Contraseña", Location = new Point(10, 220) };
            txtContraseña = new TextBox() { Location = new Point(120, 220), Width = 200, UseSystemPasswordChar = true };

            // Botón para guardar
            btnGuardar = new Button() { Text = "Guardar", Location = new Point(100, 300) };
            btnGuardar.Click += BtnGuardar_Click;

            // Agregar los controles al formulario
            this.Controls.Add(lblNombre);
            this.Controls.Add(txtNombre);
            this.Controls.Add(lblDireccion);
            this.Controls.Add(txtDireccion);
            this.Controls.Add(lblEmail);
            this.Controls.Add(txtEmail);
            this.Controls.Add(lblTipoUsuario);
            this.Controls.Add(cmbTipoUsuario);
            this.Controls.Add(lblNombreUsuario);
            this.Controls.Add(txtNombreUsuario);
            this.Controls.Add(lblContraseña);
            this.Controls.Add(txtContraseña);
            this.Controls.Add(btnGuardar);
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            // Validación del correo electrónico
            if (!ValidarEmail(txtEmail.Text))
            {
                MessageBox.Show("El correo electrónico debe contener un '@' válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Crear un nuevo usuario con los datos ingresados
            Usuario nuevoUsuario = GetNuevoUsuario();

            // Guardar el usuario en la lista de usuarios (puedes usar JSON para almacenar)
            List<Usuario> usuarios = DataManager.CargarUsuarios;
            usuarios.Add(nuevoUsuario);
            DataManager.GuardarUsuarios(usuarios);

            MessageBox.Show("Usuario guardado correctamente.");
        }

        private Usuario GetNuevoUsuario()
        {
            Usuario usuario = new Usuario(
                                        id: GenerarNuevoId(), // Método para generar un nuevo ID
                                        nombre: txtNombre.Text,
                                        nombreUsuario: txtNombreUsuario.Text,
                                        contraseña: txtContraseña.Text,
                                        direccion: txtDireccion.Text,
                                        email: txtEmail.Text,
                                        tipoUsuario: cmbTipoUsuario.SelectedItem?.ToString() ?? "",
                                        rutaFoto: rutaFotoSeleccionada // Guardar la ruta de la foto seleccionada
                                    );
            return usuario;
        }

        private bool ValidarEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

        private int GenerarNuevoId()
        {
            // Lógica para generar un nuevo ID
            List<Usuario> usuarios = DataManager.CargarUsuarios;
            return usuarios.Count > 0 ? usuarios.Max(u => u.Id) + 1 : 1;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // GestionarUsuarioForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "GestionarUsuarioForm";
            this.Load += new System.EventHandler(this.GestionarUsuarioForm_Load);
            this.ResumeLayout(false);

        }

        private void GestionarUsuarioForm_Load(object sender, EventArgs e)
        {

        }
    }
}
