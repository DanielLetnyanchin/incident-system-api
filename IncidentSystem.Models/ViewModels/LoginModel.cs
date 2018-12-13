using System.ComponentModel.DataAnnotations;

namespace IncidentSystem.Models.ViewModels
{
    public class LoginModel
    {
        public string UserName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}