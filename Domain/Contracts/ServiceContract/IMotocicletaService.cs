using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface IMotocicletaService
    {
        public void Add(Motocicleta moto);
        public void Venda(MotocicletaVendida motoVendida);
        public void Devolucao(Motocicleta moto);
        public Motocicleta GetMotocicleta(int id);
        public MotocicletaVendida GetMotocicletaVendida(int id);
        public bool CheckMotocicleta(int id, bool vendida);
        public void Update(Motocicleta motoNova, int id);
        public void UpdateVendida(MotocicletaVendida motoVendidaNova, int id);
        public List<Motocicleta> List();
        public List<MotocicletaVendida> ListVenda();
        public MotocicletaVendida DownCast(Motocicleta moto, DateTime dataVenda,
                                    int preco);
        public Motocicleta UpCast(MotocicletaVendida motoVendida, 
                                  Opcao bemCuidada, int km);
    }
}