using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities.Common;

namespace Galacticos.Domain.Entities
{
    public class Like : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid PostId { get; set; }
    }
}