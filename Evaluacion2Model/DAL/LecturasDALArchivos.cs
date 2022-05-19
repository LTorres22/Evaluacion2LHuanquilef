using Evaluacion2Model.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Model.DAL
{
    public class LecturasDALArchivos : ILecturaDAL
    {
        private LecturasDALArchivos()
        {

        }
        private static LecturasDALArchivos instancia;

        private static List<Medidor> medidores = new List<Medidor>();

        public static ILecturaDAL GetInstacia()
        {
            if (instancia == null)
            {
                instancia = new LecturasDALArchivos();
            }
            return instancia;
        }

        private static string archivo = "lecturas.txt";
        private static string url = Directory.GetCurrentDirectory() + "/" + archivo;

        public void AgregarMedidores(Medidor medidor)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(url, true))
                {
                    string texto = medidor.NroMedidor + "|" + medidor.Fecha + "|" + medidor.ValorConsumo;
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir en archivo" + ex.Message);
            }
            finally
            {
            }
        }

        public List<Medidor> ObtenerMedidores()
        {
            List<Medidor> lista = new List<Medidor>();
            try
            {
                using (StreamReader reader = new StreamReader(archivo))
                {
                    string texto = "";
                    do
                    {
                        texto = reader.ReadLine();
                        if (texto != null)
                        {
                            string[] arr = texto.Trim().Split('|');
                            int nromedidor = Convert.ToInt32(arr[0]);
                            string fecha = arr[1];
                            double valorconsumo = Convert.ToDouble(arr[2]);
                            Medidor medidor = new Medidor()
                            {
                                NroMedidor = nromedidor,
                                Fecha = fecha,
                                ValorConsumo = valorconsumo
                            };
                            lista.Add(medidor);
                        }

                    } while (texto != null);
                }
            }
            catch (Exception)
            {
                lista = null;
            }
            return lista;
        }

        public List<Lectura> ObtenerLecturas()
        {
            List<Lectura> lecturas = new List<Lectura>();
            using (StreamReader reader = new StreamReader(url))
            {            
                string texto = "";
                do
                {
                    texto = reader.ReadLine();
                    if (texto != null)
                    {
                        string[] textoArr = texto.Trim().Split(';');
                        string conteoLectura = textoArr[0];

                        //crear una lectura
                        Lectura l = new Lectura()
                        {
                            ConteoLectura = conteoLectura                            
                        };                         
                        lecturas.Add(l);
                    }

                } while (texto != null);
            }
            return lecturas;
        }
    

    public void AgregarLectura(Lectura lectura)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(url, true))
                {
                    String texto = lectura.ConteoLectura;
                    writer.WriteLine(texto);
                    writer.Flush();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al escribir en archivo" + ex.Message);
            }
            finally
            {

            }
        }
    }
}