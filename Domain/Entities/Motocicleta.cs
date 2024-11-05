using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Entities
{
    public class Motocicleta : Veiculo
    {
        public Opcao BemCuidado { get; set; }
        public int Kilometragem { get; set; }
    }
}
