using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class LanguageService
    {
        private readonly Context _context;

        public LanguageService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(Language obj)
        {
            _context.Languages.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.Languages.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<Language> FindByIdAsync(int? id)
        {
            return await _context.Languages.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(Language obj)
        {
            bool hasAny = await _context.Languages.AnyAsync(o => o.Id == obj.Id);
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

        public async Task<bool> NameExists(string name)
        {
            if (await _context.Languages.AnyAsync(x => x.Name.ToUpper() == name.ToUpper()))     
                return true;
            return false;
        }
    }
}
