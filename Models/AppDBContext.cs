
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using static Assessment.Models.AssessmentDataModelFactor;

namespace Assessment.Models
{
    public class AppDBContext : IdentityDbContext
    {     

        #region Master Data

        public DbSet<PaymentFrequency> PaymentFrequencies { get; set; }
        public DbSet<ProductsType> ProductsTypes { get; set; }
        public DbSet<LocalizationValue> LocalizationValues { get; set; }
        public DbSet<LanguageCulture> LanguageCultures { get; set; }

        #endregion

        #region UserTable
        public DbSet<User> Users { get; set; }
        public DbSet<LinkUserRole> LinkUserRole { get; set; }
        public DbSet<UserRole> UserRole { get; set; }

        #endregion

        #region Product Entities
        public DbSet<UserProductsInformation> UserProductsInformation { get; set; }      
        #endregion

        #region Project Entity
        public DbSet<CommunityProjects> CommunityProject { get; set; }  
        public DbSet<ProjectsSponsorTransaction> ProjectsSponsorTransactions { get; set; }  
        public DbSet<SponsorshipPlan> SponsorshipPlan { get; set; }  
        #endregion      

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

		}
	}
}
