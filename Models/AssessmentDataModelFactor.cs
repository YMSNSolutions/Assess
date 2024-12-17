using Microsoft.AspNetCore.SignalR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Assessment.Models
{
    public class AssessmentDataModelFactor
    {

        #region Master Data

        public class PaymentFrequency
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid PaymentFrequencyID { get; set; }
            public string Description { get; set; }
            public string Event_Type { get; set; }
        }

        public class ProductsType
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid ProductsTypeID { get; set; }
            public string Description { get; set; }
            public string Event_Type { get; set; }
        }

        public class LocalizationValue
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid LocalizationValueID { get; set; }
            public Guid LanguageCultureID { get; set; }

            public string KeyName { get; set; }
            public string Value { get; set; }

            public LanguageCulture LanguageCulture { get; set; }
        }

        public class LanguageCulture
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid LanguageCultureID { get; set; }
            public string CultureNameCode { get; set; }
            public string Description { get; set; }
        }


        #endregion 

        #region UserTable


        //Customer....
        public class User
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid UserID { get; set; }
            public string Password { get; set; }
            public string Title { get; set; }
            public string DisplayName { get; set; }
            public string FirstName { get; set; }
            public string Surname { get; set; }
            public string EmailAddress { get; set; }
            public string CellphoneNumber { get; set; }
            public int LoginTries { get; set; }
            public bool IsSuspended { get; set; }
            public bool IsEmailVerified { get; set; }
            public DateTime CreatedDateTime { get; set; }
        }

        public class LinkUserRole
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid LinkUserRoleID { get; set; }
            public Guid UserRoleID { get; set; }
            public Guid UserID { get; set; }
            public UserRole UserRole { get; set; }
            public User User { get; set; }
        }

        public class UserRole
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid UserRoleID { get; set; }
            public string Description { get; set; }
            public string EventCode { get; set; }
        }

        #endregion

        #region Product Entities
           public class UserProductsInformation
           {
                    [DatabaseGenerated(DatabaseGeneratedOption.None)]
                    public Guid UserProductsInformationID { get; set; }
                    public string Description { get; set; }
                    public DateTime DateOpened { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal AmountLimit { get; set; }
                    public Guid UserID { get; set; }
                    public User User { get; set; }

                    [Column(TypeName = "decimal(18,2)")]
                    public decimal AvailableBalance { get; set; }
                    public Guid ProductsTypeID { get; set; }
                    public ProductsType productsType { get; set; }
           }        

        #endregion

        #region Project Entity

        public class CommunityProjects
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid CommunityProjectsID { get; set; }         
            public string Decription { get; set; }
            [Column(TypeName = "decimal(18,2)")]
            public decimal? TotalFundsRequired { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? TotalFundsRaised { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal SponsoredAmount { get; set; }
            public bool? IsActive { get; set; }
        }
        
        public class ProjectsSponsorTransaction
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid ProjectsSponsorTransactionID { get; set; }
            public string Decription { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? SponsorAmount { get; set; }
            public DateTime TransactionDate { get; set; }

            [Column(TypeName = "decimal(18,2)")]
            public decimal? SponsoredAmount { get; set; }
			public Guid ProductsTypeID { get; set; }
			public ProductsType ProductsType { get; set; }
			public Guid SponsorshipPlanID { get; set; }
			public SponsorshipPlan sponsorshipPlan { get; set; }
        }


        public class SponsorshipPlan
        {
            [DatabaseGenerated(DatabaseGeneratedOption.None)]
            public Guid SponsorshipPlanID { get; set; }
            public string Decription { get; set; }
            public bool? OnceOff { get; set; }
            [Column(TypeName = "decimal(18,2)")]
            public decimal? SponsorAmount { get; set; }
            public DateTime DateActivated { get; set; }
            public Guid? PaymentFrequencyID { get; set; }
            public PaymentFrequency PaymentFrequency { get; set; }
            public bool? IsActive { get; set; }            
            public DateTime DateSuspend { get; set; }
			public Guid UserID { get; set; }
            public User user { get; set; }

		}

        #endregion
    }
}
