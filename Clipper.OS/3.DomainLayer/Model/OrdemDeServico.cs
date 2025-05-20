
namespace Clipper.OS._3.DomainLayer.Model;

public class OrdemDeServico
{
    public int NumeroOS { get; set; }
    public DateTime DataCriacao { get; set; }
    public Cliente Cliente { get; set; }
    public Equipamento Equipamento { get; set; }
    
    public List<Equipamento> Equipamentos { get; set; } = new();
    
    public void AdicionarEquipamento(Equipamento equipamento)
    {
        Equipamentos.Add(equipamento);
    }
    
    public void RemoverEquipamento(Guid equipamentoId)
    {
        Equipamentos.RemoveAll(e => e.Id == equipamentoId);
    }

    public double ValorTotal()
    {
        return Equipamentos.Sum(e => e.Valor);
    }
    
    public virtual void EnviarOrdemDeServico(OrdemDeServico ordem, string email)
    {
        Console.WriteLine($"[EMAIL FAKE] Enviando ordem Nº {ordem.NumeroOS} para {email}...");
    }

    public List<OrdemDeServico> ListarOrdensDeServicoes(DateTime dataInicio)
    {
        return new List<OrdemDeServico>();
    }
    
}