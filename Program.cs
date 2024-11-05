using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Controller;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Collections.Generic;

namespace CRUDFinal
{
    class Program
    {
        private readonly ServiceProvider _serviceProvider;
        public Program(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        static void Main(string[] args)
        {
            var serviceProvider = Startup.DependencyInjection();
            var program = new Program(serviceProvider);

            Console.WriteLine("Bem vindo ao Sistema de Venda de Automóveis!\n\n" +
                              "Selecione o dígito da operação a ser realizada:\n\n" +
                              "1 - Adicionar veículo;\n2 - Vender veículo;\n" +
                              "3 - Alterar informações de veículo;\n" +
                              "4 - Devolver veículo;\n" +
                              "5 - Listar veículos;\n" +
                              "6 - Sair.");
            if (Enum.TryParse<Menu>(Console.ReadLine(), true, out Menu menu))
            {
                switch (menu)
                {
                    case Menu.Add:
                        program.Add();
                        break;
                    case Menu.Venda:
                        program.Venda();
                        break;
                    case Menu.Update:
                        program.Update();
                        break;
                    case Menu.Devolucao:
                        program.Devolucao();
                        break;
                    case Menu.List:
                        program.List();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nosso sistema de Biblioteca! |");
                        Console.WriteLine(new string('-', 55));
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public void Add()
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            Console.Clear();
            bool loopAdd = true;
            while (loopAdd)
            {
                Console.WriteLine("Digite, linha a linha, a marca, modelo e ano de fabricação do veículo:");
                string marca = Console.ReadLine();
                string modelo = Console.ReadLine();
                int ano = int.Parse(Console.ReadLine());
                Console.WriteLine("Informe o dígito do tipo de veículo a ser adicionado:\n\n" +
                                  "1 - Carro;" +
                                  "2 - Motocicleta.");
                if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo))
                {
                    switch (tipo)
                    {
                        case TipoAutomovel.Carro:
                            Console.WriteLine("O câmbio do carro é automático ('s'/'n')?");
                            if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao automatico))
                            {
                                Console.WriteLine("O carro está em bom estado ('s'/'n')?");
                                if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                {
                                    Console.WriteLine("Informe a kilometragem do carro:");
                                    int kilometragem = int.Parse(Console.ReadLine());
                                    if (carroController.Add(marca, modelo, ano, tipo, automatico, bemCuidado, kilometragem))
                                    {
                                        Console.WriteLine("Carro adicionado com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ocorreu um erro.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Resposta inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida.");
                            }
                            break;
                        case TipoAutomovel.Motocicleta:
                            Console.WriteLine("A motocicleta está em bom estado ('s'/'n')?");
                            if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado2))
                            {
                                Console.WriteLine("Informe a kilometragem da motocicleta:");
                                if (int.TryParse(Console.ReadLine(), out int kilometragem))
                                {
                                    if(motocicletaController.Add(marca, modelo, ano, tipo, bemCuidado2, kilometragem))
                                    {
                                        Console.WriteLine("Motocicleta adicionada com sucesso!");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ocorreu um erro.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Resposta inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Resposta inválida.");
                            }
                            break;
                    }
                }
            }
        }
        public void Venda()
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            Console.Clear();
            bool loopVenda = true;
            while (loopVenda)
            {
                Console.WriteLine("Digite o dígito do tipo de veículo a ser vendido:\n\n" +
                                  "1 - Carro;\n" +
                                  "2 - Motocicleta.");
                if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo)
                    && tipo != TipoAutomovel.NA)
                {
                    if (tipo == TipoAutomovel.Carro)
                    {
                        var carros = carroController.List();
                        carros.ForEach(carro => Console.WriteLine(
                            $"{carro.ID} - {carro.Modelo} da marca {carro.Marca}," +
                            $" fabricado em {carro.Ano} com kilometragem de {carro.Kilometragem};\n"));
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (carroController.CheckCarro(id, false))
                            {
                                Carro carro = carroController.GetCarro(id, false);
                                if (carroController.CheckCarro(id, false))
                                {
                                    Carro carro = carroController.GetCarro(id, false);
                                    Console.WriteLine("Digite a data em que foi realizada a venda:");
                                    if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                    {
                                        Console.WriteLine("Digite o preço cobrado pelo carro:");
                                        if (int.TryParse(Console.ReadLine(), out int preco))
                                        {
                                            carroController.Venda(carro, data, preco);
                                            Console.WriteLine("Motocicleta vendida com sucesso!");
                                        }
                                        else
                                        {
                                            Console.WriteLine("Resposta inválida.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Resposta inválida.");
                                    }
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Resposta inválida.");
                        }
                    }
                    else
                    {
                        var motos = motocicletaController.List();
                        Console.WriteLine("Digite o dígito da motocicleta a ser vendida:\n\n");
                        motos.ForEach(moto => Console.WriteLine(
                            $"{moto.ID} - {moto.Modelo} da marca {moto.Marca}," +
                            $" fabricado em {moto.Ano} com kilometragem de {moto.Kilometragem};\n"));
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (motocicletaController.CheckMotocicleta(id, false))
                            {
                                Motocicleta motocicleta = motocicletaController.GetMotocicleta(id, false);
                                Console.WriteLine("Digite a data em que foi realizada a venda:");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                {
                                    Console.WriteLine("Digite o preço cobrado pela motocicleta:");
                                    if (int.TryParse(Console.ReadLine(), out int preco))
                                    {
                                        motocicletaController.Venda(motocicleta, data, preco);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Resposta inválida.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Resposta inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("O ID inserido não corresponde a nenhuma motocicleta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Resposta inválida.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Resposta inválida.");
                }
            }
        }
        public void Update()
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            Console.Clear();
            bool loopUpdate = true;
            while (loopUpdate)
            {
                Console.WriteLine("Digite o dígito do tipo de veículo a ser atualizado:\n\n" +
                                  "1 - Carro;\n" +
                                  "2 - Motocicleta.");
                if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo)
                    && tipo != TipoAutomovel.NA)
                {
                    Console.WriteLine("O registro que deseja atualizar é de um veículo vendido ou a venda?\n\n" +
                                      "1 - A venda;\n2 - Vendido.");
                    if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= 2)
                    {
                        if (input == 1)
                        {
                            if (tipo == TipoAutomovel.Carro)
                            {
                                var carros = carroController.List();
                                Console.WriteLine("Digite o dígito do carro a ser atualizado:\n\n");
                                carros.ForEach(carro => Console.WriteLine(
                                    $"{carro.ID} - {carro.Modelo} da marca {carro.Marca}," +
                                    $"fabricado em {carro.Ano} com kilometragem de {carro.Kilometragem};\n"));
                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    if (carroController.CheckCarro(id, false))
                                    {
                                        Carro carro = carroController.GetCarro(id, false);
                                        Carro c = new Carro()
                                        {
                                            Marca = carro.Marca,
                                            Modelo = carro.Modelo,
                                            Ano = carro.Ano,
                                            Tipo = carro.Tipo,
                                            Kilometragem = carro.Kilometragem
                                        };
                                        bool loopUpdate2 = true;
                                        while (loopUpdate2)
                                        {
                                            Console.WriteLine($"{carro.Modelo} da marca {carro.Marca}," +
                                                              $"fabricado em {carro.Ano} " +
                                                              $"com kilometragem de {carro.Kilometragem}.");
                                            Console.WriteLine(new string('-', 50));
                                            Console.WriteLine($"Informe a numeração do parâmetro " +
                                                              $"que deseja alterar:\n\n" +
                                                              $"1 - Marca;\n" +
                                                              $"2 - Modelo;\n" +
                                                              $"3 - Ano;\n" +
                                                              $"4 - Kilometragem;" +
                                                              $"5 - Fim.\n");
                                            if (Enum.TryParse<OpcaoUpdate>(Console.ReadLine(), 
                                                true, out OpcaoUpdate parametro))
                                            {
                                                switch (parametro)
                                                {
                                                    case OpcaoUpdate.Marca:
                                                        Console.WriteLine("Informe a nova marca do carro:");
                                                        string marcaNew = Console.ReadLine();
                                                        c.Marca = marcaNew;
                                                        break;
                                                    case OpcaoUpdate.Modelo:
                                                        Console.WriteLine("Informe o novo modelo do carro:");
                                                        string modeloNew = Console.ReadLine();
                                                        c.Modelo = modeloNew;
                                                        break;
                                                    case OpcaoUpdate.Ano:
                                                        Console.WriteLine("Informe o novo ano de fabricação do carro:");
                                                        int anoNew = int.Parse(Console.ReadLine());
                                                        c.Ano = anoNew;
                                                        break;
                                                    case OpcaoUpdate.Kilometragem:
                                                        Console.WriteLine("Informe a nova kilometragem do carro:");
                                                        int kmNew = int.Parse(Console.ReadLine());
                                                        c.Kilometragem = kmNew;
                                                        break;
                                                    case OpcaoUpdate.Fim:
                                                        loopUpdate2 = false;
                                                        break;
                                                }
                                                carroController.Update(carro, c, false);
                                                Console.WriteLine("Veículo atualizado com sucesso!");
                                                loopUpdate = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("O ID inserido não corresponde a nenhum carro.");
                                    }
                                }
                                else
                                {

                                }
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (tipo == TipoAutomovel.Carro)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
        public void Devolucao()
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            Console.Clear();
            bool loopDevolucao = true;
            while (loopDevolucao)
            {
                Console.WriteLine("Digite o dígito do tipo de veículo a ser devolvido:\n\n" +
                                  "1 - Carro;\n" +
                                  "2 - Motocicleta.");
                if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo)
                    && tipo != TipoAutomovel.NA)
                {
                    if (tipo == TipoAutomovel.Carro)
                    {
                        var carrosVendidos = carroController.ListVenda();
                        carrosVendidos.ForEach(cv => Console.WriteLine(
                            $"{cv.ID} - {cv.Modelo} da marca {cv.Marca}," +
                            $" fabricado em {cv.Ano}. Foi vendido em {cv.DataVenda} por {cv.Preco};\n"));
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (carroController.CheckCarro(id, true))
                            {
                                Carro carro = carroController.GetCarro(id, true);
                                Console.WriteLine("Digite a data em que foi realizada a venda:");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                {
                                    Console.WriteLine("Digite o preço cobrado pelo carro:");
                                    if (int.TryParse(Console.ReadLine(), out int preco))
                                    {
                                        carroController.Devolucao(carro, data, preco);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Resposta inválida.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Resposta inválida.");
                                }

                            }
                        }
                        else
                        {
                            Console.WriteLine("Resposta inválida.");
                        }
                    }
                    else
                    {
                        var motosVendidas = motocicletaController.ListVenda();
                        Console.WriteLine("Digite o dígito da motocicleta a ser devolvida:\n\n");
                        motosVendidas.ForEach(mv => Console.WriteLine(
                            $"{mv.ID} - {mv.Modelo} da marca {mv.Marca}," +
                            $" fabricado em {mv.Ano}. Foi vendido em {mv.DataVenda} por {mv.Preco};\n"));
                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (motocicletaController.CheckMotocicleta(id, true))
                            {
                                Motocicleta motocicletaVendida = motocicletaController.GetMotocicleta(id, true);

                                Console.WriteLine("Digite a data em que foi realizada a venda:");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                {
                                    Console.WriteLine("Digite o preço cobrado pela motocicleta:");
                                    if (int.TryParse(Console.ReadLine(), out int preco))
                                    {
                                        motocicletaController.Devolucao(motocicleta, data, preco);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Resposta inválida.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Resposta inválida.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("O ID inserido não corresponde a nenhuma motocicleta.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Resposta inválida.");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Resposta inválida.");
                }
            }
        }
        public void List()
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            Console.WriteLine("Digite o dígito do tipo de lista de veículos que deseja visualizar:\n\n" +
                              "1 - Carro;\n" +
                              "2 - Motocicleta.");
            if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo)
                && tipo != TipoAutomovel.NA)
            {
                Console.WriteLine("A lista que deseja visualizar é de veículos vendidos ou a venda?\n\n" +
                    "1 - A venda;\n2 - Vendidos.");
                if (int.TryParse(Console.ReadLine(), out int input) && input > 0 && input <= 2)
                {
                    if (input == 1)
                    {
                        if (tipo == TipoAutomovel.Carro)
                        {
                            var carros = carroController.List();
                            carros.ForEach(carro => Console.WriteLine(
                                $"{carro.ID} - {carro.Modelo} da marca {carro.Marca}," +
                                $" fabricado em {carro.Ano} com kilometragem de {carro.Kilometragem};\n"));
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                        else
                        {
                            var motos = motocicletaController.List();
                            motos.ForEach(moto => Console.WriteLine(
                                $"{moto.ID} - {moto.Modelo} da marca {moto.Marca}," +
                                $" fabricado em {moto.Ano} com kilometragem de {moto.Kilometragem};\n"));
                            Console.WriteLine("Pressione qualquer tecla para continuar...");
                            Console.ReadKey();
                        }
                    }
                    else
                    {
                        ListVenda(tipo);
                    }
                }
                else
                {
                    Console.WriteLine("Resposta inválida.");
                }
            }
            else
            {
                Console.WriteLine("Resposta inválida.");
            }
        }
        public void ListVenda(TipoAutomovel tipo)
        {
            var carroController = _serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = _serviceProvider.GetRequiredService<MotocicletaController>();
            if (tipo == TipoAutomovel.Carro)
            {
                var carrosVendidos = carroController.ListVenda();
                carrosVendidos.ForEach(cv => Console.WriteLine(
                    $"{cv.ID} - {cv.Modelo} da marca {cv.Marca}," +
                    $" fabricado em {cv.Ano}. Foi vendido em {cv.DataVenda} por {cv.Preco};\n"));
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
            else
            {
                var motosVendidas = motocicletaController.ListVenda();
                motosVendidas.ForEach(mv => Console.WriteLine(
                    $"{mv.ID} - {mv.Modelo} da marca {mv.Marca}," +
                    $" fabricado em {mv.Ano}. Foi vendido em {mv.DataVenda} por {mv.Preco};\n"));
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}

// TERMINAR LOGICA
// ADICIONAR ID ESTÁTICO DA LISTA
// CORRIGIR COM O GPT