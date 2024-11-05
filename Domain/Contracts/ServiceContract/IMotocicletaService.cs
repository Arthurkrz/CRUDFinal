using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface IMotocicletaService
    {
        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
                        int kilometragem);
        public void Venda(Motocicleta moto, DateTime dataVenda, int preco);
        public void Devolucao(MotocicletaVendida mv);
        public Motocicleta GetMotocicleta(int id, bool vendida);
        public bool CheckMotocicleta(int id, bool vendida);
        public void Update(Motocicleta moto, Motocicleta m, bool vendida);
        public List<Motocicleta> List();
        public List<Motocicleta> ListVenda();
        public Motocicleta DownCast(Motocicleta motoVendida);
    }
}