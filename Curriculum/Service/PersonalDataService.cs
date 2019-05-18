using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class PersonalDataService
    {
        private readonly Context _context;

        public PersonalDataService(Context context)
        {
            _context = context;
        }

        public async Task InsertAsync(PersonalData obj)
        {
            _context.PersonalDatas.Add(obj);
            await _context.SaveChangesAsync();
        }

        // REMOVER:
        public async Task RemoveAsync(int id)
        {
            var obj = await _context.PersonalDatas.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();
        }

        // Buscar por Id:
        public async Task<PersonalData> FindByIdAsync(int? id)
        {
            return await _context.PersonalDatas.FirstOrDefaultAsync(o => o.Id == id);
        }


        // Atualizar:
        public async Task UpdateAsync(PersonalData obj)
        {
            bool hasAny = await _context.PersonalDatas.AnyAsync(o => o.Id == obj.Id);
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
