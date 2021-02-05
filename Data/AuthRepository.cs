using EsportsProphetAPI.Models;
using EsportsProphetAPI.Security;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Data
{
    public class AuthRepository : IAuthRepository
    {
        private readonly DataContext _context;
        private readonly IPasswordEncryptor _encryptor;

        public AuthRepository(DataContext context, IPasswordEncryptor encryptor)
        {
            _context = context;
            _encryptor = encryptor;
        }

        public async Task<User> Login(string username, string password)
        {
            User u = await _context.Users.FirstOrDefaultAsync(u => u.Username == username);

            if (u == null)
                return null;

            if (!_encryptor.VerifyHash(password, u.PasswordHash, u.PasswordSalt))
                return null;

            return u;
        }

        public async Task<User> Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;

            _encryptor.CreateHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await _context.Users.AnyAsync(u => u.Username == username)) return true;
            else return false;
        }
    }
}
