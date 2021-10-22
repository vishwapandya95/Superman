using Newtonsoft.Json;
using Superman.DataModel.Common;
using System;
using System.Collections.Generic;
using System.Text;
using Superman.DataModel.Common;

namespace Superman.DataModel.BusinessModel
{
    public class SupermaneBase
    {
        /// <summary>
        /// To serialize the data which will pass when api will be called.
        /// </summary>
        /// <param name="Serialize"></param>
        /// <returns></returns>
        public string Serialize(params string[] includedProperties)
        {
            try
            {
                DynamicContractResolver contractResolver = new DynamicContractResolver(includedProperties);
                JsonSerializerSettings serializerSettings = new JsonSerializerSettings();
                serializerSettings.ContractResolver = contractResolver;
                serializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.Objects;
                string s = Newtonsoft.Json.JsonConvert.SerializeObject(this, Newtonsoft.Json.Formatting.Indented, serializerSettings);
                return s;
            }
            catch (Exception e)
            {
                throw;
            }

        }
    }
}
