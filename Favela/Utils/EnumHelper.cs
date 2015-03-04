

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Favela.Library.Utils
{
	public static class EnumHelper
	{
		#region GeneratedCode

		public static T FromInt<T>(int value)
		{
			return EnumHelper.FromString<T>(Convert.ToString(value));
		}

		public static T FromString<T>(string value)
		{
			return (T) Enum.Parse(typeof(T), value);
		}

		#endregion GeneratedCode
	}
}
