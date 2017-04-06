using System.Collections.Generic;

namespace CoreUser
{
    class UserMem
    {
        private List<User> users;
 
        public UserMem()
        {
            this.users = new List<User>();
            users.Add(new User{ID = 1, FirstName = "All", LastName = "Alfred", Email = "a@a.net"});
            users.Add(new User{ID = 2, FirstName = "Bob", LastName = "B", Email = "b@b.net"});
            users.Add(new User{ID = 3, FirstName = "Charlie", LastName = "C", Email = "c@c.net"});
        }

        public UserMem(List<User> u)
        {
            this.users = new List<User>(u);
        }
        public List<User> All(){
            return users;
        }
        public bool Add(User u)
        {
            int count = this.users.FindIndex(x => x.ID == u.ID);
            if(count != -1)
            {
                return false;
            }
            this.users.Add(u);
            return true;
        }

        public User UserById(int id)
        {
            int index = this.users.FindIndex(x => x.ID == id);
            return users[index];
        }
    }
}