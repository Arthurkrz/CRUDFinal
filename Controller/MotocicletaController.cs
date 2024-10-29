using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Service;

namespace CRUDFinal.Controller
{
    public class MotocicletaController
    {
        private MotocicletaService _motocicletaService;
        public MotocicletaController()
        {
            _motocicletaService = new MotocicletaService();
        }
        public void Add(string marca,
                        string modelo,
                        int ano,
                        TipoAutomovel tipo,
                        bool bemCuidado,
                        int kilometragem)
        {
            if (Valid(marca, modelo, ano))
            {
                _motocicletaService.Add(marca,
                                  modelo,
                                  ano,
                                  tipo,
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
            if (CheckMotocicleta(id))
            {
                _motocicletaService.Delete(id);
            }
            else
            {
                Console.WriteLine("O ID inserido não" +
                    " corresponde a nenhuma motocicleta.");
            }
        }
        public void GetMotocicleta(int id)
        {
            _motocicletaService.GetMotocicleta(id);
        }
        public bool CheckMotocicleta(int id)
        {
            if (_motocicletaService.CheckMotocicleta(id))
            {
                return true;
            }
            return false;
        }
        public void Update(Motocicleta moto,
                           string marca,
                           string modelo,
                           int ano,
                           TipoAutomovel tipo,
                           bool bemCuidado,
                           int kilometragem)
        {
            _motocicletaService.Update(moto, marca, modelo, ano, tipo, bemCuidado, kilometragem);
        }
        public void List()
        {
            _motocicletaService.List();
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
