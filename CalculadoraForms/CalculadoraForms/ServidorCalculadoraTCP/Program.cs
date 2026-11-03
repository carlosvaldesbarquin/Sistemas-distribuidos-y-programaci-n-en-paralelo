
using System;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Globalization;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        TcpListener servidor = new TcpListener(
            IPAddress.Loopback, 13000);

        servidor.Start();

        Console.WriteLine("Servidor multihilo iniciado");

        while (true)
        {
            Console.WriteLine("Esperando cliente...");

            TcpClient cliente = servidor.AcceptTcpClient();

            Console.WriteLine("Cliente conectado");

            // Creamos un hilo para atender al cliente
            Thread hilo = new Thread(AtenderCliente);

            // Pasamos el cliente al nuevo hilo
            hilo.Start(cliente);
        }
    }

    static void AtenderCliente(object objetoCliente)
    {
        TcpClient cliente = (TcpClient)objetoCliente;

        int idHilo = Thread.CurrentThread.ManagedThreadId;

        try
        {
            using (cliente)
            using (NetworkStream stream = cliente.GetStream())
            using (StreamReader lector = new StreamReader(stream))
            using (StreamWriter escritor = new StreamWriter(stream))
            {
                escritor.AutoFlush = true;

                Console.WriteLine(
                    "Hilo " + idHilo + ": Atendiendo cliente");

                string mensaje = lector.ReadLine();

                Console.WriteLine(
                    "Hilo " + idHilo + ": Recibido " + mensaje);

                string respuesta = ProcesarOperacion(mensaje);

                // Simulamos una operación que tarda 5 segundos
                Thread.Sleep(5000);

                escritor.WriteLine(respuesta);

                Console.WriteLine(
                    "Hilo " + idHilo + ": Enviado " + respuesta);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(
                "Hilo " + idHilo + ": Error: " + ex.Message);
        }

        Console.WriteLine(
            "Hilo " + idHilo + ": Finalizado");
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

        try
        {
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
                        return "ERROR: Division entre cero";
                    }

                    resultado = numero1 / numero2;
                    break;

                default:
                    return "ERROR: Operacion desconocida";
            }
        }
        catch (OverflowException)
        {
            return "ERROR: Resultado fuera de rango";
        }

        return resultado.ToString(
            CultureInfo.InvariantCulture);
    }
}
