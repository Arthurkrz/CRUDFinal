using System;
using CRUDFinal.Domain.Entities;
using CRUDFinal.Domain.Enum;
using CRUDFinal.Controller;

namespace CRUDFinal
{
    class Program
    {
        static void Main(string[] args)
        {
            Startup.DependencyInjection();
            Console.WriteLine("Bem vindo ao Sistema de Venda de Automóveis!\n\n" +
                "Selecione o dígito da operação a ser realizada:\n\n" +
                "1 - Adicionar veículo;\n2 - Vender veículo;\n" + // 2 - downcast
                "3 - Alterar informações de veículo;\n" +
                "4 - Devolver veículo;\n" + // 4 - upcast
                "5 - Listar veículos;\n" +
                "6 - Sair.");
            if (Enum.TryParse<Menu>(Console.ReadLine(), true, out Menu menu))
            {
                switch (menu)
                {
                    case Menu.Adicionar:
                        Adicionar();
                        break;
                    case Menu.Vender:
                        Vender();
                        break;
                    case Menu.Update:
                        Update();
                        break;
                    case Menu.Devolver:
                        Devolver();
                        break;
                    case Menu.Listar:
                        Listar();
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Obrigado por utilizar nosso sistema de Biblioteca!|");
                        Console.WriteLine(new string('-', 54));
                        Environment.Exit(0);
                        break;
                }
            }
        }
        public static void Adicionar()
        {
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
                        "2 - Moto.");
                    if (Enum.TryParse<TipoAutomovel>(Console.ReadLine(), true, out TipoAutomovel tipo))
                    {
                        switch (tipo)
                        {
                            case TipoAutomovel.Carro:
                                Console.WriteLine("O câmbio do carro é automático ('s'/'n')?");
                                if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao automatico))
                                {
                                    Console.WriteLine("O veículo está em bom estado ('s'/'n')?");
                                    if (Enum.TryParse<Opcao>(Console.ReadLine(), true, out Opcao bemCuidado))
                                    {
                                        Console.WriteLine("Informe a kilometragem do veículo:");
                                        int kilometragem = int.Parse(Console.ReadLine());
                                        CarroController.Add(marca, modelo, ano, tipo, automatico, bemCuidado, kilometragem);
                                    }
                                    else
                                    {
                                    Console.WriteLine("Ocorreu um erro.");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ocorreu um erro.");
                                }
                                break;
                            case TipoAutomovel.Motocicleta:

                                break;
                        }
                    }
            }
        }
    }
}
if (CheckMotocicleta(id, vendida))
{
    Motocicleta moto = GetMotocicleta(id, vendida);
    _motocicletaRepository.Update(moto, m);
}
else
{
    Console.WriteLine("O ID inserido não" +
        " corresponde a nenhuma motocicleta.");
}