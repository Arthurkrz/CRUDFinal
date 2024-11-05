using System;

namespace CRUDFinal.Domain.Entities
{
    public class CarroVendido : Carro
    {
        public DateTime DataVenda { get; set; }
        public double Preco { get; set; }
    }
}
