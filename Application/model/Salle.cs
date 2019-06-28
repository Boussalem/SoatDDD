using Application.Dtos;

namespace Application.model
{
    internal class Salle : Entity
    {
        public string Name { get; set; }

        public Salle(SalleDto dto)
        {
            Name = dto.Name;
        }

        public bool IsAvailableAt(Creneau creneau) => true;

        public static explicit operator SalleDto(Salle salle)
        {
            return new SalleDto
            {
                Name = salle.Name,
                Id = salle.Id,
            };
        }
    }
}