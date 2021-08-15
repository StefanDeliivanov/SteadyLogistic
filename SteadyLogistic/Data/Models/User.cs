﻿namespace SteadyLogistic.Data.Models
{
    using System;
    using Microsoft.AspNetCore.Identity;

    public class User : IdentityUser
    {
        public DateTime RegisteredOn { get; set; }
    }
}