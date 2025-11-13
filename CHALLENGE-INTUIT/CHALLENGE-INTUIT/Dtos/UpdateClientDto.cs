using System.ComponentModel.DataAnnotations;

namespace CHALLENGE_INTUIT.Dtos
{
    public class UpdateClientDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Nombre es obligatorio.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El Apellido es obligatorio.")]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required(ErrorMessage = "El Cuit es obligatorio.")]
        public string Cuit { get; set; }

        public string? Address { get; set; }

        [Required(ErrorMessage = "El Telefono es obligatorio.")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El Email es obligatorio.")]
        public string Email { get; set; }
    }
}
