namespace Application.model
{
    public class Salle : Entity
    {
        public string Name { get; set; }

        public bool IsAvailableAt(Creneau creneau) => true;
    }
}