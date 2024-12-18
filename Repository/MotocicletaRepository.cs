using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CRUDFinal.Repository
{
    public class MotocicletaRepository : IRepository<Motocicleta>, IRepositoryVendido<MotocicletaVendida>
    {
        private static readonly List<MotocicletaVendida> _motosVendidas = new List<MotocicletaVendida>();
        private static int _motosVendidasCounter = 1;

        private static readonly List<Motocicleta> _motos = new List<Motocicleta>();
        private static int _motosCounter = 1;

        public void Add(Motocicleta moto)
        {
            moto.ID = _motosCounter++;
            _motos.Add(moto);
        }

        public void AddVendido(MotocicletaVendida motoVendida)
        {
            motoVendida.ID = _motosVendidasCounter++;
            _motosVendidas.Add(motoVendida);
        }

        public void Delete(int id)
        {
            _motos.Remove(_motos[id]);
        }

        public void DeleteVendido(int id)
        {
            _motosVendidas.Remove(_motosVendidas[id]);
        }

        public bool CheckVendido(int id)
        {
            return _motosVendidas.Any(mv => mv.ID == id);
        }

        public MotocicletaVendida GetVendido(int id)
        {
            return _motosVendidas.FirstOrDefault(mv => mv.ID == id);
        }

        public Motocicleta Get(int id)
        {
            return _motos.FirstOrDefault(m => m.ID == id);
        }

        public bool Check(int id)
        {
            return _motos.Any(m => m.ID == id);
        }

        public void Update(Motocicleta motoNova, Motocicleta motoOriginal)
        {
            motoOriginal = _motos.FirstOrDefault(m => m.ID == motoNova.ID);
        }

        public void UpdateVendido(MotocicletaVendida motoNovaVendida, 
                                  MotocicletaVendida motoOriginalVendida)
        {
            motoOriginalVendida = _motosVendidas.FirstOrDefault
                                  (mv => mv.ID == motoNovaVendida.ID);
        }

        public List<Motocicleta> List()
        {
            return _motos;
        }
        public List<MotocicletaVendida> ListVenda()
        {
            return _motosVendidas;
        }
    }
}