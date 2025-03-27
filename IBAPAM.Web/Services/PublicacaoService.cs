using IBAPAM.Shared.Models.PublicacaoDTOs;

namespace IBAPAM.Web.Services;

public class PublicacaoService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<PublicacaoService> _logger;

    public PublicacaoService(HttpClient httpClient, ILogger<PublicacaoService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<PublicacaoDto> CreateAsync(PublicacaoCreateDto dto)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync<PublicacaoCreateDto>("api/publicacoes", dto);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PublicacaoDto>();
        }
        catch (HttpRequestException ex)
        {
            _logger.LogError(ex, "Erro ao criar publicação");
            throw;
        }
    }

    public async Task<PublicacaoDto> GetByIdAsync(int id)
    {
        try
        {
            var response = await _httpClient.GetAsync($"api/publicacoes/{id}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<PublicacaoDto>();
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

    public async Task UpdateAsync(PublicacaoUpdateDto dto)
    {
        try
        {
            var response = await _httpClient.PutAsJsonAsync<PublicacaoUpdateDto>($"api/publicacoes/{dto.Id}", dto);
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
}