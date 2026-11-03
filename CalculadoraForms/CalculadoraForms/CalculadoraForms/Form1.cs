using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.IO;
using System.Globalization;

namespace CalculadoraForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }




        private void btnSumar_Click(object sender, EventArgs e)
        {
            decimal numero1;
            decimal numero2;

            bool valido1 = decimal.TryParse(
                txtNumero1.Text, out numero1);

            bool valido2 = decimal.TryParse(
                txtNumero2.Text, out numero2);

            if (!valido1 || !valido2)
            {
                MessageBox.Show("Introduce dos numeros validos");
                return;
            }

            if (cmbOperacion.SelectedItem == null)
            {
                MessageBox.Show("Selecciona una operacion");
                return;
            }

            string operacion = cmbOperacion.SelectedItem.ToString();

            try
            {
                using (TcpClient cliente = new TcpClient(
                    "127.0.0.1", 13000))
                using (NetworkStream stream = cliente.GetStream())
                using (StreamReader lector = new StreamReader(stream))
                using (StreamWriter escritor = new StreamWriter(stream))
                {
                    escritor.AutoFlush = true;

                    string mensaje =
                        operacion + ";" +
                        numero1.ToString(CultureInfo.InvariantCulture) + ";" +
                        numero2.ToString(CultureInfo.InvariantCulture);

                    escritor.WriteLine(mensaje);

                    string respuesta = lector.ReadLine();

                    if (respuesta == null)
                    {
                        MessageBox.Show("El servidor no respondio");
                        return;
                    }

                    if (respuesta.StartsWith("ERROR:"))
                    {
                        MessageBox.Show(respuesta);
                    }
                    else
                    {
                        lblResultado.Text = "Resultado: " + respuesta;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error de comunicacion: " + ex.Message);
            }
        }


    }
}
