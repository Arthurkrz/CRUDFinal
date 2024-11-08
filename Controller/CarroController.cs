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

        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
                        Opcao automatico, int km)
        {
            if (Valid(marca, modelo, ano))
            {
                Carro carro = new Carro()
                {
                    Marca = marca,
                    Modelo = modelo,
                    Ano = ano,
                    Tipo = tipo,
                    Automatico = automatico,
                    BemCuidado = bemCuidado,
                    Kilometragem = km
                };

                _carroService.Add(carro);
            }

        }

        public void Venda(int id, DateTime dataVenda, int preco)
        {
            var carro = GetCarro(id);
            var carroVendido = DownCast(carro, dataVenda, preco);
            _carroService.Venda(carroVendido);
        }

        public void Devolucao(int id, Opcao automatico, Opcao bemCuidado, 
                              int km)
        {
            var carroVendido = GetCarroVendido(id);
            var carro = UpCast(carroVendido, automatico, bemCuidado, km);
            _carroService.Devolucao(carro);
        }

        public void Update(int id, string marca, string modelo, int ano, 
                           Opcao bemCuidado, Opcao automatico, int km)
        {
            Carro carro = new Carro()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                BemCuidado = bemCuidado,
                Automatico = automatico,
                Kilometragem = km
            };

            _carroService.Update(carro, id);
        }

        public void UpdateVendido(int id, string marca, string modelo, int ano, 
                                  DateTime dataVenda, int preco)
        {
            CarroVendido carroVendido = new CarroVendido()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                DataVenda = dataVenda,
                Preco = preco
            };

            _carroService.UpdateVendido(carroVendido, id);
        }

        public Carro GetCarro(int id)
        {
            return _carroService.GetCarro(id);
        }

        public CarroVendido GetCarroVendido(int id)
        {
            return _carroService.GetCarroVendido(id);
        }

        public bool CheckCarro(int id, bool vendido)
        {
            return _carroService.CheckCarro(id, vendido) != false;
        }

        public List<Carro> List()
        {
            return _carroService.List();
        }

        public List<CarroVendido> ListVenda()
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

        public CarroVendido DownCast(Carro carro, DateTime dataVenda, int preco)
        {
            return _carroService.DownCast(carro, dataVenda, preco);
        }

        public Carro UpCast(CarroVendido carroVendido, Opcao automatico, 
                            Opcao bemCuidado, int km)
        {
            return _carroService.UpCast(carroVendido, automatico, bemCuidado, km);
        }

    }
}