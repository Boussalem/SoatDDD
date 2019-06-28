using Application.model;
using System;
using System.Collections.Generic;

namespace Application.infrastructure
{
    public interface IConsultantRecruteurRepository
    {
        IEnumerable<ConsultantRecruteur> GetAvailableConsultantRecruteurForDate(DateTimeOffset date);
    }
}
