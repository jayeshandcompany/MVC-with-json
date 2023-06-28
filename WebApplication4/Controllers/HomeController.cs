using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using System.Linq;
using System.Web;
using WebApplication4.Models;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace WebApplication4.Controllers
{
   
   
    public class HomeController : Controller
    { 
        static string msg = "Welcome to Student Management System";
        static bool show = false;

        public PartialViewResult PartialViewAction()
        {
            // Perform any necessary logic
            StudentModel m =new StudentModel();
            // Return the partial view
            return PartialView("_try",m);
        }
        public IActionResult save()
        {
            StudentModel studentModel = new StudentModel();
            ViewBag.alertmsg=msg;
            msg = "";
           
            

            

            return View("json",studentModel);
        }
        [HttpPost]
        public ActionResult save(StudentModel sc)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    

                    //string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/files");
                    //string fileNamewithpath = Path.Combine(path, sc.file.FileName);
                    //using (var stream = new FileStream(fileNamewithpath, FileMode.Create))
                    //{
                    //    sc.file.CopyTo(stream);
                    //}

                    SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
                    con.Open();
                    if (sc.Id == null)
                    {
                        SqlCommand cmd = new SqlCommand("insert into student  values ('" + sc.name + "','" + sc.gender + "','" + sc.Country + "','" + sc.college + "','" + sc.password + "')", con);
                        cmd.ExecuteNonQuery();
                        msg = "Successfully Added the data for " + sc.name;
                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand("update student SET Name='" + sc.name + "',Gender='" + sc.gender + "'Country=,'" + sc.Country + "',College='" + sc.college + "',Password='" + sc.password + "' WHERE Studentid=" + sc.Id);
                        cmd.ExecuteNonQuery();
                        msg = "Successfully Updated the data for " + sc.name;

                    }


                    con.Close();

                    return RedirectToAction("save");


                }

                catch
                {
                    return View();
                }
            }
            return View();



        }
        public IActionResult view(StudentModel st)
        {
            ViewBag.message = msg;
            ViewBag.show = show;
            return View(st);    
        }

        public ActionResult reset(StudentModel st)
        {
            st.name = "";
            st.gender = "";
            st.Country = "";
            st.college = "";
            st.password = "";
            st.Id = null;
            return RedirectToAction("save");
        }
        
        public ActionResult Deletedata(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("delete from student where Studentid="+(id), con);
            cmd.ExecuteNonQuery();
            con.Close();
            StudentModel s1 = new StudentModel();
            msg = "Student detail succesfully deleted ";

            return RedirectToAction("view");

        }
        public void trial()
        {
            ViewBag.message = "try";
        }
        
        public IActionResult Editdata(int id)
        {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from student where Studentid=" +(id), con);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            StudentModel st=new StudentModel();
            adapter.Fill(dt);
            var dr=dt.Rows[0];
           
            st.name =   Convert.ToString(dr["Name"]).TrimEnd();
            st.gender= dr["Gender"].ToString().TrimEnd();
            st.Country = Convert.ToString(dr["Country"]).TrimEnd();
            st.college = Convert.ToString(dr["College"]).TrimEnd();
            st.password = Convert.ToString(dr["Password"]).Trim();
            







            con.Close();
            
            return View("save", st);

        }
        [HttpPost]
        public ActionResult Editdata(StudentModel sc) {
            SqlConnection con = new SqlConnection("Data Source=LAPTOP-UHCNLFKC\\SQLEXPRESS;Initial Catalog=jayesh;Integrated Security=True");
            con.Open();
            SqlCommand cmd = new SqlCommand("update student SET Name='" + sc.name + "',Gender='" + sc.gender + "',Country='" + sc.Country + "',College='" + sc.college + "',Password='" + sc.password + "' WHERE Studentid=" + sc.Id,con);
            cmd.ExecuteNonQuery();

        


            con.Close();
            StudentModel st = new StudentModel();
            var i = reset(st);

            return RedirectToAction("reset");

    }
        public IActionResult Js()
        {
            
           
            return View("jsonview");    
        }
         public JsonResult Result()
        {
            StudentModel st=new StudentModel();
            var a = st.GetAllstudent();
            var jsondata= Json(a);
            return jsondata;


        }




    }



    }

