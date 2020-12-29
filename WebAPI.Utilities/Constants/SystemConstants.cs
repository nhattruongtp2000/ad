using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPI.Utilities.Constants
{
    public class SystemConstants
    {
        public const string MainConnectionString = "WebAPI";
        public const string CartSession = "CartSession";
        public class AppSettings
        {
            public const string DefaultLanguageId = "DefautLanguageId";

            public const string Token = "Token";

            public const string BaseAddress = "BaseAddress";

        }
        public class ProductSettings
        {
            public const int NumberOfFeaturedProducts = 4;
            public const int NumberOfLatestProducts = 6;
        }
        public class ProductConstants
        {
            public const string NA = "N/A";
            public const int NAint = 0;
        }
    }

}
