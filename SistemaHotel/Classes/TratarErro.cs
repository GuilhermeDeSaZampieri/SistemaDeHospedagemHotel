using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class TratarErro
    {
        public int metodoVerificarTipoDeDado()
        {
            int escolha;
            while (true)
            {
                try
                {
                    escolha = Convert.ToInt32(Console.ReadLine());
                    break; // Se a conversão for bem-sucedida, sai do loop.

                }
                catch (FormatException)
                {
                    Console.WriteLine("Entrada inválida. Por favor, insira um número válido.");
                }
            }
            return escolha;
        }
    }
}