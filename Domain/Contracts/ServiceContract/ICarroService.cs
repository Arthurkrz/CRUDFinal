using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface ICarroService
    {
        public void Add(string marca, string modelo, int ano,
                        TipoAutomovel tipo, Opcao automatico,
                        Opcao bemCuidado, int kilometragem);
        public void Venda(int id);
        public void Update(Carro carro, string marca, string modelo, int ano,
                           TipoAutomovel tipo, Opcao automatico,
                           Opcao bemCuidado, int kilometragem);
        public void List();
        public void GetCarro(int id);
        public bool CheckCarro(int id);
    }
}