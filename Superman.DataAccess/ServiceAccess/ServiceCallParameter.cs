using System;
using System.Collections.Generic;
using System.Text;

namespace TimingApp.DataAccess.ServiceAccess
{
    public class ServiceCallParameter
    {
        public string Key { get; set; }
        public string Value { get; set; }

        public ServiceCallParameter(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public ServiceCallParameter(string key, int value)
        {
            Key = key;
            Value = value.ToString();
        }

        public ServiceCallParameter(string key, decimal value)
        {
            Key = key;
            Value = value.ToString();
        }
        public ServiceCallParameter(string key, DateTime value)
        {
            Key = key.ToString();

            Value = value.ToString("yyyy-MM-dd h:mm tt");
        }
    }
}
