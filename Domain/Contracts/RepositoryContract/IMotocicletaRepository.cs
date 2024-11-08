using CRUDFinal.Domain.Entities;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface IMotocicletaRepository
    {
        public void Add(Motocicleta moto);
        public void AddVendida(MotocicletaVendida motoVendida);
        public void DeleteMotocicleta(int id);
        public void DeleteMotocicletaVendida(int id);
        public bool CheckMotocicletaVendida(int id);
        public MotocicletaVendida GetMotocicletaVendida(int id);
        public Motocicleta GetMotocicleta(int id);
        public bool CheckMotocicleta(int id);
        public void Update(Motocicleta motoNova, Motocicleta motoOriginal);
        public void UpdateVendida(Motocicleta motoNovaVendida, 
                                  Motocicleta motoOriginalVendida);
        public List<Motocicleta> List();
        public List<MotocicletaVendida> ListVenda();
    }
}