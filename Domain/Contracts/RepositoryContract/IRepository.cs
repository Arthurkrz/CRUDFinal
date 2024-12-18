using CRUDFinal.Domain.Entities;
using System.Collections.Generic;

namespace CRUDFinal.Domain.Contracts.RepositoryContract
{
    public interface IRepository<T> where T : Veiculo
    {
        void Add(T entity);
        void Delete(int id);
        T Get(int id);
        bool Check(int id);
        void Update(T entityNova, T entityOriginal);
        List<T> List();
    }
}
