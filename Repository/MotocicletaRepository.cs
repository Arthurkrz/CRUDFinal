using System.Collections.Generic;
using CRUDFinal.Domain.Entities;
using System.Linq;
using CRUDFinal.Domain.Contracts.RepositoryContract;

namespace CRUDFinal.Repository
{
    public class MotocicletaRepository : IMotocicletaRepository
    {
        private static List<Motocicleta> _motosVendidas = new List<Motocicleta>();
        private static List<Motocicleta> _motos = new List<Motocicleta>();
        public void Add(Motocicleta moto)
        {
            _motos.Add(moto);
        }
        public void AddVendido(Motocicleta motoVendida)
        {
            _motosVendidas.Add(motoVendida);
        }
        public void DeleteMoto(int id)
        {
            _motos.Remove(_motos[id]);
        }
        public void DeleteMotoVendida(int id)
        {
            _motosVendidas.Remove(_motosVendidas[id]);
        }
        public Motocicleta CheckMotocicletaVendida(int id)
        {
            return _motosVendidas.Find(mv => mv.ID == id);
        }
        public Motocicleta GetMotocicletaVendida(int id)
        {
            return _motosVendidas.FirstOrDefault(mv => mv.ID == id);
        }
        public Motocicleta GetMotocicleta(int id)
        {
            return _motos.FirstOrDefault(m => m.ID == id);
        }
        public Motocicleta CheckMotocicleta(int id)
        {
            return _motos.Find(m => m.ID == id);
        }
        public void Update(Motocicleta moto, Motocicleta m)
        {
            m = _motos.FirstOrDefault(m => m.ID == moto.ID);
        }
        public void UpdateVendida(Motocicleta moto, Motocicleta mv)
        {
            mv = _motosVendidas.FirstOrDefault(mv => mv.ID == moto.ID);
        }
        public List<Motocicleta> List()
        {
            return _motos;
        }
    }
}
