using CRUDFinal.Domain.Entities;
using CRUDFinal.Repository;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Service
{
    public class CarroService : ICarroService
    {
        private CarroRepository _carroRepository;
        public void Add(string marca,
                        string modelo,
                        int ano,
                        TipoAutomovel tipo,
                        Opcao automatico,
                        Opcao bemCuidado,
                        int kilometragem)
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
        public void Delete(int id)
        {
            _carroRepository.Delete(id);
        }
        public void GetCarro(int id)
        {
            _carroRepository.GetCarro(id);
        }
        public bool CheckCarro(int id)
        {
            return _carroRepository.GetCarro(id) != null;
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
