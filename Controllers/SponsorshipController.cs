using Assessment.Models;
using Assessment.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Numerics;
using static Assessment.Models.AssessmentDataModelFactor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Assessment.Controllers
{

	[ApiController]
	[Route("[controller]")]

	public class SponsorshipController : ControllerBase
	{
		private readonly AppDBContext _context;
		private readonly SecurityOptions _securityOptions;


		public SponsorshipController(AppDBContext context, IOptions<SecurityOptions> securityOptions)
		{
			_context = context;
			_securityOptions = securityOptions.Value;
		}



		///List the sponsorship plans that a customer has created <summary>
		/// List the sponsorship plans that a customer has created
		/// </summary>
		/// <param name="UserID"></param>
		/// <returns></returns>
		[HttpGet]
		[Route("/GetCustomerSponsorshipPlan")]
		public List<SponsorshipPlan> GetCustomerSponsorshipPlan(Guid UserID)
		{

			var proj = from x in _context.SponsorshipPlan.Include( x=>x.user).Include(x=>x.PaymentFrequency)
					   where x.UserID == ((UserID != Guid.Empty) ? x.UserID : UserID)
					   select new SponsorshipPlan
					   {
						   SponsorshipPlanID = x.SponsorshipPlanID,
						   Decription = x.Decription,
						   user = x.user,
						   OnceOff = x.OnceOff,
						   SponsorAmount = x.SponsorAmount,
						   DateActivated = x.DateActivated,
						   PaymentFrequency = x.PaymentFrequency,
						   IsActive = x.IsActive,
						   DateSuspend = x.DateSuspend
					   };

			return proj.ToList();

		}



		/// List the payments that have already been made per sponsorship plan <summary>
		/// List the payments that have already been made per sponsorship plan
		/// </summary>
		/// <param name="SponsorshipPlanID"></param>
		/// <returns></returns>

		[HttpGet]
		[Route("/GetPaymentAlreadyMadePerSponsorshipPlan")]
		public List<ProjectsSponsorTransaction> GetPaymentAlreadyMadePerSponsorshipPlan(Guid SponsorshipPlanID)
		{

			var proj = from x in _context.ProjectsSponsorTransactions.Include(x => x.sponsorshipPlan)
					   where x.SponsorshipPlanID == ((SponsorshipPlanID != Guid.Empty) ? x.SponsorshipPlanID : SponsorshipPlanID)
					   select new ProjectsSponsorTransaction
					   {
						   ProjectsSponsorTransactionID = x.ProjectsSponsorTransactionID,
						   Decription = x.Decription,
						   SponsorAmount = x.SponsorAmount,
						   TransactionDate = x.TransactionDate,
						   ProductsType = x.ProductsType,
						   sponsorshipPlan = x.sponsorshipPlan,

					   };

			return proj.ToList();

		}


		/// Create a sponsorship plan, <summary>
		/// Create a sponsorship plan,
		/// </summary>
		/// <param name="SponsorshipPlanID"></param>
		/// <returns></returns>

		[HttpPost]
		[Route("/CreateSponsorshipPlan")]
		public bool CreateSponsorshipPlan(SponsorshipPlan Plan_)
		{


			if (Plan_ != null)
			{

				SponsorshipPlan newpla = new SponsorshipPlan();

				newpla.SponsorshipPlanID = Guid.NewGuid();
				newpla.DateActivated = DateTime.Now;
				newpla.OnceOff = Plan_.OnceOff;
				newpla.SponsorAmount = Plan_.SponsorAmount;
				newpla.PaymentFrequency = Plan_.PaymentFrequency;
				newpla.IsActive = Plan_.IsActive;
				newpla.UserID = Plan_.UserID;


				_context.SponsorshipPlan.Add(newpla);

				_context.SaveChanges();

				return true;
			}
			else
			{ return false; }


		}

		/// Create a sponsorship plan, <summary>
		/// Process the payment initiated, either on an immediate basis or on a scheduled frequency as stated in the
		/// </summary>
		/// <param name="SponsorshipPlanID"></param>
		/// <returns></returns>

		[HttpPost]
		[Route("/ProcessPayment")]
		public bool ProcessPayment(ProjectsSponsorTransaction Plan_)
		{


			if (Plan_ != null)
			{

				ProjectsSponsorTransaction newpla = new ProjectsSponsorTransaction();

				newpla.ProjectsSponsorTransactionID = Guid.NewGuid();
				newpla.Decription = Plan_.Decription;
				newpla.SponsorAmount = Plan_.SponsorAmount;
				newpla.TransactionDate = Plan_.TransactionDate;

				newpla.ProductsTypeID = Plan_.ProductsTypeID;

				newpla.SponsorshipPlanID = Plan_.SponsorshipPlanID;

				_context.ProjectsSponsorTransactions.Add(newpla);

				_context.SaveChanges();

				return true;
			}
			else
			{ return false; }


		}



	}
}
