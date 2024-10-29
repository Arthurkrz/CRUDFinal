using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Service;

namespace CRUDFinal.Controller
{
    public class CarroController
    {
        private CarroService _carroService;
        public CarroController()
        {
            _carroService = new CarroService();
        }
        public void Add(string marca,
                        string modelo,
                        int ano,
                        TipoAutomovel tipo,
                        Opcao automatico,
                        Opcao bemCuidado,
                        int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _carroService.Add(marca,
                                  modelo,
                                  ano,
                                  tipo,
                                  automatico,
                                  bemCuidado,
                                  kilometragem);
            }
            else
            {
                Console.WriteLine("Ocorreu um erro.");
            }
        }
        public void Delete(int id)
        {
            // ISSO NÃO FAZ SENTIDO TROCA NO PROGRAM
            if (CheckCarro(id))
            {
                _carroService.Delete(id);
            }
            else
            {
                Console.WriteLine("O ID inserido não" +
                    " corresponde a nenhum carro.");
            }
        }
        public void GetCarro(int id)
        {
            _carroService.GetCarro(id);
        }
        public bool CheckCarro(int id)
        {
            if (_carroService.CheckCarro(id))
            {
                return true;
            }
            return false;
        }
        public void Update(Carro carro,
                           string marca,
                           string modelo,
                           int ano,
                           TipoAutomovel tipo,
                           bool automatico,
                           bool bemCuidado,
                           int kilometragem)
        {
            _carroService.Update(carro, marca, modelo, ano, tipo, automatico, bemCuidado, kilometragem);
        }
        public void List()
        {
            _carroService.List();
        }
        public bool Valid(string marca,
                          string modelo,
                          int ano)
        {
            if (marca != null && modelo != null && ano > 0)
            {
                return true;
            }
            return false;
        }
    }
}
