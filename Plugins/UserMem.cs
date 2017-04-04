using System.Collections.Generic;

namespace User
{
    class UserMem
    {
        private List<User> users;
 
        public UserMem()
        {
            this.users = new List<User>();
        }

        public UserMem(List<User> u)
        {
            this.users = new List<User>(u);
        }

        public bool Add(User u)
        {
            int count = this.users.FindIndex(x => x.ID == u.ID);
            if(count != -1)
            {
                return false;
            }
            return true;
        }
    }
}