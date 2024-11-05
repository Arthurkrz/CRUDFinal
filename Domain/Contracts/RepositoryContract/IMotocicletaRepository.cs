using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Entities;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface IMotocicletaRepository
    {
        public void Add(Motocicleta moto);
        public void AddVendido(Motocicleta motoVendida);
        public void DeleteMoto(int id);
        public void DeleteMotoVendida(int id);
        public Motocicleta CheckMotocicletaVendida(int id);
        public Motocicleta GetMotocicletaVendida(int id);
        public Motocicleta GetMotocicleta(int id);
        public Motocicleta CheckMotocicleta(int id);
        public void Update(Motocicleta moto, Motocicleta m);
        public void UpdateVendida(Motocicleta moto, Motocicleta mv);
        public List<Motocicleta> List();
    }
}
