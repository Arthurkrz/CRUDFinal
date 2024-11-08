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

        public void Add(Carro carro)
        {
            // logic
            _carroRepository.Add(carro);
        }

        public void Venda(CarroVendido carroVendido)
        {
            // logic
            _carroRepository.AddVendido(carroVendido);
            _carroRepository.DeleteCarro(carroVendido.ID);
        }

        public void Devolucao(Carro carro)
        {
            // logic
            _carroRepository.Add(carro);
            _carroRepository.DeleteCarroVendido(carro.ID);
        }

        public Carro GetCarro(int id)
        {
            return _carroRepository.GetCarroVendido(id);
        }

        public CarroVendido GetCarroVendido(int id)
        {
            return _carroRepository.GetCarroVendido(id);
        }

        public bool CheckCarro(int id, bool vendido)
        {
            if (vendido == true)
            {
                return _carroRepository.CheckCarroVendido(id) != false;
            }

            else
            {
                return _carroRepository.CheckCarro(id) != false;
            }
        }

        public void Update(Carro carroNovo, int id)
        {
            if (CheckCarro(id, false))
            {
                Carro carroOriginal = GetCarro(id);
                _carroRepository.Update(carroNovo, carroOriginal);
                Console.WriteLine("Carro atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O ID inserido não corresponde " +
                                  "a nenhum carro.");
            }
        }

        public void UpdateVendido(Carro carroNovoVendido, int id)
        {
            if (CheckCarro(id, true))
            {
                Carro carroOriginalVendido = GetCarroVendido(id);
                _carroRepository.UpdateVendido(carroNovoVendido, 
                                               carroOriginalVendido);
                Console.WriteLine("Registro de venda atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("O ID inserido não corresponde " +
                                  "a registro de carro vendido.");
            }
        }

        public List<Carro> List()
        {
            return _carroRepository.List();
        }

        public List<CarroVendido> ListVenda()
        {
            return _carroRepository.ListVenda();
        }

        public CarroVendido DownCast(Carro carro, DateTime dataVenda, int preco)
        {
            CarroVendido carroVendido = new CarroVendido
            {
                Marca = carro.Marca,
                Modelo = carro.Modelo,
                Ano = carro.Ano,
                Tipo = carro.Tipo,
                DataVenda = dataVenda,
                Preco = preco
            };

            return carroVendido;
        }

        public Carro UpCast(CarroVendido carroVendido, Opcao automatico, 
                            Opcao bemCuidado, int km)
        {
            Carro carro = new Carro
            {
                Marca = carroVendido.Marca,
                Modelo = carroVendido.Modelo,
                Ano = carroVendido.Ano,
                Tipo = carroVendido.Tipo,
                Automatico = automatico,
                BemCuidado = bemCuidado,
                Kilometragem = km
            };

            return carro;
        }
    }
}