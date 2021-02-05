using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsProphetAPI.Security
{
    public interface IPasswordEncryptor
    {
        /// <summary>
        /// Generates <paramref name="passwordSalt"/> and hashes <paramref name="password"/>.
        /// </summary>
        void CreateHash(string password, out byte[] passwordHash, out byte[] passwordSalt);
        /// <summary>
        /// Hashes <paramref name="password"/> and checks if it matches <paramref name="passwordHash"/>
        /// </summary>
        bool VerifyHash(string password, byte[] passwordHash, byte[] passwordSalt);
    }
}
