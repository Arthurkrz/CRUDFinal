using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface ICarroService
    {
        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao automatico,
                        Opcao bemCuidado, int kilometragem);
        public void Venda(Carro moto, DateTime dataVenda, int preco);
        public void Devolucao(CarroVendido cv); // não é comando vermelho
        public Carro GetCarro(int id, bool vendido);
        public bool CheckCarro(int id, bool vendido);
        public void Update(Carro carro, Carro c, bool vendido);
        public List<Carro> List();
        public List<Carro> ListVenda();
        public Carro DownCast(Carro carroVendido);
    }
}