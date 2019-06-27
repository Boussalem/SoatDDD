using System;
using System.Collections.Generic;
using System.Text;

namespace Application.model
{
    public class Entretien
    {
        public DateTime DateEntretien { get; set; }

        public string  Status { get; set; }

        public ConsultantRecruteur ConsultantRecruteur { get; set; }
    }
}
