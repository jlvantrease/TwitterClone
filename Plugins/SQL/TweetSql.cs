using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Tweet
{
    public class TweetSql : IPlugin<Tweet>
    { private SqlConnectionStringBuilder builder;

        public TweetSql(){
            builder = new SqlConnectionStringBuilder();
            builder.DataSource="twitterclone.database.windows.net";
            builder.UserID="jasonvantrease";
            builder.Password="cs4790!!";
            builder.InitialCatalog = "TwitterClone";
        }

        public bool Add(Tweet t)
        {
            Console.WriteLine(t.ToString());
            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    //TweetMessage TweetOwner TweetID
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO dbo.JLVTweet ([TweetMessage], [TweetOwner]) ");
                    sb.AppendFormat("VALUES(@TweetMessage, @TweetOwner);");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        command.Parameters.AddWithValue("@TweetMessage", t.Message);
                        command.Parameters.AddWithValue("@TweetOwner", t.TweetOwner);
                        int rowsAffected = command.ExecuteNonQuery();
                        Console.WriteLine("SQL: "+ rowsAffected + " row(s) inserted");
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
                return false;
            }
            
            return true;
        }

        public List<Tweet> All()
        {
            List<Tweet> tweets = new List<Tweet>();
            try
                {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM JLVTweet;");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        using (SqlDataReader reader = command.ExecuteReader()){
                            while(reader.Read()){
                                var message = reader.GetString(0);
                                var tweetOwner = reader.GetInt32(1);
                                var tweetId = reader.GetInt32(2);
                                tweets.Add(new Tweet {Message = message, TweetOwner = tweetOwner, TweetID = tweetId});
                            }
                        }
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            }
            return tweets;
        }

        public bool DeleteById(int tweetId)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM JLVTweet WHERE TweetID = @ID;");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        command.Parameters.AddWithValue("@ID", tweetId);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                            return false;
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            }
            
            return true;
        }

        public Tweet FindById(int id)
        {
          Tweet tweet = new Tweet();
            try
                {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("SELECT * FROM JLVTweet WHERE TweetID = {0};",id);
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn))
                    {
                       using (SqlDataReader reader = command.ExecuteReader())
                        {   
                            int count = 0;                         
                            while(reader.Read())
                            {
                                count++;
                                var message  = reader.GetString(0);
                                var tweetOwner = reader.GetInt32(1);
                                var tweetId = reader.GetInt32(2);
                                tweet = new Tweet {Message = message, TweetOwner = tweetOwner, TweetID = tweetId };
                            }
                            if(count < 1){
                                return null;
                            }
                        }
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            }
            return tweet;
        }

        public Tweet UpdateById(int id, Tweet obj)
        {
            throw new NotImplementedException();
        }
    }
}