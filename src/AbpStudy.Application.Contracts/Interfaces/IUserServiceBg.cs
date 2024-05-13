using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AbpStudy.Interfaces
{
    public interface IUserServiceBg
    {
        Task CreateUserAsync(string userName, string emailAddress);
    }
}
