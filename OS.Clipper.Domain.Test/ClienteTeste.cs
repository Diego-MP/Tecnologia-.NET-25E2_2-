using Xunit;
using Clipper.OS._3.DomainLayer.Model;

namespace OS.Clipper.Domain.Test
{
    public class ClienteTeste
    {
        [Fact]
        public void Nao_Deve_Aceitar_Documento_Sem_Tipo()
        {
            var client_test = new Cliente
            {
                Nome = "Antonio_Unit",
                Endereco = new Endereco
                {
                    Logradouro = "Rua das Unidades, 89",
                    Bairro = "Teste",
                    Cidade = "São Paulo",
                    Estado = "SP"
                }
            };
            
            Assert.Throws<ArgumentNullException>(() =>
                client_test.AdicionarDocumento(null, "54678945636")
            );
        }

        [Fact]
        public void Deve_Aceitar_Documento_Valido()
        {
            var client_test = new Cliente
            {
                Nome = "Antonio_Unit",
                Endereco = new Endereco
                {
                    Logradouro = "Rua das Unidades, 89",
                    Bairro = "Teste",
                    Cidade = "São Paulo",
                    Estado = "SP"
                }
            };

            client_test.AdicionarDocumento("CPF", "54678945636");

            Assert.Single(client_test.Documento);
            Assert.Equal("CPF", client_test.Documento.First().Tipo);
            Assert.Equal("54678945636", client_test.Documento.First().Numero);
        }
    }
}