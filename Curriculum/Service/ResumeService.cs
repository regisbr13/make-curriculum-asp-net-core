using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class ResumeService
    {
        private readonly Context _context;

        public ResumeService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(Resume obj)
        {
            _context.Resumes.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Resumes.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<Resume> FindByIdAsync(int? id)
        {
            return await _context.Resumes.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(Resume obj)
        {
            bool hasAny = await _context.Resumes.AnyAsync(o => o.Id == obj.Id);
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
