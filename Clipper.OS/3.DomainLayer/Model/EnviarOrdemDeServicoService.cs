namespace Clipper.OS._3.DomainLayer.Model;

public class EnviarOrdemDeServicoService
{
    public void Enviar(OrdemDeServico ordemDeServico, string email)
    {
        ordemDeServico.EnviarOrdemDeServico(ordemDeServico, email);
    }
}