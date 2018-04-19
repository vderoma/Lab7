using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Matrix.Models;
using Microsoft.EntityFrameworkCore;

namespace Matrix.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public async void Add<T>(T entity) where T : class
        {
            await _context.AddAsync(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.userID == id);
            user.Photos.Append(await _context.Photos.SingleOrDefaultAsync(p => p.UserId == user.userID));
            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            foreach (User x in users)
            {
                x.Photos.Append(await _context.Photos.SingleOrDefaultAsync(p => p.UserId == x.userID));
            }
            return users;
        }

        public async Task<bool> SaveAll()
        {
            var numberSaved = await _context.SaveChangesAsync();
            return numberSaved > 0;
        }
        
        Task<IEnumerable<User>> IUserRepository.GetUsers()
        {
            throw new NotImplementedException();
        }
        Task<User> IUserRepository.GetUser(int id)
        {
            throw new NotImplementedException();
        }
    }
}
