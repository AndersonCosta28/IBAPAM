using IBAPAM.Shared.DTOs.Publicacao;

namespace IBAPAM.ApiService.Interfaces;

public interface IPublicacaoService
{
    Task<PublicacaoCreateResponseDto> CreateAsync(PublicacaoCreateRequestDto publicacao);
    Task<PublicacaoGetByIdResponseDto> GetByIdAsync(int id);
    Task<IEnumerable<PublicacaoDto>> GetAllAsync();
    Task UpdateAsync(PublicacaoUpdateRequestDto publicacao);
    Task DeleteAsync(int id);
}
