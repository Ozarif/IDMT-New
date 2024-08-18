using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Infrastructure.Utilities
{
	public sealed class HelperFunctions
	{
		public static async Task<Expression<Func<T, object>>> GetSortExpressionAsync<T>(string propertyName)
		{
			var parameter = Expression.Parameter(typeof(T), "x");
			var property = Expression.Property(parameter, propertyName);
			var lambda = Expression.Lambda<Func<T, object>>(
				Expression.Convert(property, typeof(object)), parameter);

			return lambda;
		}
	}
}
