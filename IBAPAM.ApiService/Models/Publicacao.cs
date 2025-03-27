// Models/Publicacao.cs

using System.ComponentModel.DataAnnotations;

namespace IBAPAM.ApiService.Models
{
    public class Publicacao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é obrigatório")]
        [StringLength(100)]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "O conteúdo é obrigatório")]
        public string Conteudo { get; set; }

        // Adicione outras propriedades conforme necessário
    }
}