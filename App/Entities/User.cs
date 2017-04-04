using System;

namespace User
{
    public class User
    {
        public Guid ID { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        
        public User()
        {
            this.ID = Guid.NewGuid();
        }
    }
}