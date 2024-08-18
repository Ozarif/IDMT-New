using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Abstractions
{
	public abstract  class AuditableEntity : Entity
	{
        protected AuditableEntity()
        {
            
        }
        protected AuditableEntity(Guid Id) 
            : base(Id) 
        {            
        }
		public string CreatedBy { get; set; }
		public DateTime Created { get; set; }
		public string? LastModifiedBy { get; set; }
		public DateTime? LastModified { get; set; }
	}
}
