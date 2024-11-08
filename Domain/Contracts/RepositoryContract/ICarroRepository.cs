using System.Collections.Generic;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface ICarroRepository
    {
        public void Add(Carro carro);
        public void AddVendido(CarroVendido carroVendido);
        public void DeleteCarro(int id);
        public void DeleteCarroVendido(int id);
        public bool CheckCarroVendido(int id);
        public CarroVendido GetCarroVendido(int id);
        public Carro GetCarro(int id);
        public bool CheckCarro(int id);
        public void Update(Carro carroNovo, Carro carroOriginal);
        public void UpdateVendido(Carro carroNovoVendido, 
                                  Carro carroOriginalVendido);
        public List<Carro> List();
        public List<CarroVendido> ListVenda();
    }
}