﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace mm_lib
{
    public partial class Register
    {
        public Register()
        {
            Members = new HashSet<Members>();
            Membership = new HashSet<Membership>();
        }

        public long OrgId { get; set; }
        public string OrgName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Members> Members { get; set; }
        public virtual ICollection<Membership> Membership { get; set; }
    }
}