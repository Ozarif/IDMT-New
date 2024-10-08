﻿using IDMT.Domain.Abstractions;
using IDMT.Domain.Abstractions.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Infrastructure.Specification
{
	public sealed class SpecificationEvaluator<TEntity> where TEntity : Entity
	{
		public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> specification)
		{
			var query = inputQuery;

			if (specification.IsSplitQuery)
			{
				query = query.AsSplitQuery();
			}

			if (specification.Criteria != null)
			{
				query = query.Where(specification.Criteria);
			}

			if (specification.OrderBy != null)
			{
				query = query.OrderBy(specification.OrderBy);
			}

			if (specification.OrderByDescending != null)
			{
				query = query.OrderByDescending(specification.OrderByDescending);
			}

			if (specification.IsPagingEnabled)
			{
				query = query.Skip(specification.Skip).Take(specification.Take);
			}

			query = specification.Includes.Aggregate(query, (current, include) => current.Include(include));

			return query;
		}
	}
}
