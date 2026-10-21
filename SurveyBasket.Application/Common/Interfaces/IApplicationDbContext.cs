using Microsoft.EntityFrameworkCore;
using SurveyBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    public DbSet<Poll> Polls { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
