using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Controller
{
    public class CarroController
    {
        private readonly ICarroService _carroService;
        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }
        public bool Add(string marca, string modelo, int ano, 
                        TipoAutomovel tipo, Opcao bemCuidado,
                        Opcao automatico, int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _carroService.Add(marca, modelo, ano, tipo, automatico,
                                  bemCuidado, kilometragem);
                return true;
            }
                return false;
        }
        public void Venda(Carro carro, DateTime dataVenda, int preco)
        {
            _carroService.Venda(carro, dataVenda, preco);
        }
        public void Devolucao(CarroVendido cv)
        {
            _carroService.Devolucao(cv);
        }
        public void Update(Carro carro, Carro c, bool vendido)
        {
            _carroService.Update(carro, c, vendido);
        }
        public Carro GetCarro(int id, bool vendido)
        {
            return _carroService.GetCarro(id, vendido);
        }
        public bool CheckCarro(int id, bool vendido)
        {
            return _carroService.CheckCarro(id, vendido) != null;
        }
        public List<Carro> List()
        {
            return _carroService.List();
        }
        public List<Carro> ListVenda()
        {
            return _carroService.ListVenda();
        }
        public bool Valid(string marca, string modelo, int ano)
        {
            if (marca != null && modelo != null && ano > 0)
            {
                return true;
            }
            return false;
        }
        public Carro DownCast(Carro carroVendido)
        {
            return _carroService.DownCast(carroVendido);
        }
    }
}