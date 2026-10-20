using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Contracts.Polls;

public record PollResponse(
    int Id,
    string Title,
    string Description
//string Summary,
//bool IsPublished,
//DateOnly StartsAt,        
//DateOnly EndsAt
);
