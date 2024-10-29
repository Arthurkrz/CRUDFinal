using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Entities
{
    class VeiculoVendido : Veiculo
    {
        public DateTime DataVenda { get; set; }
        public double Preco { get; set; }
    }
}
