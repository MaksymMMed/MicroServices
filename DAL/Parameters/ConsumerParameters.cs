﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Parameters
{
    public class ConsumerParameters:QueryStringParameters
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
