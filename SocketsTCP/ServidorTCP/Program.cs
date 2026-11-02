
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        TcpListener servidor = null;

        try
        {
            int puerto = 13000;
            IPAddress ip = IPAddress.Parse("127.0.0.1");

            servidor = new TcpListener(ip, puerto);
            servidor.Start();

            Console.WriteLine("Servidor iniciado");

            byte[] buffer = new byte[256];

            while (true)
            {
                Console.WriteLine("Esperando cliente...");

                TcpClient cliente = servidor.AcceptTcpClient();

                Console.WriteLine("Cliente conectado");

                NetworkStream flujo = cliente.GetStream();

                int leidos;

                while ((leidos = flujo.Read(
                    buffer, 0, buffer.Length)) != 0)
                {
                    string mensaje =
                        Encoding.ASCII.GetString(
                            buffer, 0, leidos);

                    Console.WriteLine("Recibido: " + mensaje);

                    string respuesta = mensaje.ToUpper();

                    byte[] datos =
                        Encoding.ASCII.GetBytes(respuesta);

                    flujo.Write(datos, 0, datos.Length);

                    Console.WriteLine("Enviado: " + respuesta);
                }

                cliente.Close();
                Console.WriteLine("Cliente desconectado");
            }
        }
        catch (SocketException e)
        {
            Console.WriteLine("Error: " + e.Message);
        }
        finally
        {
            servidor?.Stop();
        }
    }
}
