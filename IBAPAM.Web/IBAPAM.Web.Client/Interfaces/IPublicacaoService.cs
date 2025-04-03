using IBAPAM.Shared.DTOs.Publicacao;

namespace IBAPAM.Web.Client.Interfaces;

public interface IPublicacaoService
{
    void NavegarParaTelaDeListagem();
    void NavegarParaTelaDeCriacao();
    void NavegarParaTelaDeEdicao(int id);
    Task<PublicacaoCreateResponseDto> CreateAsync(PublicacaoCreateRequestDto dto);
    Task<PublicacaoGetByIdResponseDto> GetByIdAsync(int id);
    Task<IEnumerable<PublicacaoDto>> GetAllAsync();
    Task UpdateAsync(PublicacaoUpdateRequestDto dto);
    Task DeleteAsync(int id);
}
