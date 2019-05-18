using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class ExtraActivityService
    {
        private readonly Context _context;

        public ExtraActivityService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(ExtraActivity obj)
        {
            _context.ExtraActivities.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ExtraActivities.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<ExtraActivity> FindByIdAsync(int? id)
        {
            return await _context.ExtraActivities.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(ExtraActivity obj)
        {
            bool hasAny = await _context.ExtraActivities.AnyAsync(o => o.Id == obj.Id);
            if (!hasAny)
            {
                throw new Exception("not found");
            }
            try
            {
                _context.Update(obj);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
    }
}
