using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class CurriculumService
    {
        private readonly Context _context;

        public CurriculumService(Context context)
        {
            _context = context;
        }

        // Listar todos:
        public async Task<List<Curriculum>> FindAllAsync()
        {
            return await _context.Curriculums.ToListAsync();
        }

        // Buscar por Id:
        public async Task<Curriculum> FindByIdAsync(int? id)
        {
            return await _context.Curriculums.FirstOrDefaultAsync(t => t.Id == id);
        }

        // INSERIR:
        public async Task InsertAsync(Curriculum obj)
        {
            _context.Curriculums.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Atualizar:
        public async Task UpdateAsync(Curriculum obj)
        {
            bool hasAny = await _context.Curriculums.AnyAsync(t => t.Id == obj.Id);
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

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Curriculums.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();

        }
    }
}
