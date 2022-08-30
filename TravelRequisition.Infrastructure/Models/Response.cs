﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TravelRequisition.Infrastructure.Models
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool Succeeded { get; set; }
        public T Data { get; set; }
    }
}
