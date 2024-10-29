﻿using System;
using System.Collections.Generic;
using System.Text;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Contracts.RepositoryContract;
using CRUDFinal.Domain.Enum;

namespace CRUDFinal.Domain.Contracts.ServiceContract
{
    public interface IMotocicletaService
    {
        public void Add(string marca,
                        string modelo,
                        int ano,
                        TipoAutomovel tipo,
                        bool bemCuidado,
                        int kilometragem);
        public void Delete(int id);
        public void Update(Motocicleta moto,
                           string marca,
                           string modelo,
                           int ano,
                           TipoAutomovel tipo,
                           bool bemCuidado,
                           int kilometragem);
        public void List();
    }
}
