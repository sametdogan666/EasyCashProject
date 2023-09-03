﻿using Microsoft.AspNetCore.Identity;

namespace EasyCashProject.Entities.Concrete;

public class AppUser : IdentityUser<int>
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? District { get; set; }
    public string? City { get; set; }
    public string? ImageUrl { get; set; }
    
}