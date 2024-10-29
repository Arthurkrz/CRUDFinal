using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface IMotocicletaRepository
    {
        public void Add(Motocicleta moto);
        public void Delete(int id);
        public void Update(Motocicleta moto, Motocicleta m);
        public List<Carro> List();
    }
}
