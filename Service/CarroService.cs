using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Service
{
    public class CarroService : ICarroService
    {
        private readonly ICarroRepository _carroRepository;
        public CarroService(ICarroRepository carroRepository)
        {
            _carroRepository = carroRepository;
        }
        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao automatico,
                        Opcao bemCuidado, int kilometragem)
        {
            Carro carro = new Carro()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Tipo = tipo,
                Automatico = automatico,
                BemCuidado = bemCuidado,
                Kilometragem = kilometragem
            };

            _carroRepository.Add(carro);
        }
        public void Venda(Carro carro, DateTime dataVenda, int preco)
        {
            _carroRepository.DeleteCarro(carro.ID);
            carro = new CarroVendido()
            {
                DataVenda = dataVenda,
                Preco = preco
            };
            _carroRepository.AddVendido(carro);
        }
        public void Devolucao(CarroVendido cv)
        {
            _carroRepository.Add(DownCast(cv));
            _carroRepository.DeleteCarroVendido(cv.ID);
        }
        public Carro GetCarro(int id, bool vendido)
        {
            if (vendido == true)
            {
                return _carroRepository.GetCarroVendido(id);
            }
            else
            {
                return _carroRepository.GetCarro(id);
            }
        }
        public bool CheckCarro(int id, bool vendido)
        {
            if (vendido == true)
            {
                return _carroRepository.CheckCarroVendido(id) != null;
            }
            else
            {
                return _carroRepository.CheckCarro(id) != null;
            }
        }
        public void Update(Carro carro, Carro c, bool vendido)
        {
            if (vendido == true)
            {
                _carroRepository.UpdateVendido(carro, c);
            }
            else
            {
                _carroRepository.Update(carro, c);
            }
        }
        public List<Carro> List()
        {
            return _carroRepository.List();
        }
        public List<Carro> ListVenda()
        {
            return _carroRepository.ListVenda();
        }
        public Carro DownCast(Carro carroVendido)
        {
            Carro carro = new Carro
            {
                Marca = carroVendido.Marca,
                Modelo = carroVendido.Modelo,
                Ano = carroVendido.Ano,
                Tipo = carroVendido.Tipo,
                BemCuidado = carroVendido.BemCuidado,
                Kilometragem = carroVendido.Kilometragem
            };
            return carro;
        }
    }
}