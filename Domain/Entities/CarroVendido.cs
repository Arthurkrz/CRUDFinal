using System;

namespace CRUDFinal.Domain.Entities
{
    public class CarroVendido : Carro
    {
        public CarroVendido(DateTime dataVenda, double preco, string marca, string modelo)
        {
            this.DataVenda = dataVenda;
            this.Preco = preco;
            this.Marca = marca;
            this.Modelo = modelo;
        }
        public DateTime DataVenda { get; set; }
        public double Preco { get; set; }
    }
}
