using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Service;
using CRUDFinal.Domain.Contracts.ServiceContract;

namespace CRUDFinal.Controller
{
    public class CarroController
    {
        private readonly ICarroService _carroService;
        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }
        public void Add(string marca, string modelo, int ano, TipoAutomovel tipo,
                        Opcao automatico, Opcao bemCuidado, int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _carroService.Add(marca, modelo, ano, tipo, automatico,
                                  bemCuidado, kilometragem);
            }
            else
            {
                Console.WriteLine("Ocorreu um erro.");
            }
        }
        public void Venda(int id)
        {
            // ISSO NÃO FAZ SENTIDO TROCA NO PROGRAM
            if (_carroService.CheckCarro(id))
            {
                _carroService.Venda(id);
            }
            else
            {
                Console.WriteLine("O ID inserido não" +
                    " corresponde a nenhum carro.");
            }
        }
        public void Update(Carro carro, string marca, string modelo, int ano,
                           TipoAutomovel tipo, Opcao automatico,
                           Opcao bemCuidado, int kilometragem)
        {
            _carroService.Update(carro, marca, modelo, ano, tipo,
                                 automatico, bemCuidado, kilometragem);
        }
        public void List()
        {
            _carroService.List();
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
