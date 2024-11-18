namespace psevdotinder_core.DTOs
{
    public class UserDTO
    {
        public Id Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }

        public static implicit operator UserDTO(User other) =>
            new()
            {
                Id = other.Id,
                Name = other.Name,
                Phone = other.Phone,
                Password = other.Password,
            };
    }
}
