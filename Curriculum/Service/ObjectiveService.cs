using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class ObjectiveService
    {
        private readonly Context _context;

        public ObjectiveService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(Objective obj)
        {
            _context.Objectives.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Objectives.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<Objective> FindByIdAsync(int? id)
        {
            return await _context.Objectives.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(Objective obj)
        {
            bool hasAny = await _context.Objectives.AnyAsync(o => o.Id == obj.Id);
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
