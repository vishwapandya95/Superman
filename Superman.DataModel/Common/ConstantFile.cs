using System;
using System.Collections.Generic;
using System.Text;

namespace Superman.DataModel.Common
{
   public class ConstantFile
   {
        public static string SupermanApiBaseUrl = "";
        public static string ConnectivityError = "Please check your internet connection.";

        public static readonly string Login = "Login?PhoneNumber=";
        public static readonly string SaveUserImage = "SaveUserProfile";
        public static readonly string SaveCustomerDetails = "SaveCustomerDetails";
        public static readonly string GetUserImage = "GetImage?PhoneNumber=";
        public static readonly string UpdateCustomerDetails = "UpdateCustomerDetails";



   }
}
