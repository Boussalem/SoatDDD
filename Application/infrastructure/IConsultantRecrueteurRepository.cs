using Application.model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.infrastructure
{
    public interface IConsultantRecrueteurRepository
    {
        List<ConsultantRecruteur> GetAvailableConsultantRecruteurForDate(DateTime date);
    }
}
