using System;
using Microsoft.AspNetCore.Identity;

namespace Domain.Interfaces
{
    public interface IEntityUser<TUser> : IEntityUser<Guid, TUser>
        where TUser : IdentityUser<Guid>
    {
    }

    public interface IEntityUser<TKey, TUser> : IEntityUserId<TKey>
        where TKey : IEquatable<TKey>
        where TUser : IdentityUser<TKey>
    {
        new TKey AuthorId { get; set; }
        TUser? Author { get; set; }
    }
}