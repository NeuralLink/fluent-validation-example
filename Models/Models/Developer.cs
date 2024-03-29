﻿namespace Models.Models
{
    public class Developer
    {
        public Address Address { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string FirstName { get; set; }

        public int Id { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}