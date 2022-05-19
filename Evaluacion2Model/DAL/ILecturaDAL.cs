using Evaluacion2Model.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Model.DAL
{
    public interface ILecturaDAL
    {
        void AgregarMedidores(Medidor medidor);

        List<Medidor> ObtenerMedidores();
        List<Lectura> ObtenerLecturas();

        void AgregarLectura(Lectura lectura);
    }
}
