using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho02
{
    public class GerenciarRotas
    {
        public List<Rota> Rotas;

        public GerenciarRotas()
        {
            this.Rotas = new List<Rota>();
        }

        public void AdicionarRota(int numero, string nome)
        {
            if (Rotas.Any(r => r.Numero == numero))
            {
                throw new InvalidOperationException("Rota com o mesmo número já existe.");
            }

            Rotas.Add(new Rota(numero, nome));
        }

        public void RemoverRota(int numero)
        {
            var rota = Rotas.FirstOrDefault(r => r.Numero == numero);
            if (rota == null)
            {
                throw new KeyNotFoundException("Rota não encontrada.");
            }
            Rotas.Remove(rota);
        }

        public Rota BuscarRota(int numero) {
            foreach (Rota rota in Rotas)
            {
                if (rota.Numero == numero)
                {
                    return rota;
                }
            }
            return null;
        }

        public List<Rota> ListarRotas()
        {
            return Rotas;
        }

        public bool VerificarConflitos()
        {
            Dictionary<TimeSpan, int> dic = new Dictionary<TimeSpan,int>();
            foreach(Rota rota in Rotas)
            {
                List<Parada> paradas = rota.Paradas;
                foreach (Parada parada in paradas)
                {
                    TimeSpan horarioChegada = parada.HorarioChegada;
                    if (dic.ContainsKey(horarioChegada))
                    {
                        return true;
                    }
                    dic.Add(horarioChegada, rota.Numero);
                }
            }
            return false;
        }

    }
}
