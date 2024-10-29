using System.Collections.Generic;
using CRUDFinal.Domain.Entities;
using System.Linq;

namespace CRUDFinal.Repository
{
    public class MotocicletaRepository
    {
        private static List<Motocicleta> _motos = new List<Motocicleta>();
        public void Add(Motocicleta moto)
        {
            _motos.Add(moto);
        }
        public void Delete(int id)
        {
            _motos.Remove(_motos[id]);
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
        public List<Motocicleta> List()
        {
            return _motos;
        }
    }
}
