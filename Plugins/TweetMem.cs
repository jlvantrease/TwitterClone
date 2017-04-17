using System.Collections.Generic;

namespace Tweet
{
    class TweetMem
    {
        private static List<Tweet> tweets = new List<Tweet>
        {
            new Tweet{TweetID = 1, TweetOwner = 1, Message = "Tweet 1 owner = 1"},
            new Tweet{TweetID = 2, TweetOwner = 1, Message = "Tweet 2 owner = 1"},
            new Tweet{TweetID = 3, TweetOwner = 1, Message = "Tweet 3 owner = 2"},
            new Tweet{TweetID = 4, TweetOwner = 1, Message = "Tweet 4 owner = 3"}
        };
 
        public List<Tweet> All(){
            return tweets;
        }
        public static bool Add(Tweet t)
        {
            int count = tweets.FindIndex(x => x.TweetID == t.TweetID);
            if(count != -1)
            {
                return false;
            }
            tweets.Add(t);
            return true;
        }

        public static bool DeleteById(int id)
        {
            int index = tweets.FindIndex(x => x.TweetID == id);
            if (index <= -1)
            {
                return false;
            }
            tweets.RemoveAt(index);
            return true;
        }

        public static Tweet CreateById(int id)
        {
            int index = tweets.FindIndex(x => x.TweetID == id);
            return tweets[index];
        }
    }
}