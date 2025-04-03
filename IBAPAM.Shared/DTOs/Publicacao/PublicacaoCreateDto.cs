namespace IBAPAM.Shared.DTOs.Publicacao;
public record PublicacaoCreateRequestDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}

public record PublicacaoCreateResponseDto : PublicacaoDto;