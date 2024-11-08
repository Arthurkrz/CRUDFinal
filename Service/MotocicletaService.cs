using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Service
{
    public class MotocicletaService : IMotocicletaService
    {
        private readonly IMotocicletaRepository _motocicletaRepository;

        public MotocicletaService(IMotocicletaRepository motocicletaRepository)
        {
            _motocicletaRepository = motocicletaRepository;
        }

        public void Add(Motocicleta moto)
        {
            // logic
            _motocicletaRepository.Add(moto);
        }

        public void Venda(MotocicletaVendida motoVendida)
        {
            // logic
            _motocicletaRepository.AddVendida(motoVendida);
            _motocicletaRepository.DeleteMotocicleta(motoVendida.ID);
        }

        public void Devolucao(Motocicleta moto)
        {
            // logic
            _motocicletaRepository.Add(moto);
            _motocicletaRepository.DeleteMotocicletaVendida(moto.ID);
        }

        public Motocicleta GetMotocicleta(int id)
        {
            return _motocicletaRepository.GetMotocicleta(id);
        }

        public MotocicletaVendida GetMotocicletaVendida(int id)
        {
            return _motocicletaRepository.GetMotocicletaVendida(id);
        }

        public bool CheckMotocicleta(int id, bool vendida)
        {
            if (vendida == true)
            {
                return _motocicletaRepository.CheckMotocicletaVendida(id) != false;
            }

            else
            {
                return _motocicletaRepository.CheckMotocicleta(id) != false;
            }

        }
        public void Update(Motocicleta motoNova, int id)
        {
            if (CheckMotocicleta(id, false))
            {
                Motocicleta motoOriginal = GetMotocicleta(id);
                _motocicletaRepository.Update(motoNova, motoOriginal);
                Console.WriteLine("Motocicleta atualizada com sucesso!");
            }
            else
            {
                Console.WriteLine("O ID inserido não corresponde " +
                    "a nenhuma motocicleta");
            }
        }

        public void UpdateVendida(Motocicleta motoNovaVendida, int id)
        {
            if (CheckMotocicleta(id, true))
            {
                Motocicleta motoOriginalVendida = GetMotocicletaVendida(id);
                _motocicletaRepository.UpdateVendida(motoNovaVendida,
                                                     motoOriginalVendida);
            }
            else
            {
                Console.WriteLine("O ID inserido não corresponde " +
                                  "a nenhum registro de motocicleta vendida.");
            }
        }
        public List<Motocicleta> List()
        {
            return _motocicletaRepository.List();
        }

        public List<MotocicletaVendida> ListVenda()
        {
            return _motocicletaRepository.ListVenda();
        }

        public MotocicletaVendida DownCast(Motocicleta moto, DateTime dataVenda, 
                                           int preco)
        {
            MotocicletaVendida motocicletaVendida = new MotocicletaVendida
            {
                Marca = moto.Marca,
                Modelo = moto.Modelo,
                Ano = moto.Ano,
                Tipo = moto.Tipo,
                BemCuidado = moto.BemCuidado,
                Kilometragem = moto.Kilometragem
            };

            return motocicletaVendida;
        }

        public Motocicleta UpCast(MotocicletaVendida motoVendida, 
                                  Opcao bemCuidada, int km)
        {
            Motocicleta moto = new Motocicleta
            {
                Marca = motoVendida.Marca,
                Modelo = motoVendida.Modelo,
                Ano = motoVendida.Ano,
                Tipo = motoVendida.Tipo,
                BemCuidado = bemCuidada,
                Kilometragem = km
            };

            return moto;
        }
    }
}