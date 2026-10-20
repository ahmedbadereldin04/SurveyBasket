using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Domain.Entities;

public class Poll
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
