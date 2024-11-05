using CRUDFinal.Domain.Entities;
using CRUDFinal.Repository;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Domain.Contracts.RepositoryContract;

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
        public void Venda(int id)
        {
            _carroRepository.Venda(id);
        }
        public void GetCarro(int id)
        {
            _carroRepository.GetCarro(id);
        }
        public bool CheckCarro(int id)
        {
            return _carroRepository.GetCarro(id) != null;
        }
        public void Update(Carro carro, string marca, string modelo, int ano,
                           TipoAutomovel tipo, Opcao automatico,
                           Opcao bemCuidado, int kilometragem)
        {
            Carro c = new Carro()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Tipo = tipo,
                Automatico = automatico,
                BemCuidado = bemCuidado,
                Kilometragem = kilometragem
            };
            _carroRepository.Update(carro, c);
        }
        public void List()
        {
            _carroRepository.List();
        }
    }
}
