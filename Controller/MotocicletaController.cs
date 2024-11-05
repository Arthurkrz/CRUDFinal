using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Controller
{
    public class MotocicletaController
    {
        private readonly IMotocicletaService _motocicletaService;
        public MotocicletaController(IMotocicletaService motocicletaService)
        {
            _motocicletaService = motocicletaService;
        }
        public bool Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
                        int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _motocicletaService.Add(marca, modelo, ano, tipo,
                                        bemCuidado, kilometragem);
                return true;
            }
            return false;
        }
        public void Venda(Motocicleta moto, DateTime dataVenda, int preco)
        {
            _motocicletaService.Venda(moto, dataVenda, preco);
        }
        public void Devolucao(MotocicletaVendida mv)
        {
            _motocicletaService.Devolucao(mv);
        }
        public void Update(Motocicleta moto, Motocicleta m, bool vendida)
        {
            _motocicletaService.Update(moto, m, vendida);
        }
        public Motocicleta GetMotocicleta(int id, bool vendida)
        {
            return _motocicletaService.GetMotocicleta(id, vendida);
        }
        public bool CheckMotocicleta(int id, bool vendida)
        {
            return _motocicletaService.CheckMotocicleta(id, vendida) != null;
        }
        public List<Motocicleta> List()
        {
            return _motocicletaService.List();
        }
        public List<Motocicleta> ListVenda()
        {
            return _motocicletaService.ListVenda();
        }
        public bool Valid(string marca, string modelo, int ano)
        {
            if (marca != null && modelo != null && ano > 0)
            {
                return true;
            }
            return false;
        }
        public Motocicleta DownCast(Motocicleta motoVendida)
        {
            return _motocicletaService.DownCast(motoVendida);
        }
    }
}