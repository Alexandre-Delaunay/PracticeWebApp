using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticeWebApp.Models
{
    public interface IUser
    {
        public string Name { get; set; }
        public string FirstName { get; set; }
    }
}
