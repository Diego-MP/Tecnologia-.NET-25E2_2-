using Clipper.OS._3.DomainLayer.Model;

namespace Clipper.OS._3.DomainLayer.Repositorie;

public interface IOrdemDeServicoRepositoy
{
    public void AdicionarOrdermDeServico(OrdemDeServico ordemDeServico);
    
    public OrdemDeServico  BuscarOrdemDeServico(int numeoDaOrdemDeServico);
    
    public List<OrdemDeServico> ListarTodas();
}