namespace CHALLENGE_INTUIT.Dtos
{
    public class GetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Adress { get; set; }
        public string Telephone { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
    }
}
