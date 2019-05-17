using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class AcademicService
    {
        private readonly Context _context;

        public AcademicService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(Academic obj)
        {
            _context.Academics.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Formações acadêmicas por Curriculum:
        public async Task<List<Academic>> FindByCurriculumId(int? id)
        {
            return await _context.Academics.Where(o => o.CurriculumId == id).ToListAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Academics.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<Academic> FindByIdAsync(int? id)
        {
            return await _context.Academics.Include(o => o.CoursesType).FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(Academic obj)
        {
            bool hasAny = await _context.Academics.AnyAsync(o => o.Id == obj.Id);
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
