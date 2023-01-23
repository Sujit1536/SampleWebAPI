using System;
using System.Collections.Generic;

namespace WebServices1.Entities;

public partial class Person
{
    public int PersonID { get; set; }

    public string LastName { get; set; }

    public string FirstName { get; set; }

    public string Address { get; set; }

    public string City { get; set; }
}
