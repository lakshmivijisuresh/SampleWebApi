using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SampleWebApi.Controllers;
using SampleWebApi.Models;
using SampleWebApi.Service.Interface;

namespace SampleWebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserDetailsController : ControllerBase
	{
		private readonly ISaveEmployeeDetailsService _saveEmployeeDetails;


		public UserDetailsController(ISaveEmployeeDetailsService saveEmployeeDetails)
		{
			_saveEmployeeDetails = saveEmployeeDetails;
		}

		[Route("AddUser")]
		[HttpPost]

		public async Task<IActionResult> saveEmployeeDetails(UserDetail employeeDetail)
		{
			try
			{
				var requestStatus = await _saveEmployeeDetails.AddUser(employeeDetail);

				if (requestStatus == false)
				{
					return BadRequest();
				}


				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message, Type = ex.GetType().ToString() });
			}
		}

		[Route("CheckUser")]
		[HttpPost]

		public async Task<IActionResult> CheckValidUserAsync(UserDetail userDetail)
		{
			var isValidUser = await _saveEmployeeDetails.GetUser(userDetail);

			if (isValidUser == null)
			{
				return BadRequest();
			}

			return Ok();
		}


		[Route("GetUser")]
		[HttpGet]

		public async Task<IActionResult> GetUserDetails()
		{
			try
			{
				var allUsers = await _saveEmployeeDetails.GetAllUser();

				if (allUsers == null)
				{
					return BadRequest();
				}

				return Ok(allUsers);
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message, Type = ex.GetType().ToString() });
			}
		}


		[Route("UpdateUser/{Email}")]
		[HttpPut]
		public async Task<IActionResult> ResetEmail([FromRoute] string Email, [FromBody] UserDetail request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest();
			}
			try
			{
				var resetStatus = await _saveEmployeeDetails.UpdateUser(request, Email);
				if (resetStatus.UserId == 0)
				{
					return Unauthorized();
				}

				return Ok();
			}
			catch (Exception ex)
			{
				return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message, Type = ex.GetType().ToString() });
			}
		}

		//[Route("DeleteUser")]
		//[HttpDelete]
		//public async Task<IActionResult> DeleteEmployeeDetails(UserDetail userDetail)
		//{
		//try
		//{
		//	var requestResult = await _EmployeeDetailsService.DeleteEmployeeDetailsAsync(userDetail);
		//if (requestResult == false)
		//{
		// BadRequest();
		//}
		//return Ok();
		//}
		//catch (Exception ex)
		//{
		//	return StatusCode(StatusCodes.Status500InternalServerError, new { ex.Message, Type = ex.GetType().ToString() });
		//}
		//}
	}

}

