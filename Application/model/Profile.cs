using Application.Dtos;

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

        public int Experience { get; }

        public static explicit operator ProfileDto(Profile profile)
        {
            return new ProfileDto
            {
                Experience = profile.Experience,
            };
        }
    }
}