using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace trabalho02
{
    public class Parada
    {
        public string Nome;

        public TimeSpan HorarioSaida;

        public TimeSpan HorarioChegada;

        public Parada(string nome, TimeSpan horarioSaida,TimeSpan horarioChegada)
        {
            this.Nome = nome;
            this.HorarioChegada = horarioChegada;
            this.HorarioSaida = horarioSaida;
        }

    }
}
