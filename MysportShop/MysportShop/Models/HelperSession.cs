using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MysportShop.Models
{
    public static class HelperSession
    {
        public static void SetJson(this ISession session,string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }
        public static T GetJson<T>(this ISession session, string key)
        {
            var sessiondata = session.GetString(key);
            return sessiondata == null ? default(T) : JsonConvert.DeserializeObject<T>(sessiondata);
        }
    }
}
