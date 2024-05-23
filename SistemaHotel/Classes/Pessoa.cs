using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaHotel.Classes
{
    public class Pessoa 
    {
        public Pessoa() { }

        public Pessoa(string nome)
        {
            Nome = nome;
        }

        public Pessoa(string nome, string sobrenome)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            NomeCompleto = nome + " " + sobrenome;
        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string NomeCompleto  {get; set;}
    }
}