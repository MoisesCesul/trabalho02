using trabalho02;

namespace Teste
{
    public class UnitTest1
    {
        [Fact]
        public void AdicionarRota_DeveAdicionarRotaValida()
        {
            // Arrange
            var gerenciador = new GerenciarRotas();

            // Act
            gerenciador.AdicionarRota(1, "Rota 1");

            // Assert
            Assert.Single(gerenciador.Rotas);
            Assert.Equal("Rota 1", gerenciador.Rotas[0].Nome);
            Assert.Equal(1, gerenciador.Rotas[0].Numero);
        }
        [Fact]

        public void AdicionarParada_DeveAdicionarParadaValida()
        {
            // Arrange
            var rota = new Rota(1, "Rota 1");
            var parada = new Parada("Parada A", new TimeSpan(9, 0, 0), new TimeSpan(9, 5, 0));

            // Act
            rota.AdicionarParada(parada);

            // Assert
            Assert.Single(rota.Paradas);
            Assert.Equal("Parada A", rota.Paradas[0].Nome);
        }



        [Fact]
        public void AdicionarRota_DeveLancarExcecaoParaRotaDuplicada()
        {
            // Arrange
            var gerenciador = new GerenciarRotas();
            gerenciador.AdicionarRota(1, "Rota 1");

            // Act & Assert
            Assert.Throws<InvalidOperationException>(() => gerenciador.AdicionarRota(1, "Rota Duplicada"));
        }

        [Fact]
        public void RemoverRota_DeveRemoverRotaExistente()
        {
            // arrange
            var gerenciador = new GerenciarRotas();
            gerenciador.AdicionarRota(1, "Rota 1");

            // act
            gerenciador.RemoverRota(1);

            // Assert
            Assert.Empty(gerenciador.Rotas);
        }
        [Fact]
        public void RemoverParada_DeveRemoverParadaExistente()
        {
            // Arrange
            var rota = new Rota(1, "Rota 1");
            var parada = new Parada("Parada A", new TimeSpan(9, 0, 0), new TimeSpan(9, 5, 0));
            rota.AdicionarParada(parada);

            // Act
            rota.RemoverParada("Parada A");

            // Assert
            Assert.Empty(rota.Paradas);
        }
        [Fact]
        public void AtualizarNome_DeveAtualizarNomeCorretamente()
        {

            var rota = new Rota(1, "Rota antiga");

            rota.AtualizarNome("Rota nova");

            Assert.Equal("Rota nova", rota.Nome);

        }
        [Fact]
        public void ListarRotas_DeveListarTodasAsRotas()
        {
            //arrange
            var gerenciador = new GerenciarRotas();
            gerenciador.AdicionarRota(2, "Rota bonita");
            gerenciador.AdicionarRota(3, "Rota alternativa");

            //act
            var rotas = gerenciador.ListarRotas();

            //assert
            Assert.Equal(2, rotas.Count);
            Assert.Equal("Rota bonita", rotas[0].Nome);
            Assert.Equal("Rota alternativa", rotas[1].Nome);

        }

        [Fact]
        public void ListarParadas_DeveListarTodasParadas()
        {
            // arrange
            var rota = new Rota(1, "Rota 1");
            var parada1 = new Parada("Parada 1", new TimeSpan(9, 4, 2), new TimeSpan(9, 5, 0));
            var parada2 = new Parada("Parada 2", new TimeSpan(10, 5, 0), new TimeSpan(10, 6, 0));

            rota.AdicionarParada(parada1);
            rota.AdicionarParada(parada2);

            // act
            var paradas = rota.Paradas;

            // assert
            Assert.Equal(2, paradas.Count);
            Assert.Equal("Parada 1", paradas[0].Nome);
            Assert.Equal("Parada 2", paradas[1].Nome);
        }

        [Fact]
        public void BuscarRota_DeveRetornarRotaCorreta()
        {
            // Arrange
            var gerenciador = new GerenciarRotas();
            gerenciador.AdicionarRota(1, "Rota 1");
            gerenciador.AdicionarRota(2, "Rota 2");

            // Act
            var rota = gerenciador.BuscarRota(1);

            // Assert
            Assert.NotNull(rota);
            Assert.Equal(1, rota.Numero);
            Assert.Equal("Rota 1", rota.Nome);
        }
        [Fact]
        public void BuscarRota_DeveRetornarNuloParaRotaInexistente()
        {
            // Arrange
            var gerenciador = new GerenciarRotas();

            // Act & Assert
            Assert.Equal(null,gerenciador.BuscarRota(50));
        }
        [Fact]
        public void VerificarConflitos_DeveIdentificarConflitosCorretamente()
        {
            var gerenciador = new GerenciarRotas();

            var rota1 = new Rota(1, "Rota 1");
            var rota2 = new Rota(2, "Rota 2");

            var parada1 = new Parada("Parada 1", new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0));
            var parada2 = new Parada("Parada 1", new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0));

            rota1.AdicionarParada(parada1);
            rota2.AdicionarParada(parada2);

            gerenciador.Rotas.Add(rota1);
            gerenciador.Rotas.Add(rota2);


            // Act
            bool conflitos = gerenciador.VerificarConflitos();

            // Assert
            Assert.True(conflitos);
        }

        [Fact]
        public void VerificarConflitos_AposRemoverRota_DeveRetornarFalso()
        {
            var gerenciador = new GerenciarRotas();

            var rota1 = new Rota(1, "Rota 1");
            var rota2 = new Rota(2, "Rota 2");

            var parada1 = new Parada("Parada 1", new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0));
            var parada2 = new Parada("Parada 1", new TimeSpan(10, 0, 0), new TimeSpan(10, 15, 0));

            rota1.AdicionarParada(parada1);
            rota2.AdicionarParada(parada2);

            gerenciador.Rotas.Add(rota1);
            gerenciador.Rotas.Add(rota2);
            gerenciador.Rotas[1].RemoverParada("Parada 1");


            // Act
            bool conflitos = gerenciador.VerificarConflitos();

            // Assert
            Assert.False(conflitos);
        }
    }
}