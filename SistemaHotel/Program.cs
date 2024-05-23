// See https://aka.ms/new-console-template for more information
using System.Collections;
using System.Text;
using SistemaHotel.Classes;
using Newtonsoft.Json;//declaramos que estamos usando o pacote baixado


Console.OutputEncoding = Encoding.UTF8;

int escolha = 1;
int numeroHospedes = 0;
int escolherSuite = 0;
List<Reserva> reservaLista = new List<Reserva>();
TratarErro tratarErro = new TratarErro();

do 
{
    Console.WriteLine("Bem vindo ao sistema de hospedagem Zampieri, o que você deseja fazer?\n1 - Reserva\t2 - Exibir informação de todo mundo\t3 - Sair ");
    escolha = tratarErro.metodoVerificarTipoDeDado();
    
    switch (escolha)
    {

    case 1: 

        
        Console.WriteLine("Quantas pessoas irão se hospedar?");
        numeroHospedes = tratarErro.metodoVerificarTipoDeDado();

        if (numeroHospedes > 10)
        {
            Console.WriteLine("Nenhuma suíte disponível para mais de 10 hóspedes.");
            Environment.Exit(0);
        }
        else if (numeroHospedes > 2 && numeroHospedes <= 5)
        {
            Console.WriteLine("Escolha um dos tipos de suíte abaixo:\n3 - Suíte King, capacidade: 10, valor Diária: 80R$"
                                                              + "\n2 - Suíte Presidencial, capacidade: 5, valor Diária: 50R$");
            escolherSuite = tratarErro.metodoVerificarTipoDeDado();                                    
        }
        else if (numeroHospedes > 0 && numeroHospedes <= 2)
        {
            Console.WriteLine("Escolha um dos tipos de suíte abaixo:\n1 - Suíte Comum, capacidade: 2, valor Diária: 30R$"
                                                              + "\n2 - Suíte Presidencial, capacidade: 5, valor Diária: 50R$"
                                                              + "\n3 - Suíte King, capacidade: 10, valor Diária: 80R$");
            escolherSuite = tratarErro.metodoVerificarTipoDeDado();                                    
        }
        else
        {
            Console.WriteLine("A única suíte disponível é:\n3 - Suíte King, capacidade: 10, valor Diária: 80R$");
            escolherSuite = 3;
        }

        List<Pessoa> hospedes = new List<Pessoa>();

        for(int i = 0; i < numeroHospedes; i++)
        {
            Pessoa p = new Pessoa();
            Console.WriteLine("Informe seu nome: ");
            p.Nome = Console.ReadLine();
            Console.WriteLine("Informe seu sobrenome: ");
            p.Sobrenome = Console.ReadLine();

            Pessoa pe = new Pessoa(nome: p.Nome, sobrenome: p.Sobrenome);
            hospedes.Add(pe);
        }

        
        if(escolherSuite == 1)
        {
            Suite suiteComum = new Suite(tipoSuite: "Comum", capacidade: 2, valorDiaria: 30);

            Console.WriteLine("Informe quantos dias você vai ficar");
            Reserva reserva = new Reserva(tratarErro.metodoVerificarTipoDeDado());

            reserva.CadastrarSuite(suiteComum);
            reserva.CadastrarHospedes(hospedes);
            reservaLista.Add(reserva);

            Console.WriteLine($"\nReserva Realizada com sucesso!\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");    

        }else if(escolherSuite == 2)
        {
            Suite suitePresidencial = new Suite(tipoSuite: "Presidencial", capacidade: 5, valorDiaria: 50);

            Console.WriteLine("Informe quantos dias você vai ficar");
            Reserva reserva = new Reserva(tratarErro.metodoVerificarTipoDeDado());

            reserva.CadastrarSuite(suitePresidencial);
            reserva.CadastrarHospedes(hospedes);
            reservaLista.Add(reserva);

            Console.WriteLine($"\nReserva Realizada com sucesso!\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");    

        }else if(escolherSuite == 3)
        {
            Suite suiteKing = new Suite(tipoSuite: "King", capacidade: 10, valorDiaria: 80);

            Console.WriteLine("Informe quantos dias você vai ficar");
            Reserva reserva = new Reserva(tratarErro.metodoVerificarTipoDeDado());

            reserva.CadastrarSuite(suiteKing);
            reserva.CadastrarHospedes(hospedes);
            reservaLista.Add(reserva);

            Console.WriteLine($"\nReserva Realizada com sucesso!\nHóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");    
        }
    break;

    case 2:
        string serializados = JsonConvert.SerializeObject(reservaLista, Formatting.Indented);
        File.WriteAllText("InformacaoTXT/Reserva.txt", serializados);
        Console.WriteLine(serializados);
    break;

    case 3:
        Environment.Exit(0);
    break;
    default:
        Environment.Exit(0);
    break;

    }
    
}while(escolha != 3);






 
