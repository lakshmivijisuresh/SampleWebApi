using Microsoft.EntityFrameworkCore;
using SampleWebApi.Models;
using SampleWebApi.Service.Interface;
using static SampleWebApi.Service.SaveEmployeeDetailsService;

namespace SampleWebApi.Service
{
	public class SaveEmployeeDetailsService : ISaveEmployeeDetailsService
	{
		private readonly StuffKartContext _context;
		private object userDetail;

		public SaveEmployeeDetailsService(StuffKartContext context)
		{
			_context = context;
		}

		public async Task<bool> AddUser(UserDetail userDetail)
		{
			_context.UserDetails.Add(userDetail);

			await _context.SaveChangesAsync();

			return true;
		}

		public async Task<UserDetail> GetUser(UserDetail userDetail)
		{
			var validUser = _context.UserDetails.FirstOrDefault(x => x.Email == userDetail.Email && x.Password == userDetail.Password);

			return validUser;
		}
		
		public async Task<List<UserDetail>> GetAllUser()
		{
			var allUser = _context.UserDetails.ToList();

			return allUser;
		}



		public async Task<bool> DeleteUser(UserDetail userDetail)
		{
			var allUser = _context.UserDetails.ToList();
			allUser.Remove(userDetail);

			await _context.SaveChangesAsync();
			return true;
		}



		public async Task<UserDetail> UpdateUser(UserDetail userDetail, string email)
		{
			var allUser = _context.UserDetails.FirstOrDefault(x => x.Email == email);
			allUser.Email = userDetail.Email;

			await _context.SaveChangesAsync();
			//allUser.Update(userDetail);
			return allUser;

		}
	}
}

