using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Core.DataAccess.Eframework.Concrete;
using TaskManager.DataAccess.Abstract;
using TaskManager.Entities.Concrete;
using TaskManager.Entities.Dto;

namespace TaskManager.DataAccess.Concrete.Eframework
{
    public class RefreshTokenDal : EfRepository<RefreshToken, Context>, IRefreshTokenDal
    {
        public bool IsRefreshToken(string token)
        {
            using (var context = new Context())
            {
                var refreshToken =  context.RefreshTokens.Any(x => x.Token == token);
                return refreshToken;
            }
        }

        public bool RefreshTokenSave(RefreshToken token)
        {
            using (var context = new Context())
            {
                context.RefreshTokens.Add(token);
                context.SaveChangesAsync();
                return true;
            }
        }

        //public NewRefreshToken UserRefreshToken(NewRefreshToken token)
        //{
        //    using (var context = new Context())
        //    {
        //        var refreshToken = context.RefreshTokens.Where(x => x.Token == token.Token && x.ExpirationDate >= DateTime.Now).FirstOrDefault();
        //        return refreshToken;
        //    }
        //}
    }
}
