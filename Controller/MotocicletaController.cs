using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Service;
using CRUDFinal.Domain.Contracts.ServiceContract;

namespace CRUDFinal.Controller
{
    public class MotocicletaController
    {
        private readonly IMotocicletaService _motocicletaService;
        public MotocicletaController(IMotocicletaService motocicletaService)
        {
            _motocicletaService = motocicletaService;
        }
        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
                        int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _motocicletaService.Add(marca, modelo, ano, tipo,
                                        bemCuidado, kilometragem);
            }
            else
            {
                Console.WriteLine("Ocorreu um erro.");
            }
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
        public void List()
        {
            _motocicletaService.List();
        }
        public bool Valid(string marca, string modelo, int ano)
        {
            if (marca != null && modelo != null && ano > 0)
            {
                return true;
            }
            return false;
        }
    }
}