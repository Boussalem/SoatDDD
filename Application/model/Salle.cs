namespace Application.model
{
    public class Salle
    {
        public string Name { get; set; }

        public bool IsAvailableAt(Creneau creneau) => true;
    }
}