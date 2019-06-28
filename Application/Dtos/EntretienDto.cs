using Application.model;

namespace Application.Dtos
{
    public class EntretienDto
    {
        public CreneauDto Creneau { get; set; }
        public EntretienStatus Status { get; set; }
        public CandidatDto Candidat { get; set; }
        public ConsultantRecruteurDto ConsultantRecruteur { get; set; }
    }
}