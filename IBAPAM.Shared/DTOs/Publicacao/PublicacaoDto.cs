namespace IBAPAM.Shared.DTOs.Publicacao;

public record PublicacaoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}