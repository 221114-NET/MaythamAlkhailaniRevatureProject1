using ApiUi.Business;
using ApiUi.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ApiUi.Login
{
    //public class Login
    //{
    //    private static string connectionString = "Server=localhost;Database=ReimbursementDb;Trusted_Connection=True;MultipleActiveResultSets=true";

    //    public static void AddUser(User user)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            SqlCommand command = new SqlCommand();
    //            command.Connection = connection;
    //            command.CommandType = CommandType.Text;
    //            command.CommandText = "INSERT INTO Users (Name, Email, Password) VALUES (@name, @email, @password)";
    //            command.Parameters.AddWithValue("@name", user.Name);
    //            command.Parameters.AddWithValue("@email", user.Email);
    //            command.Parameters.AddWithValue("@password", user.Password);

    //            command.ExecuteNonQuery();
    //        }
    //    }

    //    public static void AddAdmin(Admin admin)
    //    {
    //        using (SqlConnection connection = new SqlConnection(connectionString))
    //        {
    //            connection.Open();

    //            SqlCommand command = new SqlCommand();
    //            command.Connection = connection;
    //            command.CommandType = CommandType.Text;
    //            command.CommandText = "INSERT INTO Admins (Name, Email, Password) VALUES (@name, @email, @password)";
    //            command.Parameters.AddWithValue("@name", admin.Name);
    //            command.Parameters.AddWithValue("@email", admin.Email);
    //            command.Parameters.AddWithValue("@password", admin.Password);

    //            command.ExecuteNonQuery();
    //        }
    //    }

    //    public static bool VerifyUser(string email, string password)

    //    {
    //        try
    //        {
    //            if (email == null || password == null)  //Change that so it checks with the database.
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                using (SqlConnection connection = new SqlConnection(connectionString))
    //                {
    //                    connection.Open();
    //                    SqlCommand command = new SqlCommand("Select count(*) from Users where Email= @email and Password=@password", connection);
    //                    command.Parameters.AddWithValue("@email", email);
    //                    command.Parameters.AddWithValue("@password", password);
    //                    var result = (int)command.ExecuteScalar();
    //                    return (result > 0);
    //                }

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return false;
    //        }
    //    }


    //    public static bool VerifyAdmin(string email, string password)

    //    {
    //        try
    //        {
    //            if (email == null || password == null)  //Change that so it checks with the database.
    //            {
    //                return false;
    //            }
    //            else
    //            {
    //                using (SqlConnection connection = new SqlConnection(connectionString))
    //                {
    //                    connection.Open();
    //                    SqlCommand command = new SqlCommand("Select count(*) from Admins where Email= @email and Password=@password", connection);
    //                    command.Parameters.AddWithValue("@email", email);
    //                    command.Parameters.AddWithValue("@password", password);
    //                    var result = (int)command.ExecuteScalar();
    //                    return (result > 0);
    //                }

    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            return false;
    //        }
    //    }
    //}
}
