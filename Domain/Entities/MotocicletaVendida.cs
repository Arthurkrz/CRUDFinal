using System;

namespace CRUDFinal.Domain.Entities
{
    public class MotocicletaVendida : Motocicleta
    {
        public DateTime DataVenda { get; set; }
        public double Preco { get; set; }
    }
}
