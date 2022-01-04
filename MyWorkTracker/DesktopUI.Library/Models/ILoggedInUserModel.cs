using System;

namespace DesktopUI.Library.Models
{
    public interface ILoggedInUserModel
    {
        string EmailAddress { get; set; }
        string FirstName { get; set; }
        string Id { get; set; }
        string LastName { get; set; }
        string Company { get; set; }
        bool IsAdmin { get; set; }
        DateTime CreatedAt { get; set; }

        void ResetUser();
    }
}