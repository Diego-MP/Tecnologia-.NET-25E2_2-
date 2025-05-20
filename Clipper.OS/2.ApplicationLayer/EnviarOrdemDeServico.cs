using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Repositorie;
using Clipper.OS._3.DomainLayer.Factory;
using Clipper.OS._4.InfrastructureLayer;


namespace Clipper.OS._2.ApplicationLayer;

public class EnviarOrdemDeServico
{
    private IOrdemDeServicoRepositoy _ordemDeServicoRepositoy;
    private EnviarOrdemDeServicoService _enviarOrdemDeServicoService;

    public EnviarOrdemDeServico(IOrdemDeServicoRepositoy ordemDeServicoRepositoy,
        EnviarOrdemDeServicoService enviarOrdemDeServicoService)
    {
        _ordemDeServicoRepositoy = ordemDeServicoRepositoy;
        _enviarOrdemDeServicoService = enviarOrdemDeServicoService;
    }
    
    public bool Enviar(int ordemDeServicoId, string email)
    {
        try
        {
            OrdemDeServico ordemDeServico = _ordemDeServicoRepositoy.BuscarOrdemDeServico(ordemDeServicoId);
            _enviarOrdemDeServicoService.Enviar(ordemDeServico, email);
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao enviar ordem de serviço: {ex.Message}");
            return false;
        }
    }
}