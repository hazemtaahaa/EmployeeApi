﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Employee.DAL;

public class EmployeeEntity
{
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;

}
