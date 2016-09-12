﻿using System;

namespace Client
{
    public class Transaction
    {
        public int Id { get; set; }
        public string CustomerName { get; set; }
        public double Total { get; set; }
        public DateTime CompletedOn { get; set; }
    }
}