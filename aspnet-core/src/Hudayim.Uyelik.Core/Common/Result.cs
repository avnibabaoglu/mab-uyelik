using System.Collections.Generic;
using System.Linq;

namespace Hudayim.Uyelik.Common
{
	public class Result
	{
		public Result()
		{
			Messages = new List<string>();
		}
		public bool Success { get; set; }

		public List<string> Messages { get; set; }

		public string Message
		{
			get
			{
				return Messages.FirstOrDefault();
			}

			set
			{
				Messages.Add(value);
			}
		}
	}

	public class Result<T> : Result
	{
		public T Data { get; set; }
	}
}
