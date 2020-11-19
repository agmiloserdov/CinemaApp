using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Cinema.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public virtual List<Film> Films { get; set; }
    }
}