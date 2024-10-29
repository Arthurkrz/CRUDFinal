using System.Collections.Generic;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface ICarroRepository
    {
        public void Add(Carro carro);
        public void Delete(int id);
        public void Update(Carro carro, Carro c);
        public List<Carro> List();
    }
}