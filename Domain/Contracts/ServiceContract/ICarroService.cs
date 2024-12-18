using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface ICarroService
    {
        public void Add(Carro carro);
        public void Venda(CarroVendido carroVendido);
        public void Devolucao(Carro carro);
        public Carro GetCarro(int id);
        public CarroVendido GetCarroVendido(int id);
        public bool CheckCarro(int id, bool vendido);
        public void Update(Carro carroNovo, int id);
        public void UpdateVendido(CarroVendido carroNovo, int id);
        public List<Carro> List();
        public List<CarroVendido> ListVenda();
        public CarroVendido DownCast(Carro carro, DateTime datavenda, 
                              int preco);
        public Carro UpCast(CarroVendido carroVendido, Opcao automatico,
                            Opcao bemCuidado, int km);
    }
}