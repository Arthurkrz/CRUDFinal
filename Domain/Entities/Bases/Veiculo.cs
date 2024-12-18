using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Entities
{
    public class Veiculo
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public int Ano { get; set; }
        public TipoAutomovel Tipo { get; set; }
    }
}
