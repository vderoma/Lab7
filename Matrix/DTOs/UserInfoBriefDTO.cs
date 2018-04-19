using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix.DTOs
{
    public class UserInfoBriefDTO
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public string Gender { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public int Age { get; set; }
        public string PhotoUrl { get; set; }
    }
}
