using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Repository;

namespace CRUDFinal.Service
{
    public class MotocicletaService : IMotocicletaService
    {
        private MotocicletaRepository _motocicletaRepository;
        public void Add(string marca,
                        string modelo,
                        int ano,
                        TipoAutomovel tipo,
                        bool bemCuidado,
                        int kilometragem)
        {
            Motocicleta moto = new Motocicleta()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Tipo = tipo,
                BemCuidado = bemCuidado,
                Kilometragem = kilometragem
            };
            _motocicletaRepository.Add(moto);
        }
        public void Delete(int id)
        {
            _motocicletaRepository.Delete(id);
        }
        public void GetMotocicleta(int id)
        {
            _motocicletaRepository.GetMotocicleta(id);
        }
        public bool CheckMotocicleta(int id)
        {
            return _motocicletaRepository.GetMotocicleta(id) != null;
        }
        public void Update(Motocicleta moto,
                           string marca,
                           string modelo,
                           int ano,
                           TipoAutomovel tipo,
                           bool bemCuidado,
                           int kilometragem)
        {
            Motocicleta m = new Motocicleta()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                Tipo = tipo,
                BemCuidado = bemCuidado,
                Kilometragem = kilometragem
            };
            _motocicletaRepository.Update(moto, m);
        }
        public void List()
        {
            _motocicletaRepository.List();
        }
    }
}
