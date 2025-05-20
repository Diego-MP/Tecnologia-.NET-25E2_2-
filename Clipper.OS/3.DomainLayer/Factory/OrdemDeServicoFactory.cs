using System.Runtime.InteropServices.JavaScript;
using Clipper.OS._3.DomainLayer.Model;

namespace Clipper.OS._3.DomainLayer.Factory;

public class OrdemDeServicoFactory
{
    public static OrdemDeServico OrdemDeServico(Cliente cliente)
    {
        if (cliente == null)
            throw new ArgumentNullException(nameof(cliente));
        
        return new OrdemDeServico
        {
            Cliente = cliente
        };
    }

    public static OrdemDeServico OrdemDeServico(Cliente cliente, DateTime validade)
    {
        return new Orcamento
        {
            Cliente = cliente,
            Validade = validade
        };
    }

    public static OrdemDeServico OrdemDeServico(Cliente cliente, DateTime prazoDePagamento, string metodoDePagamento)
    {
        if (metodoDePagamento == null)
            throw new ArgumentNullException(nameof(metodoDePagamento));
        return new Faturada
        {
            Cliente = cliente,
            PrazoDePagamento = prazoDePagamento,
            MetodoDePagamento = metodoDePagamento
        };
    }
}