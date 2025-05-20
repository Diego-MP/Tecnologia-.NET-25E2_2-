using Xunit;
using Clipper.OS._3.DomainLayer.Model;
using System;

namespace OS.Clipper.Domain.Test
{
    public class EquipamentoTest
    {
        [Fact]
        public void Deve_Adicionar_Equipamento_Valido()
        {
            var equipamento = new Equipamento();

            equipamento.AdicionarEquipamento("Monitor", "Dell UltraSharp", "SN9988", 1200.50);

            Assert.Equal("Monitor", equipamento.Nome);
            Assert.Equal("Dell UltraSharp", equipamento.Modelo);
            Assert.Equal("SN9988", equipamento.Serial);
            Assert.Equal(1200.50, equipamento.Valor);
        }

        [Fact]
        public void Nao_Deve_Aceitar_Serial_Nulo()
        {
            var equipamento = new Equipamento();

            Assert.Throws<ArgumentNullException>(() =>
                equipamento.AdicionarEquipamento("Mouse", "Logitech G305", null, 200)
            );
        }
        

        [Fact]
        public void Deve_Aceitar_Valor_Zero()
        {
            var equipamento = new Equipamento();

            equipamento.AdicionarEquipamento("Hub USB", "Intelbras", "USB123", 0);

            Assert.Equal(0, equipamento.Valor);
        }
        
        [Fact]
        public void Nao_Deve_Aceitar_Valor_Negativo()
        {
            var equipamento = new Equipamento();

            Assert.Throws<ArgumentNullException>(() =>
                equipamento.AdicionarEquipamento("HD", "Samsung", "HDSAM123", -200)
            );
        }
        
    }
}
