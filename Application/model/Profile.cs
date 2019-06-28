using System;
using System.Collections.Generic;
using Application.Dtos;
using System.Linq;

namespace Application.model
{
    public class Profile
    {
        private Profile()
        { }

        public Profile(ProfileDto dto)
        {
            Experience = dto.Experience;
        }

        public Profile(int experience)
        {
            Experience = experience;
        }

        public int Experience { get; }

        public static explicit operator ProfileDto(Profile profile)
        {
            return new ProfileDto
            {
                Experience = profile.Experience,
            };
        }

        internal ConsultantRecruteur RecruteurMatchingProfile(IEnumerable<ConsultantRecruteur> availableRecruteurs)
        {
            return availableRecruteurs.FirstOrDefault(c => c.Profile.Experience > this.Experience);
        }
    }
}