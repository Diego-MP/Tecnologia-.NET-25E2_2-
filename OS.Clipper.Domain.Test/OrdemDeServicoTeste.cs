using Xunit;
using System;

using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Factory;
using Clipper.OS._3.DomainLayer.Repositorie;
using Clipper.OS._4.InfrastructureLayer;


namespace OS.Clipper.Domain.Test
{
    public class OrdemDeServicoTests
    {
        [Fact]
        public void Deve_Criar_OrdemDeServico_Valida()
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

            var equipamento_test = new Equipamento
            {
                Nome = "Notebook_Unit",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 100.00
            };
            
            var ordem_test = OrdemDeServicoFactory.OrdemDeServico(client_test);
            ordem_test.AdicionarEquipamento(equipamento_test);
            
             Assert.NotNull(ordem_test);
             Assert.Equal(client_test, ordem_test.Cliente);
             Assert.False(string.IsNullOrEmpty(ordem_test.NumeroOS.ToString()));;
             Assert.Equal(0, ordem_test.NumeroOS);
        }
        
        [Fact]
        public void NaoDeve_Criar_OrdemDeServico_SemCliente()
        {
            var equipamento_test = new Equipamento
            {
                Nome = "Notebook_Unit",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 100.00
            };
            
            Assert.Throws<ArgumentNullException>(() =>
                OrdemDeServicoFactory.OrdemDeServico(null));
        }
        
        [Fact]
        public void Nao_Deve_Enviar_OrdemDeServico_Orcamento_Sem_OrdemDeServico()
        {
            OrdemDeServicoRepositoy ordemDeServicoRepositoy = new OrdemDeServicoRepositoy();

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

            var equipamento_test = new Equipamento
            {
                Nome = "Notebook_Unit",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 100.00
            };
            
            var ordem_test_orcamento = OrdemDeServicoFactory.OrdemDeServico(client_test, DateTime.Today.AddDays(15));
            ordem_test_orcamento.NumeroOS = 2;
            ordem_test_orcamento.AdicionarEquipamento(new Equipamento
            {
                Nome = "Notebook Acer",
                Modelo = "Aspire 5",
                Serial = "ABC123456",
                Valor = 2200.00
            });
            
            Assert.Throws<ArgumentNullException>(() =>
                ordemDeServicoRepositoy.AdicionarOrdemDeServico(null));

        }
        
        [Fact]
        public void Nao_Deve_Enviar_OrdemDeServico_Faturada_Sem_MetodoDePagamento()
        {
            OrdemDeServicoRepositoy ordemDeServicoRepositoy = new OrdemDeServicoRepositoy();

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

            var equipamento_test = new Equipamento
            {
                Nome = "Notebook_Unit",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 100.00
            };
            
            var ordem_test_faturada = OrdemDeServicoFactory.OrdemDeServico(client_test, DateTime.Today.AddDays(15), "Boleto");
            ordem_test_faturada.NumeroOS = 2;
            ordem_test_faturada.AdicionarEquipamento(new Equipamento
            {
                Nome = "Notebook Acer",
                Modelo = "Aspire 5",
                Serial = "ABC123456",
                Valor = 2200.00
            });
            
            Assert.Throws<ArgumentNullException>(() =>
                ordemDeServicoRepositoy.AdicionarOrdemDeServico(null));

        }
        
        [Fact]
        public void Deve_Calcular_OrdemDeServico_Corretamente()
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

            var equipamento_test = new Equipamento
            {
                Nome = "Notebook_Unit_1",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 100.00
            };
            
            var equipamento_test_2 = new Equipamento
            {
                Nome = "Notebook_Unit_2",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 90.00
            };
            
            var equipamento_test_3 = new Equipamento
            {
                Nome = "Notebook_Unit_3",
                Modelo = "Teste",
                Serial = "SN123",
                Valor = 10.00
            };
            
            var ordem_test = OrdemDeServicoFactory.OrdemDeServico(client_test);
            
            ordem_test.AdicionarEquipamento(equipamento_test);
            ordem_test.AdicionarEquipamento(equipamento_test_2);
            ordem_test.AdicionarEquipamento(equipamento_test_3);
            
            Assert.Equal(ordem_test.ValorTotal(), 200.00);
        }
    }
}