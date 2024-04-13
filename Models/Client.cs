﻿namespace Constructor.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Deal> Deals { get; set; }
    }
}