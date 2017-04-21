/*
try
{
    using (SqlConnection conn = new SqlConnection(builder.ConnectionString)){
    conn.Open();
                    
    StringBuilder sb = new StringBuilder();
                   
    String sql = sb.ToString();
                    
        using(SqlCommand command = new SqlCommand(sql,conn)){
                       
        }
    }
}
catch(SqlException e){
Console.WriteLine(e.ToString());
return false;
}
*/