using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DOA.Models;

namespace DOA.Services
{
    public interface IDayService
    {
        Task<Day[]> GetIncompleteItemsAsync();
    }
}
