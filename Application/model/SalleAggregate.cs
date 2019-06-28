using System.Collections.Generic;
using System.Linq;
using Application.Dtos;

namespace Application.model
{
    public class SalleAggregate
    {
        internal Salle Salle { get; set; }

        public SalleAggregate Match(IEnumerable<SalleDto> salles, CreneauDto creneau)
        {
            var c = new Creneau(creneau);
            Salle = salles.Select(s => new Salle(s))
                .FirstOrDefault(salle => salle.IsAvailableAt(c));

            return this;
        }
    }
}