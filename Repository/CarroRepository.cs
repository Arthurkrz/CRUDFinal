using System.Collections.Generic;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Contracts.RepositoryContract;
using System.Linq;

namespace CRUDFinal.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private static List<Carro> _carros = new List<Carro>();
        public void Add(Carro carro)
        {
            _carros.Add(carro);
        }
        public void Delete(int id)
        {
            _carros.Remove(_carros[id]);
        }
        public Carro GetCarro(int id)
        {
            return _carros.FirstOrDefault(c => c.ID == id);
        }
        public Carro CheckCarro(int id)
        {
            return _carros.Find(c => c.ID == id);
        }
        public void Update(Carro carro, Carro c)
        {
            c = _carros.FirstOrDefault(c => c.ID == carro.ID);
        }
        public List<Carro> List()
        {
            return _carros;
        }
    }
}
