﻿namespace psevdotinder.Core.Entities
{
    public class User : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
    }

}