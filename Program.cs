using CRUDFinal.Controller;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CRUDFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiceCollection services = new ServiceCollection();
            Startup.DependencyInjection(services);
            var serviceProvider = services.BuildServiceProvider();
            var carroController = serviceProvider.GetRequiredService<CarroController>();
            var motocicletaController = serviceProvider.GetRequiredService<MotocicletaController>();

            bool controle = true;
            while (controle)
            {
                Console.WriteLine("Bem vindo ao Sistema de Venda de Automóveis!\n\n" +
                  "Selecione o dígito da operação a ser realizada:\n\n" +
                  "1 - Adicionar veículo;\n2 - Vender veículo;\n" +
                  "3 - Alterar informações de veículos;\n" +
                  "4 - Devolver veículo;\n" +
                  "5 - Listar veículos;\n" +
                  "6 - Sair.");

                if (Enum.TryParse<Menu>(Console.ReadLine(), true, out Menu menu))
                {
                    switch (menu)
                    {
                        case Menu.Add:
                            Add(carroController, motocicletaController);
                            break;

                        case Menu.Venda:
                            Venda(carroController, motocicletaController);
                            break;

                        case Menu.Update:
                            Update(carroController, motocicletaController);
                            break;

                        case Menu.Devolucao:
                            Devolucao(carroController, motocicletaController);
                            break;

                        case Menu.List:
                            List(carroController, motocicletaController);
                            break;

                        default:
                            Console.Clear();
                            Console.WriteLine("Obrigado por utilizar nosso sistema de Venda de Automóveis! |");
                            Console.WriteLine(new string('-', 61));
                            Environment.Exit(0);
                            break;
                    }
                }
            }
        }

        public static void Add(CarroController carroController, MotocicletaController motocicletaController)
        {
            Console.Clear();
            bool loopAdd = true;
            while (loopAdd)
            {
                Console.WriteLine("Digite, linha a linha, a marca, modelo e ano de fabricação do veículo:");
                string marca = Console.ReadLine();
                string modelo = Console.ReadLine();
                int ano = int.Parse(Console.ReadLine());

                Console.Clear();

                Console.WriteLine("Informe o dígito do tipo de veículo a ser adicionado:\n\n" +
                                  "1 - Carro;\n" +
                                  "2 - Motocicleta.");
                if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo))
                {
                    switch (tipo)
                    {
                        case TipoAutomovel.Carro:
                            Console.Clear();
                            Console.WriteLine("O câmbio do carro é automático?\n\n" +
                                              "1 - Sim;\n" +
                                              "2 - Não.");
                            if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao automatico))
                            {
                                Console.Clear();
                                Console.WriteLine("O carro está em bom estado?\n\n" +
                                                  "1 - Sim;\n" +
                                                  "2 - Não.");
                                if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                {
                                    Console.Clear();
                                    Console.WriteLine("Informe a kilometragem do carro:");
                                    if (int.TryParse(Console.ReadLine(), out int km))
                                    {
                                        carroController.Add(marca, modelo, ano, tipo, automatico, bemCuidado, km);
                                        Console.Clear();
                                        loopAdd = false;
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Resposta inválida. |");
                                        Console.WriteLine(new string('-', 20));
                                        Console.WriteLine("");
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Resposta inválida. |");
                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine("");
                            }

                            break;
                        case TipoAutomovel.Motocicleta:
                            Console.WriteLine("A motocicleta está em bom estado?" +
                                              "1 - Sim;\n" +
                                              "2 - Não.");

                            if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado2))
                            {
                                Console.WriteLine("Informe a kilometragem da motocicleta:");
                                if (int.TryParse(Console.ReadLine(), out int kilometragem))
                                {
                                    motocicletaController.Add(marca, modelo, ano, tipo, bemCuidado2, kilometragem);
                                    Console.Clear();
                                    loopAdd = false;

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Resposta inválida. |");
                                Console.WriteLine(new string('-', 20));
                                Console.WriteLine("");
                            }

                            break;
                    }
                }
            }
        }
        public static void Venda(CarroController carroController, MotocicletaController motocicletaController)
        {
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
                            $"{carro.ID} - {carro.Modelo} da marca {carro.Marca}, " +
                            $"fabricado em {carro.Ano} com kilometragem de {carro.Kilometragem}.\n" +
                            $"Automático - {carro.Automatico},\n" +
                            $"Bem cuidado - {carro.BemCuidado}."));

                        if (int.TryParse(Console.ReadLine(), out int id))
                        {
                            if (carroController.CheckCarro(id, false))
                            {
                                Console.WriteLine("Digite a data em que foi realizada a venda:");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                {
                                    Console.WriteLine("Digite o preço cobrado pelo carro:");
                                    if (int.TryParse(Console.ReadLine(), out int preco))
                                    {
                                        carroController.Venda(id, data, preco);

                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Resposta inválida. |");
                                        Console.WriteLine(new string('-', 20));
                                        Console.WriteLine("");
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }

                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
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
                                Console.WriteLine("Digite a data em que foi realizada a venda:");
                                if (DateTime.TryParse(Console.ReadLine(), out DateTime data))
                                {
                                    Console.WriteLine("Digite o preço cobrado pela motocicleta:");
                                    if (int.TryParse(Console.ReadLine(), out int preco))
                                    {
                                        motocicletaController.Venda(id, data, preco);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Resposta inválida. |");
                                        Console.WriteLine(new string('-', 20));
                                        Console.WriteLine("");
                                    }

                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }

                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("O ID inserido não corresponde a nenhuma motocicleta. |");
                                Console.WriteLine(new string('-', 50));
                                Console.WriteLine("");
                            }

                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
                        }

                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Resposta inválida. |");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("");
                }

            }
        }
        public static void Update(CarroController carroController, MotocicletaController motocicletaController)
        {
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
                                      "1 - A venda;\n" +
                                      "2 - Vendido.");

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
                                    $"fabricado em {carro.Ano} com kilometragem de {carro.Kilometragem}." +
                                    $"Automático - {carro.Automatico}," +
                                    $"Bem cuidado - {carro.BemCuidado};\n"));

                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    if (carroController.CheckCarro(id, false))
                                    {
                                        Carro carro = carroController.GetCarro(id);
                                        bool loopUpdate2 = true;
                                        while (loopUpdate2)
                                        {
                                            Console.WriteLine($"{carro.Modelo} da marca {carro.Marca}," +
                                                              $"fabricado em {carro.Ano} " +
                                                              $"com kilometragem de {carro.Kilometragem}." +
                                                              $"Automático - { carro.Automatico},\n" +
                                                              $"Bem cuidado - {carro.BemCuidado}.");

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
                                                string marcaNew = null;
                                                string modeloNew = null;
                                                int anoNew = 0;
                                                int kmNew = 0;
                                                Opcao bemCuidadoNew = Opcao.NA;
                                                Opcao automaticoNew = Opcao.NA;

                                                switch (parametro)
                                                {
                                                    case OpcaoUpdate.Marca:
                                                        Console.WriteLine("Informe a nova marca do carro:");
                                                        marcaNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Modelo:
                                                        Console.WriteLine("Informe o novo modelo do carro:");
                                                        modeloNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Ano:
                                                        Console.WriteLine("Informe o novo ano de fabricação do carro:");
                                                        anoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.Kilometragem:
                                                        Console.WriteLine("Informe a nova kilometragem do carro:");
                                                        kmNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.BemCuidado:
                                                        Console.WriteLine("O carro está em bom estado?\n\n" +
                                                                          "1 - Sim;\n" +
                                                                          "2 - Não.");
                                                        if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                                        {
                                                            bemCuidadoNew = bemCuidado;
                                                        }
                                                        break;

                                                    case OpcaoUpdate.Automatico:
                                                        Console.WriteLine("O carro é automático?\n\n" +
                                                                          "1 - Sim;\n" +
                                                                          "2 - Não.");
                                                        if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao automatico))
                                                        {
                                                            automaticoNew = automatico;
                                                        }
                                                        break;

                                                    case OpcaoUpdate.Fim:
                                                        loopUpdate2 = false;
                                                        break;

                                                }

                                                carroController.Update(id, marcaNew, modeloNew, anoNew,
                                                                       automaticoNew, bemCuidadoNew, kmNew);
                                                loopUpdate = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("O ID inserido não corresponde a nenhum carro. |");
                                        Console.WriteLine(new string('-', 50));
                                        Console.WriteLine("");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                var motos = motocicletaController.List();
                                Console.WriteLine("Digite o dígito da motocicleta a ser atualizado:\n\n");
                                motos.ForEach(moto => Console.WriteLine(
                                    $"{moto.ID} - {moto.Modelo} da marca {moto.Marca}," +
                                    $"fabricada em {moto.Ano} com kilometragem de {moto.Kilometragem}." +
                                    $"Bem cuidada - {moto.BemCuidado};\n"));

                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    if (motocicletaController.CheckMotocicleta(id, false))
                                    {
                                        Motocicleta moto = motocicletaController.GetMotocicleta(id);
                                        bool loopUpdate2 = true;
                                        while (loopUpdate2)
                                        {
                                            Console.WriteLine($"{moto.Modelo} da marca {moto.Marca}," +
                                                              $"fabricado em {moto.Ano} " +
                                                              $"com kilometragem de {moto.Kilometragem}." +
                                                              $"Bem cuidada - {moto.BemCuidado};\n");

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
                                                string marcaNew = null;
                                                string modeloNew = null;
                                                int anoNew = 0;
                                                int kmNew = 0;
                                                Opcao bemCuidadoNew = Opcao.NA;

                                                switch (parametro)
                                                {
                                                    case OpcaoUpdate.Marca:
                                                        Console.WriteLine("Informe a nova marca da motocicleta:");
                                                        marcaNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Modelo:
                                                        Console.WriteLine("Informe o novo modelo da motocicleta:");
                                                        modeloNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Ano:
                                                        Console.WriteLine("Informe o novo ano de fabricação da motocicleta:");
                                                        anoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.Kilometragem:
                                                        Console.WriteLine("Informe a nova kilometragem da motocicleta:");
                                                        kmNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.BemCuidado:
                                                        Console.WriteLine("A motocicleta está em bom estado?\n\n" +
                                                                          "1 - Sim;\n" +
                                                                          "2 - Não.");
                                                        if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                                        {
                                                            bemCuidadoNew = bemCuidado;
                                                        }
                                                        break;

                                                    case OpcaoUpdate.Fim:
                                                        loopUpdate2 = false;
                                                        break;

                                                }
                                                motocicletaController.Update(id, marcaNew, modeloNew, anoNew, 
                                                                             bemCuidadoNew, kmNew);
                                                loopUpdate = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (tipo == TipoAutomovel.Carro)
                            {
                                var carrosVendidos = carroController.ListVenda();
                                Console.WriteLine("Digite o dígito do carro a ser atualizado:\n\n");
                                carrosVendidos.ForEach(cv => Console.WriteLine(
                                    $"{cv.ID} - {cv.Modelo} da marca {cv.Marca}," +
                                    $" fabricado em {cv.Ano}. Foi vendido em {cv.DataVenda} por {cv.Preco};\n"));

                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    if (carroController.CheckCarro(id, false))
                                    {
                                        CarroVendido carroVendido = carroController.GetCarroVendido(id);
                                        bool loopUpdate2 = true;
                                        while (loopUpdate2)
                                        {
                                            Console.WriteLine($"{carroVendido.Modelo} da marca {carroVendido.Marca}, " +
                                                              $"fabricado em {carroVendido.Ano}. Foi vendido em " +
                                                              $"{carroVendido.DataVenda} por {carroVendido.Preco};");

                                            Console.WriteLine(new string('-', 50));

                                            Console.WriteLine($"Informe a numeração do parâmetro " +
                                                              $"que deseja alterar:\n\n" +
                                                              $"1 - Marca;\n" +
                                                              $"2 - Modelo;\n" +
                                                              $"3 - Ano;\n" +
                                                              $"7 - Data de venda;\n" +
                                                              $"8 - Preço de venda;\n " +
                                                              $"9 - Fim.");

                                            if (Enum.TryParse<OpcaoUpdate>(Console.ReadLine(),
                                                true, out OpcaoUpdate parametro))
                                            {
                                                string marcaNew = null;
                                                string modeloNew = null;
                                                int anoNew = 0;
                                                DateTime dataNew = DateTime.MinValue;
                                                int precoNew = 0;

                                                switch (parametro)
                                                {
                                                    case OpcaoUpdate.Marca:
                                                        Console.WriteLine("Informe a nova marca do carro:");
                                                        marcaNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Modelo:
                                                        Console.WriteLine("Informe o novo modelo do carro:");
                                                        modeloNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Ano:
                                                        Console.WriteLine("Informe o novo ano de fabricação do carro:");
                                                        anoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.DataVenda:
                                                        Console.WriteLine("Informe a nova data de venda do carro:");
                                                        if (DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", null, 
                                                            System.Globalization.DateTimeStyles.None, out DateTime data))
                                                        {
                                                            dataNew = data;
                                                        }
                                                        break;

                                                    case OpcaoUpdate.Preco:
                                                        Console.WriteLine("Informe o novo preço de venda:");
                                                        precoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.Fim:
                                                        loopUpdate2 = false;
                                                        break;

                                                }
                                                carroController.UpdateVendido(id, marcaNew, modeloNew, anoNew, 
                                                                              dataNew, precoNew);
                                                loopUpdate = false;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("O ID inserido não corresponde a nenhum carro. |");
                                        Console.WriteLine(new string('-', 50));
                                        Console.WriteLine("");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine(""); ;
                                }
                            }
                            else
                            {
                                var motosVendidas = motocicletaController.ListVenda();
                                Console.WriteLine("Digite o dígito da motocicleta a ser atualizada:\n\n");
                                motosVendidas.ForEach(mv => Console.WriteLine(
                                    $"{mv.ID} - {mv.Modelo} da marca {mv.Marca}," +
                                    $" fabricado em {mv.Ano}. Foi vendida em {mv.DataVenda} por {mv.Preco};\n"));

                                if (int.TryParse(Console.ReadLine(), out int id))
                                {
                                    if (motocicletaController.CheckMotocicleta(id, false))
                                    {
                                        MotocicletaVendida motoVendida = motocicletaController.GetMotocicletaVendida(id);
                                        bool loopUpdate2 = true;
                                        while (loopUpdate2)
                                        {
                                            Console.WriteLine($"{motoVendida.Modelo} da marca {motoVendida.Marca}, " +
                                                              $"fabricado em {motoVendida.Ano}. Foi vendido em " +
                                                              $"{motoVendida.DataVenda} por {motoVendida.Preco};");

                                            Console.WriteLine(new string('-', 50));

                                            Console.WriteLine($"Informe a numeração do parâmetro " +
                                                              $"que deseja alterar:\n\n" +
                                                              $"1 - Marca;\n" +
                                                              $"2 - Modelo;\n" +
                                                              $"3 - Ano;\n" +
                                                              $"7 - Data de venda;\n" +
                                                              $"8 - Preço de venda;\n " +
                                                              $"9 - Fim.");

                                            if (Enum.TryParse<OpcaoUpdate>(Console.ReadLine(),
                                                true, out OpcaoUpdate parametro))
                                            {
                                                string marcaNew = null;
                                                string modeloNew = null;
                                                int anoNew = 0;
                                                DateTime dataNew = DateTime.MinValue;
                                                int precoNew = 0;

                                                switch (parametro)
                                                {
                                                    case OpcaoUpdate.Marca:
                                                        Console.WriteLine("Informe a nova marca da motocicleta:");
                                                        marcaNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Modelo:
                                                        Console.WriteLine("Informe o novo modelo da motocicleta:");
                                                        modeloNew = Console.ReadLine();
                                                        break;

                                                    case OpcaoUpdate.Ano:
                                                        Console.WriteLine("Informe o novo ano de fabricação da motocicleta:");
                                                        anoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.DataVenda:
                                                        Console.WriteLine("Informe a nova data de venda da motocicleta:");
                                                        if (DateTime.TryParseExact(Console.ReadLine(), "ddMMyyyy", null,
                                                            System.Globalization.DateTimeStyles.None, out DateTime data))
                                                        {
                                                            dataNew = data;
                                                        }
                                                        break;

                                                    case OpcaoUpdate.Preco:
                                                        Console.WriteLine("Informe o novo preço de venda:");
                                                        precoNew = int.Parse(Console.ReadLine());
                                                        break;

                                                    case OpcaoUpdate.Fim:
                                                        loopUpdate2 = false;
                                                        break;

                                                }
                                                motocicletaController.UpdateVendida(id, marcaNew, modeloNew, anoNew, 
                                                                             dataNew, precoNew);
                                                loopUpdate = false;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            } 
        }

        public static void Devolucao(CarroController carroController, MotocicletaController motocicletaController)
        {
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
                                Console.WriteLine("O câmbio do carro é automático?\n\n" +
                                                  "1 - Sim;\n" +
                                                  "2 - Não.");
                                if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao automatico))
                                {
                                    Console.WriteLine("O carro está em bom estado?\n\n" +
                                                  "1 - Sim;\n" +
                                                  "2 - Não.");
                                    if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                    {
                                        Console.WriteLine("Informe a kilometragem do carro:");
                                        int kilometragem = int.Parse(Console.ReadLine());
                                        carroController.Devolucao(id, automatico, bemCuidado, kilometragem);
                                    }
                                    else
                                    {
                                        Console.Clear();
                                        Console.WriteLine("Resposta inválida. |");
                                        Console.WriteLine(new string('-', 20));
                                        Console.WriteLine("");
                                    }
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
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
                                Console.WriteLine("A motocicleta está em bom estado?\n\n" +
                                                  "1 - Sim;\n" +
                                                  "2 - Não.");
                                if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                {
                                    Console.WriteLine("Informe a kilometragem da motocicleta:");
                                    int kilometragem = int.Parse(Console.ReadLine());
                                    motocicletaController.Devolucao(id, bemCuidado, kilometragem);
                                }
                                else
                                {
                                    Console.Clear();
                                    Console.WriteLine("Resposta inválida. |");
                                    Console.WriteLine(new string('-', 20));
                                    Console.WriteLine("");
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("O ID inserido não corresponde a nenhuma motocicleta. |");
                                Console.WriteLine(new string('-', 50));
                                Console.WriteLine("");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Resposta inválida. |");
                            Console.WriteLine(new string('-', 20));
                            Console.WriteLine("");
                        }
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Resposta inválida. |");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("");
                }
            }
        }
        public static void List(CarroController carroController, MotocicletaController motocicletaController)
        {
            Console.WriteLine("Digite o dígito do tipo de lista de veículos que deseja visualizar:\n\n" +
                              "1 - Carro;\n" +
                              "2 - Motocicleta.");

            if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo)
                && tipo != TipoAutomovel.NA)
            {
                Console.WriteLine("A lista que deseja visualizar é de veículos vendidos ou a venda?\n\n" +
                                  "1 - A venda;\n" +
                                  "2 - Vendidos.");

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
                        ListVenda(carroController, motocicletaController, tipo);
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Resposta inválida. |");
                    Console.WriteLine(new string('-', 20));
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Resposta inválida. |");
                Console.WriteLine(new string('-', 20));
                Console.WriteLine("");
            }
        }
        public static void ListVenda(CarroController carroController, MotocicletaController motoController, 
                                     TipoAutomovel tipo)
        {
            if (tipo == TipoAutomovel.Carro)
            {
                var carrosVendidos = carroController.ListVenda();

                if (carrosVendidos.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Não existem registros de carros vendidos! |");
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("");
                }
                else
                {
                    carrosVendidos.ForEach(cv => Console.WriteLine(
                        $"{cv.ID} - {cv.Modelo} da marca {cv.Marca}," +
                        $" fabricado em {cv.Ano}. Foi vendido em {cv.DataVenda} por {cv.Preco};\n"));

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
            else
            {
                var motosVendidas = motoController.ListVenda();
                
                if (motosVendidas.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Não existem registros de motocicletas vendidas!");
                    Console.WriteLine(new string('-', 50));
                    Console.WriteLine("");
                }
                else
                {
                    motosVendidas.ForEach(mv => Console.WriteLine(
                        $"{mv.ID} - {mv.Modelo} da marca {mv.Marca}," +
                        $" fabricado em {mv.Ano}. Foi vendido em {mv.DataVenda} por {mv.Preco};\n"));

                    Console.WriteLine("Pressione qualquer tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}