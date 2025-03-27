// PublicacaoDTOs/PublicacaoDto.cs

namespace IBAPAM.Shared.Models.PublicacaoDTOs;

public class PublicacaoDto
{
    public int Id { get; set; }
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}

public class PublicacaoCreateDto
{
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}

public class PublicacaoUpdateDto
{
    public int Id { get; set; } = 0;
    public string Titulo { get; set; } = string.Empty;
    public string Conteudo { get; set; } = string.Empty;
}

public class PublicacaoListDto
{
    public IEnumerable<PublicacaoDto> Publicacoes { get; set; } = [];
}

public class PublicacaoDetailDto
{
    public PublicacaoDto Publicacao { get; set; }
}