using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels.Services
{
    internal class JsonService<T> where T : class
    {
        public static string ToJson(T entity)
        {
            string json = string.Empty;

            if(entity != null)
            {
                json = JsonConvert.SerializeObject(entity);
            }

            return json;
        }

        public static T FromJson(string json)
        {
            T entity = null;

            if(json != null && !string.IsNullOrEmpty(json))
            {
                entity = JsonConvert.DeserializeObject<T>(json);
            }


            return entity;
        }
    }
}
