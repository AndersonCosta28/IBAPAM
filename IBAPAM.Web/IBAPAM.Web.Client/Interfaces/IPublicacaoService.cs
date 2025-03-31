using IBAPAM.Shared.Models.PublicacaoDTOs;

namespace IBAPAM.Web.Client.Interfaces;

public interface IPublicacaoService
{
    void NavegarParaTelaDeListagem();
    void NavegarParaTelaDeCriacao();
    void NavegarParaTelaDeEdicao(int id);
    Task<PublicacaoDto> CreateAsync(PublicacaoCreateDto dto);
    Task<PublicacaoDto> GetByIdAsync(int id);
    Task<IEnumerable<PublicacaoDto>> GetAllAsync();
    Task UpdateAsync(PublicacaoUpdateDto dto);
    Task DeleteAsync(int id);
}
