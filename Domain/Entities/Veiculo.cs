using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Entities
{
    public abstract class Veiculo
    {
        private static int _idCounter = 1;
        private readonly int _id;
        public int ID
        {
            get
            {
                return _id;
            } 
        }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public TipoAutomovel Tipo { get; set; }
        protected Veiculo()
        {
            _id = _idCounter++;
        }
    }
}
