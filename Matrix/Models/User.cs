﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Matrix.Models
{
    public class User
    {
        public int userID { get; set; }
        public string userName { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }

        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Introduction { get; set; }
        public string LookingFor { get; set; }
        public string Interests { get; set; }
        public string City { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public User()
        {
            Photos = new Collection<Photo>();
        }
    }
}
