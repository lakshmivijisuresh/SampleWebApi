using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using SampleWebApi.Models;

namespace SampleWebApi.Service.Interface
{
    public interface ISaveEmployeeDetailsService
    {
        Task<bool> AddUser(UserDetail userDetail);
        Task<UserDetail> GetUser(UserDetail userDetail);
        Task<List<UserDetail>> GetAllUser();

		Task<bool> DeleteUser(UserDetail userDetail);
        Task<UserDetail> UpdateUser(UserDetail userDetail, string email);
	}
}
