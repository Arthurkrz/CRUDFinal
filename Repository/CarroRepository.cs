using System.Collections.Generic;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Contracts.RepositoryContract;
using System.Linq;

namespace CRUDFinal.Repository
{
    public class CarroRepository : ICarroRepository
    {
        private static List<CarroVendido> _carrosVendidos = new List<CarroVendido>();
        private static int _carrosVendidosCounter = 1;

        private static List<Carro> _carros = new List<Carro>();
        private static int _carrosCounter = 1;

        public void Add(Carro carro)
        {
            carro.ID = _carrosCounter++;
            _carros.Add(carro);
        }

        public void AddVendido(CarroVendido carroVendido)
        {
            carroVendido.ID = _carrosVendidosCounter++;
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

        public bool CheckCarroVendido(int id)
        {
            return _carrosVendidos.Any(cv => cv.ID == id);
        }

        public CarroVendido GetCarroVendido(int id)
        {
            return _carrosVendidos.FirstOrDefault(cv => cv.ID == id);
        }

        public Carro GetCarro(int id)
        {
            return _carros.FirstOrDefault(c => c.ID == id);
        }

        public bool CheckCarro(int id)
        {
            return _carros.Any(c => c.ID == id);
        }

        public void Update(Carro carroNovo, Carro carroOriginal)
        {
            carroOriginal = _carros.FirstOrDefault(c => c.ID == carroNovo.ID);
        }

        public void UpdateVendido(Carro carroNovoVendido, Carro carroOriginalVendido)
        {
            carroOriginalVendido = _carrosVendidos.FirstOrDefault
                                   (cv => cv.ID == carroNovoVendido.ID);
        }

        public List<Carro> List()
        {
            return _carros;
        }

        public List<CarroVendido> ListVenda()
        {
            return _carrosVendidos;
        }

    }
}