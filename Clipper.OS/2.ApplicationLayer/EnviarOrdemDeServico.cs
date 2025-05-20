using Clipper.OS._3.DomainLayer.Model;
using Clipper.OS._3.DomainLayer.Repositorie;
using Clipper.OS._3.DomainLayer.Factory;
using Clipper.OS._4.InfrastructureLayer;


namespace Clipper.OS._2.ApplicationLayer;

/*Princípio SOLID: Single Responsibility Principle (SRP) — Princípio da Responsabilidade Única
A classe EnviarOrdemDeServico tem uma única responsabilidade: orquestrar o envio de uma ordem 
de serviço por e-mail, delegando persistência e envio para outras classes.
*/
public class EnviarOrdemDeServico
{
    private IOrdemDeServicoRepositoy _ordemDeServicoRepositoy;
    private EnviarOrdemDeServicoService _enviarOrdemDeServicoService;

    public EnviarOrdemDeServico(IOrdemDeServicoRepositoy ordemDeServicoRepositoy,
        EnviarOrdemDeServicoService enviarOrdemDeServicoService)
    {
        /* Baixo Acoplamento
         * As dependências são injetadas, não criadas internamente.
         * A utilização de interfaces e injeção de dependência reduz o acoplamento entre as classes,
         * permitindo trocar implementações facilmente.
         */
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