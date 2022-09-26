using AspCoreBE.Context;
using AspCoreBE.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspCoreBE.Repositories
{
    public class UserRepository : IRepository<UserModel>
    {
        private readonly WebCoreContext context;

        public UserRepository(WebCoreContext ctx)
        {
            context = ctx;
        }

        public UserModel Add(UserModel data)
        {
            if (data == null) return null;
            var result = context.Users.Add(data);
            context.SaveChanges();
            return result.Entity;
        }

        public void Delete(int id)
        {
            var userToDelete = context.Users.FirstOrDefault(u => u.Id.Equals(id));
            context.Users.Remove(userToDelete);
            context.SaveChanges();
        }

        public UserModel Get(int id)
        {
            return context.Users.FirstOrDefault(u => u.Id.Equals(id));
        }

        public IEnumerable<UserModel> Get()
        {
            return context.Users;
        }

        public UserModel Update(UserModel data)
        {
            var foundUser = context.Users.FirstOrDefault(u => u.Id.Equals(data.Id));
            if (foundUser == null) return null;

            context.Entry<UserModel>(foundUser).CurrentValues.SetValues(data);
            context.SaveChanges();
            return data;
        }
    }
}
