using System;

namespace Models.Entities.Interfaces
{
    public interface IModificationHistory
    {
        DateTime DateModified { get; set; }
        DateTime DateCreated { get; set; }
    }
}
