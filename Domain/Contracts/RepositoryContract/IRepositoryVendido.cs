using CRUDFinal.Domain.Entities;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface IRepositoryVendido<T> where T : VeiculoVendido
    {
        void AddVendido(T entityVendida);
        void DeleteVendido(int id);
        bool CheckVendido(int id);
        T GetVendido(int id);
        void UpdateVendido(T entityVendidaNova, T entityVenididaOriginal);
        List<T> ListVenda();
    }
}
