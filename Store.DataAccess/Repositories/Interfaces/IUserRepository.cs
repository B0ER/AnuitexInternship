using Store.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.DataAccess.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<ApplicationUser>
    {
        void AddRole(Role roleUser);
        void DeleteRole(Role roleUser);

        //todo: add authentification method
    }
}
