using IBAPAM.ApiService.Interfaces;
using IBAPAM.Shared.Models.PublicacaoDTOs;
using Microsoft.AspNetCore.Mvc;

namespace IBAPAM.ApiService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PublicacoesController : ControllerBase
{
    private readonly IPublicacaoService _service;

    public PublicacoesController(IPublicacaoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<PublicacaoDto>> PostPublicacao([FromBody] PublicacaoCreateDto dto)
    {
        var created = await _service.CreateAsync(dto);
        return CreatedAtAction(nameof(PostPublicacao), created.Id, created);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<PublicacaoDto>> GetPublicacao(int id)
    {
        var publicacao = await _service.GetByIdAsync(id);
        if (publicacao == null)
        {
            return NotFound();
        }
        return publicacao;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PublicacaoDto>>> GetPublicacoes()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutPublicacao(int id, PublicacaoUpdateDto dto)
    {
        if (id != dto.Id)
        {
            return BadRequest();
        }
        await _service.UpdateAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePublicacao(int id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }
}