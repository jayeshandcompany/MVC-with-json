using System.Data.SqlClient;
using System.Data;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Models
{
    public class StudentModel
    {
        public int? Id { get; set; }
        [Required(ErrorMessage ="please enter your name")]
        public string name { get; set;}

        public string gender { get; set; }

        public string Country { get; set; }

        public string college { get; set; }
        public string password { get; set; }
        //[Required(ErrorMessage ="please enter File name")]
        //public string FileName { get; set; }
        public IFormFile? file { get; set; }
        public string? exam { get; set; }

        public int? year { get; set; }
        public int? percent { get; set; }

        public List<StudentModel> GetAllstudent()
        {
            List<StudentModel> studentTable = new List<StudentModel>();
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student", con);
            SqlDataAdapter dat = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            dat.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                studentTable.Add(
                    new StudentModel()
                    {
                        Id = Convert.ToInt32(dr["Studentid"]),
                        name = Convert.ToString(dr["Name"]),
                        gender = Convert.ToString(dr["Gender"]),
                        Country = Convert.ToString(dr["Country"]),
                        college = Convert.ToString(dr["College"]),
                        password = Convert.ToString(dr["Password"])
                    });

            }
            return studentTable;
        }
        public string getdata(int? id1)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student where Studentid=" + (id1), con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            StudentModel st = new StudentModel();
            adapter.Fill(dt);
            var dr = dt.Rows[0];

            string msg = "Name = " + Convert.ToString(dr["Name"]) + "\n Gender = " + dr["Gender"].ToString() + " \n Country = " + Convert.ToString(dr["Country"]) + "\nCollege = " + Convert.ToString(dr["College"]) + "\n Password = " + Convert.ToString(dr["Password"]);
            con.Close();
           
            
            return msg;

        }
    }

    public enum Country1
    {
        India,
        Egypt,
        Utah,
        Canada,
        US
    }
}

