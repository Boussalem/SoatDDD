using Application.Dtos;

namespace Application.model
{
    internal class ConsultantRecruteur : Entity
    {
        public string Name { get; set;}
        public Profile Profile { get; set; }

        public ConsultantRecruteur(ConsultantRecruteurDto dto)
        {
            Name = dto.Name;
            Profile = new Profile(dto.Profile);
        }

        public bool CanInterview(Profile profile) => Profile.Experience > profile.Experience;

        public bool IsAvailableAt(Creneau creneau) => true;

        public static explicit operator ConsultantRecruteurDto(ConsultantRecruteur consultantRecruteur)
        {
            return new ConsultantRecruteurDto
            {
                Profile = (ProfileDto) consultantRecruteur.Profile,
                Name = consultantRecruteur.Name,
                Id = consultantRecruteur.Id,
            };
        }
    }
}
