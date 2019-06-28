namespace Application.model
{
    public class ConsultantRecruteur : Entity
    {
        public string Name {get; set;}
        public Profile Profile { get; set; }

        public bool CanInterview(Profile profile) => Profile.Experience > profile.Experience;

        public bool IsAvailableAt(Creneau creneau) => true;
    }
}
