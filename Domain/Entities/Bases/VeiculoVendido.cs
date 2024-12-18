using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDFinal.Domain.Entities
{
    public class VeiculoVendido : Veiculo
    {
        public DateTime DataVenda { get; set; }
        public double Preco { get; set; }
    }
}
