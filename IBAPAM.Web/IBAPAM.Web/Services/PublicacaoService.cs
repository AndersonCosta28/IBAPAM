using IBAPAM.Shared.DTOs.Publicacao;
using IBAPAM.Web.Client.Interfaces;
using Microsoft.AspNetCore.Components;

namespace IBAPAM.Web.Services;

public class PublicacaoService : IPublicacaoService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PublicacaoService> _logger;
    private readonly NavigationManager _navigationManager;

    public PublicacaoService(
        HttpClient _httpClient,
        ILogger<PublicacaoService> logger,
        NavigationManager navigationManager)
    {
        this._httpClient = _httpClient;

        _logger = logger;
        this._navigationManager = navigationManager;
    }

    public async Task<PublicacaoCreateResponseDto> CreateAsync(PublicacaoCreateRequestDto dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("api/publicacoes", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PublicacaoCreateResponseDto>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao criar publicação");
            throw;
        }
    }

    public async Task<PublicacaoGetByIdResponseDto> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/publicacoes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PublicacaoGetByIdResponseDto>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao obter publicação por ID");
            throw;
        }
    }

    public async Task<IEnumerable<PublicacaoDto>> GetAllAsync()
    {
        try
        {
            var response = await _httpClient.GetAsync("api/publicacoes");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<PublicacaoDto>>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao obter todas as publicações");
            throw;
        }
    }

    public async Task UpdateAsync(PublicacaoUpdateRequestDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync($"api/publicacoes/{dto.Id}", dto);
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao atualizar publicação");
            throw;
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            var response = await _httpClient.DeleteAsync($"api/publicacoes/{id}");
            response.EnsureSuccessStatusCode();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao deletar publicação");
            throw;
        }
    }

    public void NavegarParaTelaDeListagem()
    {
        this._navigationManager.NavigateTo("/publicacoes");
    }
    public void NavegarParaTelaDeCriacao()
    {
        this._navigationManager.NavigateTo("/publicacoes/criar-publicacao");
    }
    public void NavegarParaTelaDeEdicao(int id)
    {
        this._navigationManager.NavigateTo($"/publicacoes/editar-publicacao/{id}");
    }
}