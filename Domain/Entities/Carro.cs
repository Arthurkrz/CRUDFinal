using System;
using System.Collections.Generic;
using System.Text;

namespace CRUDFinal.Domain.Entities
{
    public class Carro : Veiculo
    {
        public Carro(bool automatico, bool bemCuidado, int kilometragem)
        {
            Automatico = automatico;
            BemCuidado = bemCuidado;
            Kilometragem = kilometragem;
        }

        public bool Automatico { get; set; }
        public bool BemCuidado { get; set; }
        public int Kilometragem { get; set; }
    }
}
