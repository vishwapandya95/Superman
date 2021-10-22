using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Superman.DataModel.Common
{
    /// <summary>
    /// To serialize the data in Json 
    /// </summary>
    public class DynamicContractResolver : DefaultContractResolver
    {
        private string[] PropertiesToSerialize = null;

        public DynamicContractResolver(string[] propertiesToSerialize)
        {
            PropertiesToSerialize = propertiesToSerialize;
        }

        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization).Where(p => !p.Ignored || PropertiesToSerialize.Contains(p.PropertyName)).ToList();
            if (properties != null)
            {
                foreach (JsonProperty property in properties)
                {
                    property.Ignored = false;
                }
            }
            return properties;
        }
    }
}