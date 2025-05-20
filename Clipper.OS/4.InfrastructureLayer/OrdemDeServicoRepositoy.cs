using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Repositorie;

namespace Clipper.OS._4.InfrastructureLayer;

public class OrdemDeServicoRepositoy : IOrdemDeServicoRepositoy
{
    private static readonly List<OrdemDeServico> _ordens = new();

    public void AdicionarOrdermDeServico(OrdemDeServico ordemDeServico)
    {
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