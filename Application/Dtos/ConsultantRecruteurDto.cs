namespace Application.Dtos
{
    public class ConsultantRecruteurDto : EntityDto
    {
        public string Name { get; set;}
        public ProfileDto Profile { get; set; }
    }
}