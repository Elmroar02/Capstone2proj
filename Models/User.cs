﻿using System;
using System.Collections.Generic;

#nullable disable

namespace webapi.Models
{
    public partial class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Position { get; set; }
        public string Meal { get; set;}
    }
}
