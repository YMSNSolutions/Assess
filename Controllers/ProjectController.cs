using Assessment.Models;
using Assessment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Data;
using static Assessment.Models.AssessmentDataModelFactor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assessment.Controllers
{


	[ApiController]
	[Route("[controller]")]
	public class ProjectController : ControllerBase
	{
		private readonly AppDBContext _context;
		private readonly SecurityOptions _securityOptions;


		public ProjectController(AppDBContext context, IOptions<SecurityOptions> securityOptions)
		{
			_context = context;
			_securityOptions = securityOptions.Value;
		}

		/// List the payments that have already been made per sponsorship plan <summary>
		/// List the payments that have already been made per sponsorship plan
		/// </summary>
		/// <param name="ProjectID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("/GetProjectDetails")]
		public List<CommunityProjects> Get(Guid ProjectID)
		{

			var proj = from x in _context.CommunityProject
					   where x.CommunityProjectsID == ((ProjectID != Guid.Empty) ? x.CommunityProjectsID : ProjectID)
					   select new CommunityProjects
					   {
						   Decription = x.Decription,
						   StartDate = x.StartDate,
						   EndDate = x.EndDate,
						   TotalFundsRequired = x.TotalFundsRequired,
						   TotalFundsRaised = x.TotalFundsRaised
					   };

			return proj.ToList();
	
		}


	}

}
