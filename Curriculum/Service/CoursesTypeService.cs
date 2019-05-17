using MakeCurriculum.Data;
using MakeCurriculum.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class CoursesTypeService
    {
        private readonly Context _context;

        public CoursesTypeService(Context context)
        {
            _context = context;
        }

        // Listar todos:
        public async Task<List<CoursesType>> FindAllAsync()
        {
            return await _context.CoursesTypes.ToListAsync();
        }
    }
}
