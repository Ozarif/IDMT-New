using IDMT.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.Posts
{
	public sealed class PostResource : Entity
	{
        internal PostResource(Guid id, 
							Guid postId, 
							Guid resourceId, 
							Guid resourceProfileId, 
							string? resourceLoginName, 
							string? note) 
            : base(id)
        {
            PostId = postId;
			ResourceId = resourceId;
			ResourceProfileId = resourceProfileId;
			ResourceLoginName = resourceLoginName;
			Note = note;
        }

        public Guid PostId { get; private set; }
		public Guid ResourceId { get; private set; }
		public Guid ResourceProfileId { get; private set; }
		public string? ResourceLoginName { get; private set; }
		public string? Note { get; private set; }
	}
}
