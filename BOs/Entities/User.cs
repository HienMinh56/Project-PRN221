﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BOs.Entities;

public partial class User
{
    public int Id { get; set; }

    public string UserId { get; set; } = null!;

    [StringLength(50, MinimumLength = 2, ErrorMessage = "FullName must be between 2 and 50 characters long.")]
    [RegularExpression(@"^([A-Z][a-z]*)(\s[A-Z][a-z]*)*$", ErrorMessage = "Each word in FullName must start with an uppercase letter and can only contain letters and spaces.")]
    public string FullName { get; set; } = null!;

    [StringLength(50, MinimumLength = 2, ErrorMessage = "UserName must be between 5 and 50 characters long.")]
    [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "UserName can only contain letters and numbers with no spaces.")]
    public string UserName { get; set; } = null!;

    [StringLength(200, MinimumLength = 3, ErrorMessage = "Password must be more than 3 characters")]
    [RegularExpression(@"^\S.*$", ErrorMessage = "Password cannot start with a space.")]
    public string Password { get; set; } = null!;

    [StringLength(200, MinimumLength = 5, ErrorMessage = "Address must be between 5 and 200 characters long.")]
    public string Address { get; set; } = null!;

    [EmailAddress(ErrorMessage = "Invalid email address.")]
    public string Email { get; set; } = null!;

    [RegularExpression(@"^0\d{9}$", ErrorMessage = "Phone only 10 number and start with 0.")]
    public string Phone { get; set; } = null!;

    public int Role { get; set; }

    public int Status { get; set; }
    [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
    public DateTime? CreatedDate { get; set; } = DateTime.Now;

    public string? CreatedBy { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();
}
