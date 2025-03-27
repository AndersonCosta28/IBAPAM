using System;
using IBAPAM.ApiService.Models;
using IBAPAM.Shared.Models.PublicacaoDTOs;

namespace IBAPAM.ApiService.Interfaces;

public interface IPublicacaoService
{
    Task<PublicacaoDto> CreateAsync(PublicacaoCreateDto publicacao);
    Task<PublicacaoDto> GetByIdAsync(int id);
    Task<IEnumerable<PublicacaoDto>> GetAllAsync();
    Task UpdateAsync(PublicacaoUpdateDto publicacao);
    Task DeleteAsync(int id);
}
