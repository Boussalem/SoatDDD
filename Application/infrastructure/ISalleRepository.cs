using System;
using System.Collections.Generic;
using Application.Dtos;
using Application.model;

namespace Application.infrastructure
{
    public interface ISalleRepository
    {
        IEnumerable<SalleDto> Get(DateTimeOffset date);
    }
}