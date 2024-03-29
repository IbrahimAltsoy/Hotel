﻿using Microsoft.AspNetCore.Identity;

namespace Hotel.EntitiyLayer.Concreate
{
    public class AppUser: IdentityUser<Guid>
    {
        

        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string? ImageUrl { get; set; }
        public string? WorkDeparment { get; set; }
        public Guid? WorkLocationId { get; set; }
        public bool? IsActive { get; set; } = false;

        public WorkLocation? WorkLocation { get; set; }
    }
}
