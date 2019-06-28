namespace Application.model
{
    public class Profile
    {
        private Profile()
        { }

        public Profile(int experience)
        {
            Experience = experience;
        }

        public int Experience { get; }
    }
}