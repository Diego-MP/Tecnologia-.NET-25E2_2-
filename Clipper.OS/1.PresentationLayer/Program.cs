using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Repositorie;
using Clipper.OS._3.DomainLayer.Factory;
using Clipper.OS._4.InfrastructureLayer;

namespace Clipper.OS._1.PresentationLayer;

class Program
{
    static void Main(string[] args)
    {
        OrdemDeServicoRepositoy ordemDeServicoRepositoy = new OrdemDeServicoRepositoy();

        // CLIENTE 1 - EzComp
        var client_EzComp = new Cliente
        {
            Nome = "EzComp",
            Endereco = new Endereco
            {
                Logradouro = "Rua das Flores, 89",
                Bairro = "Centro",
                Cidade = "São Paulo",
                Estado = "SP"
            }
        };
        client_EzComp.AdicionarDocumento("CNPJ", "12345678901234");

        var ordem_EzComp = OrdemDeServicoFactory.OrdemDeServico(client_EzComp);
        ordem_EzComp.AdicionarEquipamento(new Equipamento
        {
            Nome = "PC DELL XPS 15",
            Modelo = "XPS 15 - DELL",
            Serial = "FGD76767287JH",
            Valor = 1200.00
        });
        ordem_EzComp.AdicionarEquipamento(new Equipamento
        {
            Nome = "Impressora HP InkJet",
            Modelo = "Deskjet XP248 - HP",
            Serial = "HFHG287872222",
            Valor = 350.00
        });
        ordem_EzComp.AdicionarEquipamento(new Equipamento
        {
            Nome = "Monitor LG 28",
            Modelo = "UltraWide W28 - LG",
            Serial = "LG4567F34567",
            Valor = 890.00
        });
        ordemDeServicoRepositoy.AdicionarOrdermDeServico(ordem_EzComp);

        // CLIENTE 2 - XyPrints
        var client_XyPrints = new Cliente
        {
            Nome = "XyPrints",
            Endereco = new Endereco
            {
                Logradouro = "Av. das Palmeiras, 100A",
                Bairro = "Jardim",
                Cidade = "Rio de Janeiro",
                Estado = "RJ"
            }
        };
        client_XyPrints.AdicionarDocumento("CNPJ", "98765432109876");

        var ordem_XyPrints = OrdemDeServicoFactory.OrdemDeServico(client_XyPrints);
        ordem_XyPrints.AdicionarEquipamento(new Equipamento
        {
            Nome = "Scanner Epson",
            Modelo = "ScanGo 3000",
            Serial = "SCN00112233",
            Valor = 470.00
        });
        ordem_XyPrints.AdicionarEquipamento(new Equipamento
        {
            Nome = "Plotter Canon",
            Modelo = "ImagePrograf 210",
            Serial = "PTT7890044",
            Valor = 3200.00
        });
        ordemDeServicoRepositoy.AdicionarOrdermDeServico(ordem_XyPrints);

        // CLIENTE 3 - FastFix
        var client_FastFix = new Cliente
        {
            Nome = "FastFix Serviços",
            Endereco = new Endereco
            {
                Logradouro = "Rua das Oficinas, 200",
                Bairro = "Indústria",
                Cidade = "Belo Horizonte",
                Estado = "MG"
            }
        };
        client_FastFix.AdicionarDocumento("CNPJ", "44556677889900");

        var ordem_FastFix = OrdemDeServicoFactory.OrdemDeServico(client_FastFix);
        ordem_FastFix.AdicionarEquipamento(new Equipamento
        {
            Nome = "Notebook Lenovo",
            Modelo = "ThinkPad L14",
            Serial = "NBK987656789",
            Valor = 2300.00
        });
        ordemDeServicoRepositoy.AdicionarOrdermDeServico(ordem_FastFix);

        var todasOrdens = ordemDeServicoRepositoy.ListarTodas();

        foreach (var ordem in todasOrdens)
        {
            Console.WriteLine($"Ordem de Serviço Nº: {ordem.NumeroOS}");
            Console.WriteLine($"Cliente: {ordem.Cliente.Nome}");
            Console.WriteLine("Equipamentos:");

            foreach (var equipamento in ordem.Equipamentos)
            {
                Console.WriteLine($"- {equipamento.Nome} | Modelo: {equipamento.Modelo} | Serial: {equipamento.Serial} | Valor: R${equipamento.Valor:F2}");
            }

            Console.WriteLine($"Valor Total da Ordem: R${ordem.ValorTotal():F2}");
            Console.WriteLine("-----------------------------");
            
        }

        var enviarService = new EnviarOrdemDeServicoService();
        var enviarUseCase = new Clipper.OS._2.ApplicationLayer.EnviarOrdemDeServico(
            ordemDeServicoRepositoy,
            enviarService
        );

        int numeroParaEnviar = 0;
        bool sucesso = enviarUseCase.Enviar(numeroParaEnviar, "contato@empresa.com");

        Console.WriteLine(sucesso
            ? $"Ordem de serviço Nº {numeroParaEnviar} enviada com sucesso."
            : $"Falha ao enviar ordem de serviço Nº {numeroParaEnviar}.");

        var ordem_Orcamento = OrdemDeServicoFactory.OrdemDeServico(client_XyPrints, DateTime.Today.AddDays(15));
        ordem_Orcamento.NumeroOS = 2;
        ordem_Orcamento.AdicionarEquipamento(new Equipamento
        {
            Nome = "Notebook Acer",
            Modelo = "Aspire 5",
            Serial = "ABC123456",
            Valor = 2200.00
        });
        ordemDeServicoRepositoy.AdicionarOrdermDeServico(ordem_Orcamento);

        var ordem_Faturada = OrdemDeServicoFactory.OrdemDeServico(client_EzComp, DateTime.Today.AddDays(30), "Boleto");
        ordem_Faturada.NumeroOS = 3;
        ordem_Faturada.AdicionarEquipamento(new Equipamento
        {
            Nome = "Servidor Dell",
            Modelo = "PowerEdge T40",
            Serial = "XYZ987654",
            Valor = 4800.00
        });
        ordemDeServicoRepositoy.AdicionarOrdermDeServico(ordem_Faturada);
        
        var ordem_outra = ordemDeServicoRepositoy.BuscarOrdemDeServico(2);

        if (ordem_outra is Orcamento orc)
        {
            orc.EnviarOrdemDeServico(ordem_outra, "cliente@exemplo.com");
        }
        else if (ordem_outra is Faturada fat)
        {
            fat.EnviarOrdemDeServico(ordem_outra, "cliente@exemplo.com");
        }
        else
        {
            ordem_outra.EnviarOrdemDeServico(ordem_outra,"cliente@exemplo.com"); 
        }
        
        Console.ReadLine();
    }
}
