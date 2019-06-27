using System;
using System.Collections.Generic;
using Application.model;
using Application.use_case.entretien;

namespace Application.infrastructure
{
    public interface ISalleRepository
    {
        IEnumerable<Salle> Get(DateTimeOffset date);
    }
}