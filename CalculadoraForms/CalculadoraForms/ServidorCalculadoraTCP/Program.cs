

using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        TcpListener servidor = new TcpListener(
            IPAddress.Loopback, 13000);

        servidor.Start();

        Console.WriteLine("Servidor iniciado en puerto 13000");

        while (true)
        {
            Console.WriteLine("Esperando cliente...");

            try
            {
                using (TcpClient cliente = servidor.AcceptTcpClient())
                using (NetworkStream stream = cliente.GetStream())
                using (StreamReader lector = new StreamReader(stream))
                using (StreamWriter escritor = new StreamWriter(stream))
                {
                    escritor.AutoFlush = true;

                    string mensaje = lector.ReadLine();

                    Console.WriteLine("Recibido: " + mensaje);

                    string respuesta = ProcesarOperacion(mensaje);

                    escritor.WriteLine(respuesta);

                    Console.WriteLine("Enviado: " + respuesta);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    static string ProcesarOperacion(string mensaje)
    {
        if (string.IsNullOrEmpty(mensaje))
        {
            return "ERROR: Mensaje vacio";
        }

        string[] partes = mensaje.Split(';');

        if (partes.Length != 3)
        {
            return "ERROR: Formato incorrecto";
        }

        string operacion = partes[0];

        decimal numero1;
        decimal numero2;

        bool valido1 = decimal.TryParse(
            partes[1],
            NumberStyles.Number,
            CultureInfo.InvariantCulture,
            out numero1);

        bool valido2 = decimal.TryParse(
            partes[2],
            NumberStyles.Number,
            CultureInfo.InvariantCulture,
            out numero2);

        if (!valido1 || !valido2)
        {
            return "ERROR: Numeros no validos";
        }

        decimal resultado;

        switch (operacion)
        {
            case "SUMAR":
                resultado = numero1 + numero2;
                break;

            case "RESTAR":
                resultado = numero1 - numero2;
                break;

            case "MULTIPLICAR":
                resultado = numero1 * numero2;
                break;

            case "DIVIDIR":
                if (numero2 == 0)
                {
                    return "ERROR: No se puede dividir entre cero";
                }

                resultado = numero1 / numero2;
                break;

            default:
                return "ERROR: Operacion desconocida";
        }

        return resultado.ToString(CultureInfo.InvariantCulture);
    }
}
