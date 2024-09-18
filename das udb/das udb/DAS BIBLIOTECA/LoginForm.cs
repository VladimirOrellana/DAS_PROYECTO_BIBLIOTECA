using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            txtPassword.PasswordChar = '*';
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = txtUsuario.Text;
            string password = txtPassword.Text;

            if (ValidarCredenciales(usuario, password))
            {
                // Si las credenciales son válidas, cerrar el formulario de login con éxito
                this.DialogResult = DialogResult.OK;
                this.Close(); // Cerrar el formulario de login
            }
            else
            {
                lblMensajeError.Text = "Usuario o contraseña incorrectos.";
                lblMensajeError.Visible = true;
            }
        }

        private bool ValidarCredenciales(string usuario, string password)
        {
            // Simular la carga de usuarios (esto podría ser de una base de datos o un archivo)
            List<Usuario> usuarios = DataManager.CargarUsuarios;

            // Buscar si el usuario existe y la contraseña es correcta
            var usuarioEncontrado = usuarios.FirstOrDefault(u => u.NombreUsuario == usuario && u.Contraseña == password);
            return usuarioEncontrado != null;
        }

        private void lblMensajeError_Click(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
