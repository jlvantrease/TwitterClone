using System.Collections.Generic;

namespace CoreUser
{
    static class UserMem 
    {
        private static List<User> usersMem = new List<User>
        {
            new User{ID = 1, FirstName = "All", LastName = "Alfred", Email = "a@a.net"},
            new User{ID = 2, FirstName = "Bob", LastName = "B", Email = "b@b.net"},
            new User{ID = 3, FirstName = "Charlie", LastName = "C", Email = "c@c.net"},
        };
       
        public static List<User> All(){
            return usersMem;
        }
        public static bool Add(User u)
        {
            int count = usersMem.FindIndex(x => x.ID == u.ID);
            if(count != -1)
            {
                return false;
            }
            usersMem.Add(u);
            return true;
        }

        public static bool DeleteById(int id)
        {
            int index = usersMem.FindIndex(x => x.ID == id);
            if(index <= -1)
            {
                return false;
            }
            usersMem.RemoveAt(index);
            return true;
        }

        public static User FindById(int id)
        {
            int index = usersMem.FindIndex(x => x.ID == id);
            return usersMem[index];
        }
    }
}