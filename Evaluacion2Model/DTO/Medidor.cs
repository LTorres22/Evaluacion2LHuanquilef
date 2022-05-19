using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Evaluacion2Model.DTO
{
    public class Medidor
    {
        private int nroMedidor;
        private string fecha;
        private double valorConsumo;

        public int NroMedidor { get => nroMedidor; set => nroMedidor = value; }
        public string Fecha { get => fecha; set => fecha = value; }
        public double ValorConsumo { get => valorConsumo; set => valorConsumo = value; }
    }
}