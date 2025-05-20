namespace Clipper.OS._3.DomainLayer.Model;

public class Orcamento : OrdemDeServico
{
    public DateTime Validade { get; set; }

    public Orcamento()
    {
        
    }

    public override void EnviarOrdemDeServico(OrdemDeServico ordemDeServico, string email)
    {
        Console.WriteLine("[Email]: Enviando Orçamento da ordem de serviço...");
        
    }
}