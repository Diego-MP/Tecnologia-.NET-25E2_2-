using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Repositorie;

namespace Clipper.OS._4.InfrastructureLayer;
/*
 * Alta Coesão
 * A classe OrdemDeServicoRepositoy é altamente coesa, pois todos os seus métodos tratam
 * exclusivamente de operações sobre ordens de serviço.
 */
public class OrdemDeServicoRepositoy : IOrdemDeServicoRepositoy
{
    private static readonly List<OrdemDeServico> _ordens = new();

    public void AdicionarOrdemDeServico(OrdemDeServico ordemDeServico)
    {
        if (ordemDeServico == null)
            throw new ArgumentNullException(nameof(ordemDeServico));
        _ordens.Add(ordemDeServico);
    }

    public OrdemDeServico  BuscarOrdemDeServico(int id)
    {
        return _ordens.FirstOrDefault(o => o.NumeroOS == id);
    }

    public List<OrdemDeServico> ListarTodas()
    {
        return _ordens.ToList();
    }
}