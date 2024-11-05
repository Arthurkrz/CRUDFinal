using System.Collections.Generic;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface ICarroRepository
    {
        public void Add(Carro carro);
        public void AddVendido(Carro carroVendido);
        public void DeleteCarro(int id);
        public void DeleteCarroVendido(int id);
        public Carro CheckCarroVendido(int id);
        public Carro GetCarroVendido(int id);
        public Carro GetCarro(int id);
        public Carro CheckCarro(int id);
        public void Update(Carro carro, Carro c);
        public void UpdateVendido(Carro carro, Carro cv);
        public List<Carro> List();
        public List<Carro> ListVenda();
    }
}