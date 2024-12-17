using Assessment.ViewModels;
using Functions;
using static Assessment.Models.AssessmentDataModelFactor;

namespace Assessment.Models
{
    public static class InitializingDatabase
    {
        public static void Initialize(AppDBContext context, SecurityOptions securityOptions)
        {
            AddPaymentFrequency(context, securityOptions);
            AddProductsTypes(context, securityOptions);
            AddInitialUserAccounts(context, securityOptions);

        }

        #region Assement Seeding

        public static void AddPaymentFrequency(AppDBContext context, SecurityOptions securityOptions)
        {
            bool itemAdded = false;

            if (context.PaymentFrequencies.Any(x => x.Event_Type == "ONCE_OFF") == false)
            {
                context.PaymentFrequencies.Add(new PaymentFrequency { Description = "Once Off", Event_Type = "ONCE_OFF", PaymentFrequencyID = Guid.NewGuid() });
                itemAdded = true;
            }

            if (context.PaymentFrequencies.Any(x => x.Event_Type == "WEEKLY") == false)
            {
                context.PaymentFrequencies.Add(new PaymentFrequency { Description = "Weekly", Event_Type = "WEEKLY", PaymentFrequencyID = Guid.NewGuid() });
                itemAdded = true;
            }

            if (context.PaymentFrequencies.Any(x => x.Event_Type == "MONTHLY") == false)
            {
                context.PaymentFrequencies.Add(new PaymentFrequency { Description = "Monthly", Event_Type = "MONTHLY", PaymentFrequencyID = Guid.NewGuid() });
                itemAdded = true;
            }

            if (itemAdded)
            {
                context.SaveChanges();
            }
        }

        public static void AddProductsTypes(AppDBContext context, SecurityOptions securityOptions)
        {
            bool itemAdded = false;

            if (context.ProductsTypes.Any(x => x.Event_Type == "Card") == false)
            {
                context.ProductsTypes.Add(new ProductsType { Description = "Card", Event_Type = "Card", ProductsTypeID = Guid.NewGuid() });
                itemAdded = true;
            }

            if (context.ProductsTypes.Any(x => x.Event_Type == "Account") == false)
            {
                context.ProductsTypes.Add(new ProductsType { Description = "Account", Event_Type = "Account", ProductsTypeID = Guid.NewGuid() });
                itemAdded = true;
            }
                   
            if (itemAdded)
            {
                context.SaveChanges();
            }
        }


        private static void AddInitialUserAccounts(AppDBContext context, SecurityOptions securityOptions)
        {
            if (context.Users.Any() == false)
            {

                //Guid Prov_ = context.Provinces.Where(a => a.EventCode == "PROV_GAUTENG").FirstOrDefault().ProvinceID;

                string password = "password";
                string hashedPassword = HashProvider.ComputeHash(password, HashProvider.HashAlgorithmList.SHA256, securityOptions.PasswordSalt);

                User[] users = new User[]
                {
                    new User
                    {
                        Title = "Mr",
                        DisplayName = "Phumudzo Mamphaga",
                        FirstName = "Phumudzo",
                        Surname = "Mampphaga",
                        CellphoneNumber = "072 893 0836",
                        EmailAddress = "phumudzom@sourceworx.co.za",
                        Password = hashedPassword,
                        UserID = Guid.NewGuid(),
                        CreatedDateTime = DateTime.Now,
                        IsSuspended = false,        
                    }

                };

                foreach (User s in users)
                {
                    context.Users.Add(s);
                }
                  

               context.SaveChanges();
            }
        }

        #endregion
    }
}
