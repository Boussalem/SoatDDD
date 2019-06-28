using System.Collections.Generic;
using System.Linq;

namespace Application.model
{
    public class SalleAggregate
    {
        public Salle Salle { get; set; }

        public SalleAggregate Match(IEnumerable<Salle> salles, Creneau creneau)
        {
            Salle = salles.FirstOrDefault(salle => salle.IsAvailableAt(creneau));

            return this;
        }
    }
}