namespace Clipper.OS._3.DomainLayer.Model;

public class Faturada : OrdemDeServico
{
    public DateTime PrazoDePagamento { get; set; }
    public string MetodoDePagamento { get; set; }

    public Faturada()
    {
        
    }
    
    public override void EnviarOrdemDeServico(OrdemDeServico ordemDeServico, string email)
    {
        Console.WriteLine("[Email]: Enviando ordem de serviço faturada...");
    }
}