using System;

namespace Farmer.Domain
{
    public interface IUniqueIdOwner
    {
        Guid Id { get; }
    }
}