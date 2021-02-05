using System.Reflection.Metadata;
using EsportsProphetAPI.Models;

namespace EsportsProphetAPI.Security
{
    public interface ITokenGenerator
    {
         string GetTokenString(User user);
    }
}