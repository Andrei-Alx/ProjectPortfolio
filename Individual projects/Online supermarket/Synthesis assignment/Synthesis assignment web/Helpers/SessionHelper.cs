using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Logic
{
    public static class SessionHelper
    {
		public static void SetObjectAsJson(this ISession session, string key, List<OrderProduct> value)
		{
			session.SetString(key, JsonSerializer.Serialize(value));
		}

		public static List<OrderProduct>? GetObjectFromJson(this ISession session, string key)
		{
			var value = session.GetString(key);
			return value == null ? default : JsonSerializer.Deserialize<List<OrderProduct>>(value);
		}
	}
}
