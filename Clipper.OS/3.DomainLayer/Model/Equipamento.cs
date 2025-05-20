namespace Clipper.OS._3.DomainLayer.Model;

public class Equipamento
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Modelo { get; set; }
    public string Serial { get; set; }
    public double Valor { get; set; }
    
    public void AdicionarEquipamento(string nome, string modelo, string serial)
    {
        Nome = nome;
        Modelo = modelo;
        Serial = serial;
    }
}