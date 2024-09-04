using System.ComponentModel.DataAnnotations;

namespace Agenda.ViewModels
{
    public class CreateContatoVM
    {
        //[Required(ErrorMessage ="Codigo é Obrigatório")] //obriga o campo a ser preenchido
        //public int Codigo { get; set; }

        [Required]
        [StringLength(11)] //Define o numero maximo de caracteres
        public string? NomeCompleto { get; set; }
        
        [Required]
        public string? Telefone { get; set; }
        
        [Required]
        public DateTime DataDeNascimento { get; set; }
    }
     public class UpdateContato
    {
        

        public string? NomeCompleto { get; set; }

        public string? Telefone { get; set; }

        public DateTime DataDeNascimento { get; set; }
    }
}