using BLL;
using EL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class Form1 : Form
    {
        // propiedaes
        private ClienteBLL _clienteBLL;

        // constructor
        public Form1()
        {
            InitializeComponent();

            // iniciarlizar _clienteBLL
            _clienteBLL = new ClienteBLL();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            // Salir de la aplicación
            Application.Exit();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (ValidarCampos())
                {
                    // guardar el cliente

                    // 1. Crear un objeto cliente
                    Cliente cliente = new Cliente();

                    // 2. Llenar los campos del objeto
                    cliente.Nombres = txtNombres.Text;
                    cliente.Apellidos = txtApellidos.Text;
                    cliente.Documento = mskTxtDUI.Text;
                    cliente.Email = txtEmail.Text;
                    cliente.Telefono = mskTxtTelefono.Text;

                    // 3. Guardar el cliente
                    int resultado = _clienteBLL.Guardar(cliente);

                    if (resultado > 0)
                    {
                        MessageBox.Show($"Cliente con ID: {resultado} ingresado con éxito", "Banco Verde", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un error al guardar el cliente", "Banco Verde", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // mostrar un mensaje
                    MessageBox.Show("Campos inválidos, favor llenar los campos requeridos.", "Banco Verde", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocurrio un error: {ex.Message}", "Banco Verde", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidarCampos()
        {
            bool esValido = false;

            if (!string.IsNullOrEmpty(txtNombres.Text) && !string.IsNullOrEmpty(txtApellidos.Text) && !string.IsNullOrEmpty(mskTxtDUI.Text))
            {
                esValido = true;
            }

            return esValido;
        }
    }
}
