using MakeCurriculum.Data;
using MakeCurriculum.Models;
using MakeCurriculum.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakeCurriculum.Service
{
    public class UserService
    {
        private readonly Context _context;

        public UserService(Context context)
        {
            _context = context;
        }

        // Listar todos:
        public async Task<List<User>> FindAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        // Buscar por Id:
        public async Task<User> FindByIdAsync(int? id)
        {
            return await _context.Users.FirstOrDefaultAsync(t => t.Id == id);
        }

        // INSERIR:
        public async Task InsertAsync(User obj)
        {
            _context.Users.Add(obj);
            await _context.SaveChangesAsync();
        }

        // Atualizar:
        public async Task UpdateAsync(User obj)
        {
            bool hasAny = await _context.Users.AnyAsync(t => t.Id == obj.Id);
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
            var obj = await _context.Users.FindAsync(id);
            _context.Remove(obj);
            await _context.SaveChangesAsync();

        }

        // USUARIO EXISTE:
        public async Task<bool> HasAny(LoginViewModel viewModel)
        {
            return await _context.Users.AnyAsync(u => u.Email == viewModel.Email && u.Password == viewModel.Password);
        }

        // Email EXISTE:
        public async Task<bool> HasAnyEmail(User user)
        {
            return await _context.Users.AnyAsync(u => u.Email == user.Email);
        }

        // ID DO USUARIO:
        public int UserId(LoginViewModel viewModel)
        {
            return _context.Users.Where(u => u.Email == viewModel.Email && u.Password == viewModel.Password).Select(u => u.Id).Single();
        }
    }
}
