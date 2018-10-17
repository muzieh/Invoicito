using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
	public class Repository<T> where T : AggregateRoot
	{
		public T GetById(long id)
		{
			return default(T);
		}
	}
}
