using AspCoreBE.Context;
using AspCoreBE.Models;
using AspCoreBE.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreBE.Repositories.User
{
    public class UserRepository : RepositoryBase<UserModel>, IUserRepository
    {
        public UserRepository(WebCoreContext ctx):base(ctx)
        {
        }
    }
}
