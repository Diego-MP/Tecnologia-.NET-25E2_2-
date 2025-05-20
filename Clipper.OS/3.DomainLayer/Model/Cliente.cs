namespace Clipper.OS._3.DomainLayer.Model;

public class Cliente
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public Endereco Endereco { get; set; }
    public List<Documento> Documento { get; set; } = new List<Documento>();
    
    public void AdicionarDocumento(string tipo, string numero)
    {
        Documento.Add(new Documento { Tipo = tipo, Numero = numero });
    }
}

