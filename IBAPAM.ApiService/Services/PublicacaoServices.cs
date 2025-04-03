using IBAPAM.ApiService.Data;
using IBAPAM.ApiService.Interfaces;
using IBAPAM.ApiService.Models;
using IBAPAM.Shared.DTOs.Publicacao;
using Microsoft.EntityFrameworkCore;

namespace IBAPAM.ApiService.Services;

public class PublicacaoService : IPublicacaoService
{
    private readonly ApplicationDbContext _context;

    public PublicacaoService(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<PublicacaoCreateResponseDto> CreateAsync(PublicacaoCreateRequestDto dto)
    {
        var publicacao = new Publicacao
        {
            Titulo = dto.Titulo,
            Conteudo = dto.Conteudo
        };

        await _context.Publicacoes.AddAsync(publicacao);
        await _context.SaveChangesAsync();

        return new PublicacaoCreateResponseDto
        {
            Id = publicacao.Id,
            Titulo = publicacao.Titulo,
            Conteudo = publicacao.Conteudo
        };
    }

    public async Task<PublicacaoGetByIdResponseDto> GetByIdAsync(int id)
    {
        var publicacao = await _context.Publicacoes.FindAsync(id) ?? throw new KeyNotFoundException("Publicação não encontrada");
        return new PublicacaoGetByIdResponseDto
        {
            Id = publicacao.Id,
            Titulo = publicacao.Titulo,
            Conteudo = publicacao.Conteudo
        };
    }

    public async Task<IEnumerable<PublicacaoDto>> GetAllAsync()
    {
        var publicacoes = await _context.Publicacoes.ToListAsync();
        return publicacoes.Select(p => new PublicacaoDto
        {
            Id = p.Id,
            Titulo = p.Titulo,
            Conteudo = p.Conteudo
        });
    }

    public async Task UpdateAsync(PublicacaoUpdateRequestDto dto)
    {
        var publicacao = await _context.Publicacoes.FindAsync(dto.Id) ?? throw new KeyNotFoundException("Publicação não encontrada");
        publicacao.Titulo = dto.Titulo;
        publicacao.Conteudo = dto.Conteudo;

        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var publicacao = await _context.Publicacoes.FindAsync(id) ?? throw new KeyNotFoundException("Publicação não encontrada");
        _context.Publicacoes.Remove(publicacao);
        await _context.SaveChangesAsync();
    }
}