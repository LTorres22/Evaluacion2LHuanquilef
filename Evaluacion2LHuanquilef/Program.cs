using Evaluacion2LHuanquilef.Comunicaciones;
using Evaluacion2Model.DAL;
using Evaluacion2Model.DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Evaluacion2LHuanquilef
{
    public partial class Program
    {
        private static ILecturaDAL lecturaDAL = LecturasDALArchivos.GetInstacia();

        static void IniciarServidorConPuerto(int puerto)
        {
            ServidorHebra hebra = new ServidorHebra(puerto);
            Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
            t.IsBackground = true;
            t.Start();
        }

        static void Main(string[] args)
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar puerto del servidor");
            Console.WriteLine("2. Iniciar en el puerto 3000");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("Ingresar puerto del servidor");
                    int puerto = Convert.ToInt32(Console.ReadLine());
                    IniciarServidorConPuerto(puerto);
                    break;
                case "2":
                    int puerto3000 = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);
                    ServidorHebra hebra = new ServidorHebra(puerto3000);
                    Thread t = new Thread(new ThreadStart(hebra.Ejecutar));
                    t.IsBackground = true;
                    t.Start();
                    break;
            }
            while (Menu()) ;
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar Medidor");
            Console.WriteLine("2. Mostrar Medidores");
            Console.WriteLine("3. Ingresar Lectura");
            Console.WriteLine("4. Mostrar Lecturas");
            Console.WriteLine("0. Salir");
            switch (Console.ReadLine().Trim())
            {
                case "1":
                    IngresarMedidor();
                    break;
                case "2":
                    MostrarMedidor();
                    break;
                case "3":
                    IngresarLectura();
                    break;
                case "4":
                    MostrarLectura();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Seleccione bien el numero");
                    break;
            }
            return continuar;
        }

        private static void MostrarLectura()
        {
            throw new NotImplementedException();
        }

        private static void IngresarLectura()
        {
            throw new NotImplementedException();
        }

        private static void MostrarMedidor()
        {
            List<Medidor> medidores = lecturaDAL.ObtenerMedidores();
            for (int i = 0; i < medidores.Count(); i++)
            {
                Medidor actual = medidores[i];
                Console.WriteLine("{0} : Nro. del Medidor : {1}, la Fecha : {2} y su valor del consumo: {3}", i, actual.NroMedidor, actual.Fecha, actual.ValorConsumo);
            }
        }

        private static void IngresarMedidor()
        {
            int nroMedidor;
            DateTime fecha = DateTime.Now;
            double valorConsumo;

            Console.WriteLine("Ingresando datos del medidor..");
            bool esValido;

            string fechaIngresada = String.Format("{0:yyyy-MM-dd-HH-mm-ss}", fecha);

            do
            {
                Console.WriteLine("Ingrese el numero del consumo:");
                esValido = Int32.TryParse(Console.ReadLine().Trim(), out nroMedidor);
            } while (!esValido);

            do
            {
                Console.WriteLine("Ingrese el valor del consumo:");
                esValido = double.TryParse(Console.ReadLine().Trim(), out valorConsumo);
            } while (!esValido);

            Medidor medidor = new Medidor()
            {
                NroMedidor = nroMedidor,
                ValorConsumo = valorConsumo,
                Fecha = fechaIngresada
            };
            lecturaDAL.AgregarMedidores(medidor);
            Console.WriteLine("Estamos Ok.");
        }
    }
}