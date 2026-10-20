using SurveyBasket.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SurveyBasket.Application.Interfaces;

public interface IPollService
{
    IEnumerable<Poll> GetAll();
    Poll? Get(int id);
    Poll Add(Poll poll);
    bool Update(int id, Poll poll);
    bool Delete(int id);
}