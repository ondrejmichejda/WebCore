using AspCoreBE.Repositories.User;

namespace AspCoreBE.Repositories.Wrapper
{
    public interface IRepositoryWrapper
    {
        IUserRepository Users { get; }

        // + another repo

        void Save();
    }
}
