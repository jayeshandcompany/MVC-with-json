using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using WebApplication4.Models;

namespace WebApplication4
{
    public class abc
    {
        SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");

        public void save(StudentModel data)
        {
            con.Open();
           // SqlCommand cmd = new SqlCommand("insert into Student vaules ('" + data.name + "','" + data.hobbies + "','" + data.gender + "','" + data.college + "','" + data.birthdate + "','"+data.Country+ "','"+data.year+ "')", con);
            //cmd.ExecuteNonQuery();
            con.Close();

        }

    }
}
