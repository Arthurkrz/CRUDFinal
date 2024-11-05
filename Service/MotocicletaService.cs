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

        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
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
        public void Venda(Motocicleta moto, DateTime dataVenda, int preco)
        {
            _motocicletaRepository.DeleteMoto(moto.ID);
            moto = new MotocicletaVendida()
            {
                DataVenda = dataVenda,
                Preco = preco
            };
            _motocicletaRepository.AddVendido(moto);
        }
        public void Devolucao(MotocicletaVendida mv)
        {
            _motocicletaRepository.Add(DownCast(mv));
            _motocicletaRepository.DeleteMotoVendida(mv.ID);
        }
        public Motocicleta GetMotocicleta(int id, bool vendida)
        {
            if (vendida == true)
            {
                return _motocicletaRepository.GetMotocicletaVendida(id);
            }
            else
            {
                return _motocicletaRepository.GetMotocicleta(id);
            }
        }
        public bool CheckMotocicleta(int id, bool vendida)
        {
            if (vendida == true)
            {
                return _motocicletaRepository.CheckMotocicletaVendida(id) != null;
            }
            else
            {
                return _motocicletaRepository.CheckMotocicleta(id) != null;
            }
        }
        public void Update(Motocicleta moto, Motocicleta m, bool vendida)
        {
            if (vendida == true)
            {
                _motocicletaRepository.UpdateVendida(moto, m);
            }
            else
            {
                _motocicletaRepository.Update(moto, m);
            }
        }
        public List<Motocicleta> List()
        {
            return _motocicletaRepository.List();
        }
        public List<Motocicleta> ListVenda()
        {
            return _motocicletaRepository.ListVenda();
        }
        public Motocicleta DownCast(Motocicleta motoVendida)
        {
            Motocicleta motocicleta = new Motocicleta
            {
                Marca = motoVendida.Marca,
                Modelo = motoVendida.Modelo,
                Ano = motoVendida.Ano,
                Tipo = motoVendida.Tipo,
                BemCuidado = motoVendida.BemCuidado,
                Kilometragem = motoVendida.Kilometragem
            };
            return motocicleta;
        }
    }
}