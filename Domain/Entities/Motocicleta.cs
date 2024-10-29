using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDFinal.Domain.Entities
{
    public class Motocicleta : Veiculo
    {
        public bool BemCuidado { get; set; }
        public int Kilometragem { get; set; }
    }
}
