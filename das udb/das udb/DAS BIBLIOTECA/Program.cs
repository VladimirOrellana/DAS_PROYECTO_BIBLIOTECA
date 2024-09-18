using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DAS_BIBLIOTECA
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Mostrar el formulario de login primero
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() == DialogResult.OK)
            {
                // Si el login es exitoso, mostrar el formulario principal
                Application.Run(new MainForm());
            }
            else
            {
                // Si el login falla, salir de la aplicación
                Application.Exit();
            }
        }
    }
}
