
using System;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        Connect("127.0.0.1", "hola servidor");
    }

    static void Connect(string servidor, string mensaje)
    {
        try
        {
            int puerto = 13000;

            TcpClient cliente =
                new TcpClient(servidor, puerto);

            byte[] datos =
                Encoding.ASCII.GetBytes(mensaje);

            NetworkStream flujo = cliente.GetStream();

            flujo.Write(datos, 0, datos.Length);

            Console.WriteLine("Enviado: " + mensaje);

            datos = new byte[256];

            int leidos =
                flujo.Read(datos, 0, datos.Length);

            string respuesta =
                Encoding.ASCII.GetString(
                    datos, 0, leidos);

            Console.WriteLine("Recibido: " + respuesta);

            flujo.Close();
            cliente.Close();
        }
        catch (ArgumentNullException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        catch (SocketException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }

        Console.ReadLine();
    }
}
