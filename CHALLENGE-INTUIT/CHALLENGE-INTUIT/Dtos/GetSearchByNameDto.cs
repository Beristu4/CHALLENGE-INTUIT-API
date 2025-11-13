namespace CHALLENGE_INTUIT.Dtos
{
    public class GetSearchByNameDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public string? Adress { get; set; }
        public string Telephone { get; set; }
        public string Cuit { get; set; }
        public string Email { get; set; }
    }
}
