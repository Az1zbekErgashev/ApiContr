﻿namespace WebApplication1.Enitiy
{
    public class Contact
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public User User { get; set; }
    }
}
