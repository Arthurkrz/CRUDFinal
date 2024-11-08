using CRUDFinal.Domain.Contracts.ServiceContract;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using System;
using System.Collections.Generic;

namespace CRUDFinal.Controller
{
    public class MotocicletaController
    {
        private readonly IMotocicletaService _motocicletaService;

        public MotocicletaController(IMotocicletaService motocicletaService)
        {
            _motocicletaService = motocicletaService;
        }

        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao bemCuidado,
                        int km)
        {
            if (Valid(marca, modelo, ano))
            {
                Motocicleta moto = new Motocicleta()
                {
                    Marca = marca,
                    Modelo = modelo,
                    Ano = ano,
                    Tipo = tipo,
                    BemCuidado = bemCuidado,
                    Kilometragem = km
                };

                _motocicletaService.Add(moto);
            }

        }

        public void Venda(int id, DateTime dataVenda, int preco)
        {
            var moto = GetMotocicleta(id);
            var motoVendida = DownCast(moto, dataVenda, preco);
            _motocicletaService.Venda(motoVendida);
        }

        public void Devolucao(int id, Opcao bemCuidado, int km)
        {
            var motoVendida = GetMotocicletaVendida(id);
            var moto = UpCast(motoVendida, bemCuidado, km);
            _motocicletaService.Devolucao(moto);
        }

        public void Update(int id, string marca, string modelo, 
                           int ano, Opcao bemCuidado, int km)
        {
            Motocicleta moto = new Motocicleta()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                BemCuidado = bemCuidado,
                Kilometragem = km
            };

            _motocicletaService.Update(moto, id);
        }

        public void UpdateVendida(int id, string marca, string modelo, int ano, 
                                  DateTime dataVenda, int preco)
        {
            MotocicletaVendida motoVendida = new MotocicletaVendida()
            {
                Marca = marca,
                Modelo = modelo,
                Ano = ano,
                DataVenda = dataVenda,
                Preco = preco
            };

            _motocicletaService.UpdateVendida(motoVendida, id);
        }

        public Motocicleta GetMotocicleta(int id)
        {
            return _motocicletaService.GetMotocicleta(id);
        }

        public MotocicletaVendida GetMotocicletaVendida(int id)
        {
            return _motocicletaService.GetMotocicletaVendida(id);
        }

        public bool CheckMotocicleta(int id, bool vendida)
        {
            return _motocicletaService.CheckMotocicleta(id, vendida) != false;
        }

        public List<Motocicleta> List()
        {
            return _motocicletaService.List();
        }

        public List<MotocicletaVendida> ListVenda()
        {
            return _motocicletaService.ListVenda();
        }

        public bool Valid(string marca, string modelo, int ano)
        {
            if (marca != null && modelo != null && ano > 0)
            {
                return true;
            }

            return false;
        }

        public MotocicletaVendida DownCast(Motocicleta moto, DateTime dataVenda, int preco)
        {
            return _motocicletaService.DownCast(moto, dataVenda, preco);
        }

        public Motocicleta UpCast(MotocicletaVendida motoVendida, 
                                  Opcao bemCuidada, int km)
        {
            return _motocicletaService.UpCast(motoVendida, bemCuidada, km);
        }

    }
}