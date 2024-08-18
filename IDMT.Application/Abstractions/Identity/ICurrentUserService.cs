using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Application.Abstractions.Identity;

public interface ICurrentUserService
{
	string UserName { get; }
        string UserFullName { get; }
        bool IsAuthenticated { get; }
}
