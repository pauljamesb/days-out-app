using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DOA.Data;
using DOA.Models;

namespace DOA.Services
{

    public class DayService : IDayService
    {

        private readonly ApplicationDbContext _db;
        public DayService(ApplicationDbContext db)
        {
            _db = db;
        }


        public async Task<Day[]> GetIncompleteItemsAsync()
        {
            var days = await _db.AllDays.ToArrayAsync();
            return days;
        }

    }



}
