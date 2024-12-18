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
        private readonly IRepository<Carro> _carroRepository;
        private readonly IRepositoryVendido<CarroVendido> _carroVendidoRepository;

        public CarroService(IRepository<Carro> carroRepository, 
                            IRepositoryVendido<CarroVendido> carroVendidoRepository)
        {
            _carroRepository = carroRepository;
            _carroVendidoRepository = carroVendidoRepository;
        }

        public void Add(Carro carro)
        {
            if (carro.Marca.Length <= 2)
            {
                throw new ArgumentException("A marca do carro " +
                                            "deve ter mais de 2 linhas.");
            }
            else if (carro.Modelo.Length <= 2)
            {
                throw new ArgumentException("O modelo do carro " +
                                            "deve ter mais de 2 linhas.");
            }
            else if (carro.Ano < 1900)
            {
                throw new ArgumentException("O ano de fabricação " +
                                            "do carro deve ser" +
                                            "a partir do século XX.");
            } 
            _carroRepository.Add(carro);
            Console.WriteLine("Carro adicionado com sucesso!");
        }

        public void Venda(CarroVendido carroVendido)
        {
            if (carroVendido.Preco <= 0)
            {
                throw new ArgumentException("O preço de venda não pode" +
                                            " ser menor ou igual a zero.");
            }
            else if (carroVendido.DataVenda > DateTime.Now)
            {
                throw new ArgumentException("Data de venda inválida.");
            }
            _carroVendidoRepository.AddVendido(carroVendido);
            _carroRepository.Delete(carroVendido.ID);
        }

        public void Devolucao(Carro carro)
        {
            if (carro.Kilometragem < 0)
            {
                throw new ArgumentException("Não há como a kilometragem" +
                            " do carro ser abaixo de zero.");
            }
            _carroRepository.Add(carro);
            _carroVendidoRepository.DeleteVendido(carro.ID);
        }

        public Carro GetCarro(int id)
        {
            return _carroRepository.Get(id);
        }

        public CarroVendido GetCarroVendido(int id)
        {
            return _carroVendidoRepository.GetVendido(id);
        }

        public bool CheckCarro(int id, bool vendido)
        {
            if (vendido == true)
            {
                return _carroVendidoRepository.CheckVendido(id) != false;
            }

            else
            {
                return _carroRepository.Check(id) != false;
            }
        }

        public void Update(Carro carroNovo, int id)
        {
            if (CheckCarro(id, false))
            {
                if (carroNovo.Marca.Length <= 2)
                {
                    throw new ArgumentException("A marca do carro " +
                                                "deve ter mais de 2 linhas.");
                }
                else if (carroNovo.Modelo.Length <= 2)
                {
                    throw new ArgumentException("O modelo do carro " +
                                                "deve ter mais de 2 linhas.");
                }
                else if (carroNovo.Ano < 1900)
                {
                    throw new ArgumentException("O ano de fabricação " +
                                                "do carro deve ser" +
                                                "a partir do século XX.");
                }
                else if (carroNovo.Kilometragem < 0)
                {
                    throw new ArgumentException("Não há como a kilometragem" +
                                                " do carro ser abaixo de zero.");
                }

                Carro carroOriginal = GetCarro(id);
                _carroRepository.Update(carroNovo, carroOriginal);
                Console.WriteLine("Carro atualizado com sucesso!");
            }
            else
            {
                throw new ArgumentException("O ID inserido não " +
                                            "corresponde a nenhum carro.");
            }

        }

        public void UpdateVendido(CarroVendido carroNovoVendido, int id)
        {
            if (CheckCarro(id, true))
            {
                if (carroNovoVendido.Marca.Length <= 2)
                {
                    throw new ArgumentException("A marca do carro " +
                                                "deve ter mais de 2 linhas.");
                }
                else if (carroNovoVendido.Modelo.Length <= 2)
                {
                    throw new ArgumentException("O modelo do carro " +
                                                "deve ter mais de 2 linhas.");
                }
                else if (carroNovoVendido.Ano < 1900)
                {
                    throw new ArgumentException("O ano de fabricação " +
                                                "do carro deve ser" +
                                                "a partir do século XX.");
                }
                else if (carroNovoVendido.Preco <= 0)
                {
                    throw new ArgumentException("O preço de venda não pode" +
                                                " ser menor ou igual a zero.");
                }

                CarroVendido carroOriginalVendido = GetCarroVendido(id);
                _carroVendidoRepository.UpdateVendido(carroNovoVendido, 
                                                      carroOriginalVendido);
                Console.WriteLine("Registro de venda atualizado com sucesso!");
            }

            else
            {
                Console.WriteLine("O ID inserido não corresponde " +
                                  "a nenhum registro de carro vendido.");
            }
        }

        public List<Carro> List()
        {
            return _carroRepository.List();
        }

        public List<CarroVendido> ListVenda()
        {
            return _carroVendidoRepository.ListVenda();
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