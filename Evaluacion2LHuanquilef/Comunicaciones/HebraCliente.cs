using Evaluacion2Model.DAL;
using Evaluacion2Model.DTO;
using ServerSocketsUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2LHuanquilef.Comunicaciones
{
     class HebraCliente
    {
        private static ILecturaDAL lecturaDAL = LecturasDALArchivos.GetInstacia();
        private ClienteCom clienteCom;

        public HebraCliente(ClienteCom clienteCom)
        {
            this.clienteCom = clienteCom;
        }

        public void Ejecutar()
        {
            clienteCom.Escribir("Ingrese Nro. del Medidor:");
            int nroMedidor = int.Parse(clienteCom.Leer());
            clienteCom.Escribir("Ingrese el valor del consumo:");
            double valorConsumo = double.Parse(clienteCom.Leer());
            DateTime fecha = DateTime.Now;
            string fechaIngresada = String.Format("{0:yyyy-MM-dd-HH-mm-ss}", fecha);
            Medidor medidor = new Medidor()
            {
                NroMedidor = nroMedidor,
                ValorConsumo = valorConsumo,
                Fecha = fechaIngresada
            };
            lock (lecturaDAL)
            {
                lecturaDAL.AgregarMedidores(medidor);
                Console.WriteLine("Se ingresaron los datos correctamente");
            }            
            clienteCom.Desconectar();
        }
    }
}