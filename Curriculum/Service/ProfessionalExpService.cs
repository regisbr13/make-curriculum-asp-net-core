using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class ProfessionalExpService
    {
        private readonly Context _context;

        public ProfessionalExpService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(ProfessionalExp obj)
        {
            _context.ProfessionalExps.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.ProfessionalExps.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<ProfessionalExp> FindByIdAsync(int? id)
        {
            return await _context.ProfessionalExps.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(ProfessionalExp obj)
        {
            bool hasAny = await _context.ProfessionalExps.AnyAsync(o => o.Id == obj.Id);
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
