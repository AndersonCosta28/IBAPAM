namespace IBAPAM.Shared.DTOs.Publicacao;

public record PublicacaoUpdateRequestDto
{
    public int Id { get; set; } = 0;
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}