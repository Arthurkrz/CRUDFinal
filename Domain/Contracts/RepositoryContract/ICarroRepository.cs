using System.Collections.Generic;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface ICarroRepository
    {
        public void Add(Carro carro);
        public void Venda(int id);
        public void Update(Carro carro, Carro c);
        public Carro GetCarro(int id);
        public Carro CheckCarro(int id);
        public List<Carro> List();
    }
}