namespace psevdotinder.Core.Entities
{
    public class Profile : IEntity
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string AccountLink { get; set; }
    }

}