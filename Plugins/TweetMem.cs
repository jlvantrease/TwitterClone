using System.Collections.Generic;

namespace Tweet
{
    class TweetMem
    {
        private List<Tweet> tweets;
 
        public TweetMem()
        {
            this.tweets = new List<Tweet>();
            tweets.Add(new Tweet{TweetID = 1, TweetOwner = 1, Message = "Tweet 1 owner = 1"});
            tweets.Add(new Tweet{TweetID = 2, TweetOwner = 1, Message = "Tweet 2 owner = 1"});
            tweets.Add(new Tweet{TweetID = 3, TweetOwner = 1, Message = "Tweet 3 owner = 2"});
            tweets.Add(new Tweet{TweetID = 4, TweetOwner = 1, Message = "Tweet 4 owner = 3"});
        }

        public TweetMem(List<Tweet> t)
        {
            this.tweets = new List<Tweet>(t);
        }
        public List<Tweet> All(){
            return tweets;
        }
        public bool Add(Tweet t)
        {
            int count = this.tweets.FindIndex(x => x.TweetID == t.TweetID);
            if(count != -1)
            {
                return false;
            }
            this.tweets.Add(t);
            return true;
        }

        public Tweet TweetById(int id)
        {
            int index = this.tweets.FindIndex(x => x.TweetID == id);
            return tweets[index];
        }
    }
}