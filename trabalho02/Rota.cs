using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace trabalho02
{
    public class Rota
    {
        public int Numero { get; set; }
        public string Nome { get; set; }

        public List<Parada> Paradas { get; set; }

        public Rota(int numero,string nome)
        {
            this.Numero = numero;
            this.Nome = nome;
            Paradas = new List<Parada>();
        }

        public void AdicionarParada(Parada parada)
        {
            if (!Paradas.Contains(parada))
            {
                Paradas.Add(parada);
                return;
            }
            throw new Exception("Já existe o item");
        }



        public void RemoverParada(string nomeParada)
        {
            var parada = Paradas.FirstOrDefault(p => p.Nome == nomeParada);
            if (parada == null)
            {
                throw new KeyNotFoundException("Parada não encontrada.");
            }

            Paradas.Remove(parada);
        }

        public void AtualizarNome(string nome)
        {
            if (nome.Length > 0 || this.Nome != nome)
            {
                this.Nome = nome;
            }
        }

        public void ListarParadas()
        {
            foreach (Parada parada in Paradas)
            {
                Console.WriteLine(parada);
            }
        }

    }
}
