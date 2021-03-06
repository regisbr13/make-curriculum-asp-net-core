﻿using MakeCurriculum.Data;
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
        public async Task<List<Curriculum>> FindAllAsync(int? id)
        {
            return await _context.Curriculums.Where(c => c.UserId == id).ToListAsync();
        }

        // Buscar por Id:
        public async Task<Curriculum> FindByIdAsync(int? id)
        {
            return await _context.Curriculums.Include(c => c.PersonalData).Include(c => c.Resume).Include(c => c.Objectives).Include(c => c.Academics).ThenInclude(a => a.CoursesType).Include(c => c.ProfessionalExps).Include(c => c.ExtraActivities).Include(c => c.Languages).FirstOrDefaultAsync(t => t.Id == id);
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

        // Currículo já cadastrado:
        public async Task<bool> HasName(Curriculum obj, int userId)
        {
            if (await _context.Curriculums.Where(c => c.UserId == userId).AnyAsync(x => x.Name.ToUpper() == obj.Name.ToUpper()))         
                return true;
            return false;
        }
    }
}
