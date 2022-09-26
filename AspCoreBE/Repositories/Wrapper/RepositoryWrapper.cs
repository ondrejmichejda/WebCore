using AspCoreBE.Context;
using AspCoreBE.Repositories.User;

namespace AspCoreBE.Repositories.Wrapper
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly WebCoreContext context;

        private IUserRepository? users;

        public IUserRepository Users
        {
            get
            {
                if(users == null)
                {
                    users = new UserRepository(context);
                }
                return users;
            }
        }

        public RepositoryWrapper(WebCoreContext context)
        {
            this.context = context;
        }

        public void Save()
        {
            context.SaveChanges();
        }
    }
}
