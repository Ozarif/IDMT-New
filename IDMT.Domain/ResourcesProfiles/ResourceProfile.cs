using IDMT.Domain.Abstractions;
using IDMT.Domain.Resources;
using IDMT.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IDMT.Domain.ResourcesProfiles
{
    public sealed class ResourceProfile : Entity
    {
        private ResourceProfile(Guid id, string name, Guid resourceId)
            : base(id)
        {
            Name = name;
            ResourceId = resourceId;
        }
        private ResourceProfile()
        {
            
        }
        public string Name { get; private set; }
        public Guid ResourceId { get; private set; }
        public bool IsActive { get; private set; }
        public void Deactivate()
        {
            IsActive = false;
        }
        public static ResourceProfile Create(Guid id, string name, Resource resource)
        {
            var resourceProfile =  new ResourceProfile(Guid.NewGuid(), name, resource.Id);
            resourceProfile.IsActive = true;
            return resourceProfile;
        }
    }
}
