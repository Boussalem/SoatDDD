using System;
using System.Collections.Generic;
using Application.Dtos;

namespace Application.infrastructure
{
    public interface IConsultantRecruteurRepository
    {
        IEnumerable<ConsultantRecruteurDto> GetAvailableConsultantRecruteurForDate(DateTimeOffset date);
    }
}
