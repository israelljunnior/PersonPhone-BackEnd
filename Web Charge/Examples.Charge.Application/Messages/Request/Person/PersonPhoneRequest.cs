﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Examples.Charge.Application.Messages.Request.Person
{
    public class PersonPhoneRequest
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public int PhoneNumberTypeID { get; set; }
    }
}
