using System.Collections.Generic;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Contracts.RepositoryContract;
using System.Linq;

namespace CRUDFinal.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private static List<Carro> _carrosVendidos = new List<Carro>();
        private static List<Carro> _carros = new List<Carro>();
        public void Add(Carro carro)
        {
            _carros.Add(carro);
        }
        public void AddVendido(Carro carroVendido)
        {
            _carrosVendidos.Add(carroVendido);
        }
        public void DeleteCarro(int id)
        {
            _carros.Remove(_carros[id]);
        }
        public void DeleteCarroVendido(int id)
        {
            _carrosVendidos.Remove(_carrosVendidos[id]);
        }
        public Carro CheckCarroVendido(int id)
        {
            return _carrosVendidos.Find(cv => cv.ID == id);
        }
        public Carro GetCarroVendido(int id)
        {
            return _carrosVendidos.FirstOrDefault(cv => cv.ID == id);
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
        public void UpdateVendido(Carro carro, Carro cv)
        {
            cv = _carrosVendidos.FirstOrDefault(cv => cv.ID == carro.ID);
        }
        public List<Carro> List()
        {
            return _carros;
        }
        public List<Carro> ListVenda()
        {
            return _carrosVendidos;
        }
    }
}