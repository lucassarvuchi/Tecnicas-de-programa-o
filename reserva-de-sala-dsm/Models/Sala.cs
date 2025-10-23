using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace reserva_de_sala_dsm.Models
{
    [Tags("Salas")]
    public class Sala
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public long Id { get; set; }

        [Required(ErrorMessage = "O nome da sala é obrigatório")]
        [StringLength(100, ErrorMessage = "O nome da sala deve ter no máximo 100 caracteres")]

        public string Nome { get; set; }

        [Reqired(ErrorMessage = "A capacidade da sala é obrigatória")]
        [Range(1, int.MaxValue, ErrorMessage = "A capacidade da sala deve ser um número positivo")]

        public int Capacidade { get; set; }

        [StringLength(500, ErrorMessage = "A descrição da sala deve ter no máximo 500 caracteres")]

        public string Recursos { get; set; }


    }
}
