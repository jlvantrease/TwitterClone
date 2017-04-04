using System;

namespace Tweet
{
    public class Tweet
    {
        protected string Message { get; set; }
        protected Guid TweetOwner { get; set; }
        protected Guid TweetID { get; }

        public Tweet(Guid id)
        {
            this.TweetOwner = id;
            this.TweetID = Guid.NewGuid();
        }
    }
}