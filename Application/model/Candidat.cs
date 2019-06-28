using Application.Dtos;

namespace Application.model
{
    internal class Candidat : Entity
    {
        public Candidat(CandidatDto dto)
        {
            Name = dto.Name;
            Profile = new Profile(dto.Profile);
        }

        public string Name { get; set; }
        public Profile Profile { get; set; }

        public static explicit operator CandidatDto(Candidat candidat)
        {
            return new CandidatDto
            {
                Profile = (ProfileDto) candidat.Profile,
                Name = candidat.Name,
            };
        }
    }
}
