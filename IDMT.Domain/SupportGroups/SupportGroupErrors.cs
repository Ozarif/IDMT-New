using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.SupportGroups;

public static class SupportGroupErrors
{
	public static readonly Error NotFound = new(
								"SupportGroup.NotFound",
								"The Support Group with the specified identifier was not found");
	public static readonly Error AlreadyExists = new(
							"SupportGroup.AlreadyExists",
							"The Support Group with the specified name is already existed");
}
