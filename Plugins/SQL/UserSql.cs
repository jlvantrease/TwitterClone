using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace CoreUser
{
    public class UserSql : IPlugin<User>
    {
        private SqlConnectionStringBuilder builder;

        public UserSql(){
            builder = new SqlConnectionStringBuilder();
            builder.DataSource="twitterclone.database.windows.net";
            builder.UserID="jasonvantrease";
            builder.Password="cs4790!!";
            builder.InitialCatalog = "TwitterClone";
        }
        public bool Add(User u)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("INSERT INTO dbo.JLVUser ([FirstName], [LastName], [Email])");
                    sb.AppendFormat("VALUES(@FirstName, @LastName, @Email);");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        command.Parameters.AddWithValue("@FirstName", u.FirstName);
                        command.Parameters.AddWithValue("@LastName", u.LastName);
                        command.Parameters.AddWithValue("@Email", u.Email);
                        int rowsAffted = command.ExecuteNonQuery();
                        Console.WriteLine("SQL: "+rowsAffted + "row(s) inserted");
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
                return false;
            }
            
            return true;
        }
        public System.Collections.Generic.List<User> All()
        {
            List<User> users = new List<User>();
            try
                {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("SELECT * FROM JLVUser;");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        using (SqlDataReader reader = command.ExecuteReader()){
                            while(reader.Read()){
                                var id = reader.GetInt32(0);
                                var fname = reader.GetString(1);
                                var lname = reader.GetString(2);
                                var email = reader.GetString(3);
                                users.Add(new User {ID = id, FirstName = fname, LastName = lname, Email = email});
                            }
                        }
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            }
            return users;
        }
      
        public User UpdateById(int id, User u)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("UPDATE dbo.JLVUser ");
                    sb.Append("SET FirstName = @FirstName, LastName = @LastName, Email = @Email ");
                    sb.Append("WHERE ID = @ID;");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        command.Parameters.AddWithValue("@ID", id.ToString());
                        command.Parameters.AddWithValue("@FirstName", u.FirstName);
                        command.Parameters.AddWithValue("@LastName", u.LastName);
                        command.Parameters.AddWithValue("@Email", u.Email);
                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected == 0)
                            return null;
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            
            }
            
            return u;
        }

        public bool DeleteById(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.Append("DELETE FROM JLVUser WHERE ID = @ID;");
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn)){
                        command.Parameters.AddWithValue("@ID", id.ToString());
                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected == 0)
                            return false;
                    }
                }
            }
            catch(SqlException e){
                Console.WriteLine(e.ToString());
            }
            
            return true;
        }

        public User FindById(int id)
        {
            User user = new User();
            try
                {
                using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
                conn.Open();
                    
                    StringBuilder sb = new StringBuilder();
                    sb.AppendFormat("SELECT * FROM JLVUser WHERE ID = {0};",id);
                    String sql = sb.ToString();
                    
                    using(SqlCommand command = new SqlCommand(sql,conn))
                    {
                       using (SqlDataReader reader = command.ExecuteReader())
                        {   
                            int count = 0;                         
                            while(reader.Read())
                            {
                                count++;
                                var userId  = reader.GetInt32(0);
                                var fname = reader.GetString(1);
                                var lname = reader.GetString(2);
                                var email = reader.GetString(3);
                                user = new User {ID = userId, FirstName = fname, LastName = lname, Email = email};
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
            return user;
        }


    }
}