using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Galacticos.Domain.Entities;

namespace Galacticos.Application.Persistence.Contracts
{
    public interface IRelationRepository
    {
        Task<Follow> Follow(Guid followerId, Guid followingId); // Follow
        Task<Follow> UnFollow(Guid followerId, Guid followingId); // Unfollow
        Task<Follow> Get(Guid followerId, Guid followingId); // Get Relation
        Task<List<Guid>> GetFollowedUserIdsByUserId(Guid userId); 

    }
}
