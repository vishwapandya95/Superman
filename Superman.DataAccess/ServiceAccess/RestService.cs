using Newtonsoft.Json;
using Superman.DataModel.BusinessModel;
using Superman.DataModel.Common;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using TimingApp.DataAccess.ServiceAccess;

namespace Superman.DataAccess.ServiceAccess
{
   public class RestService<T>
   {
        private readonly GenericServiceCall clientHelper;
        public RestService()
        {
            clientHelper = new GenericServiceCall(string.Concat(ConstantFile.SupermanApiBaseUrl));
        }
     

        //public async Task<LoginResponseModel> Login(LoginRequestModel model)
        //{
        //    try
        //    {
        //        var response = await this.clientHelper.CallGet(ConstantFile.TimingAppBaseUrl + ConstantFile.Login+model.MobileNumber);
        //        if (!string.IsNullOrEmpty(response))
        //        {
        //            var responsedata = JsonConvert.DeserializeObject<LoginResponseModel>(response);                  
        //            return responsedata;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        return null;
        //    }
        //}

    }
}
