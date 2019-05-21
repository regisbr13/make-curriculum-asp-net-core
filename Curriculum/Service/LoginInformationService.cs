using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class LoginInformationService
    {
        private readonly Context _context;

        public LoginInformationService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(LoginInformation obj)
        {
            _context.Add(obj);
            await _context.SaveChangesAsync();
        }

        public async Task<List<LoginInformation>> LoginInformationByUserId(int? id)
        {
            return await _context.LoginInformations.Include(li => li.User).Where(li => li.UserId == id).OrderByDescending(li => li.LoginDate).ToListAsync();
        }
    }
}
