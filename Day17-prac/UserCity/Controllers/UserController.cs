using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UserCity.Models;

namespace UserCity.Controllers
{
    public class UserController : Controller
    {
        SqlConnection cn = new SqlConnection();       
       
        public ActionResult Home()
        {
            
            if(Session["LoginName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (Request.Cookies["UserInfo"] != null)
                {
                    HttpCookie reqCook = Request.Cookies["UserInfo"];
                    string name = reqCook.Values["LoginName"];
                    string pass = reqCook.Values["Password"];

                    User user1 = new User();
                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
                    cn.Open();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = cn;
                    cmd1.CommandType = System.Data.CommandType.Text;
                    cmd1.CommandText = "Select * from Users where LoginName = @LoginName ";

                    cmd1.Parameters.AddWithValue("@LoginName", name);

                    SqlDataReader dr1 = cmd1.ExecuteReader();

                   
                    if (dr1.Read())
                    {
                        user1.LoginName = (string)dr1["LoginName"];
                        user1.Password = (string)dr1["Password"];
                        user1.FullName = (string)dr1["FullName"];
                        user1.CityId = (int)dr1["CityId"];
                        user1.Email = (string)dr1["Email"];
                        user1.Phone = (string)dr1["Phone"];


                        dr1.Close();
                        cn.Close();
                        return View(user1);
                    }
                    else
                    {
                        return View("Login");
                    }
                   
                }
                else
                {
                    User user = new User();
                    string LoginName = Session["LoginName"].ToString();

                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Select * from Users where LoginName = @LoginName ";

                    cmd.Parameters.AddWithValue("@LoginName", LoginName);

                    SqlDataReader dr = cmd.ExecuteReader();

                    if (dr.Read())
                    {
                        user.LoginName = (string)dr["LoginName"];
                        user.Password = (string)dr["Password"];
                        user.FullName = (string)dr["FullName"];
                        user.CityId = (int)dr["CityId"];
                        user.Email = (string)dr["Email"];
                        user.Phone = (string)dr["Phone"];


                        dr.Close();
                        cn.Close();
                        return View(user);
                    }
                    else
                    {
                        return View("Login");
                    }
                }
            }
   
        }

       

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            User user = new User();

            cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
            cn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.CommandText = "Select * from Cities";

            SqlDataReader dr = cmd.ExecuteReader();

            List<SelectListItem> lstCity = new List<SelectListItem>();

            while (dr.Read())
            {
                lstCity.Add(new SelectListItem { Text = (string)dr["CityName"], Value = Convert.ToInt32(dr["CityId"]).ToString() });

            }

            user.Cities = lstCity;
            dr.Close();
            cn.Close();
            return View(user);
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "InsertUser";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);

                cmd.ExecuteNonQuery();

                
                return RedirectToAction("Login");
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: User/Create
        public ActionResult Login()
        {
            HttpCookie objCookie1 = Request.Cookies["UserInfo"];
            if (objCookie1 != null)
            {
                return RedirectToAction("Home");
            }
            else
            {
                User user = new User();
                return View(user);
            }
           
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Login(User user)
        {
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = "select * from Users where LoginName = @LoginName and Password = @Password";

                cmd.Parameters.AddWithValue("@LoginName",user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                SqlDataReader dr = cmd.ExecuteReader();
                if (user.IsActive == true) //if you selected remember me 
                {
                   
                    if (dr.Read())
                    {
                        HttpCookie objCookie = new HttpCookie("UserInfo");
                        objCookie.Expires = DateTime.Now.AddDays(1);
                        objCookie.Values["LoginName"] = user.LoginName;
                        objCookie.Values["Password"] = user.Password;
                        Response.Cookies.Add(objCookie);

                        Session["LoginName"] = (string)dr["LoginName"];
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                else
                {
               
                    if (dr.Read())
                    {
                        Session["LoginName"] = (string)dr["LoginName"];
                        return RedirectToAction("Home");
                    }
                    else
                    {
                        return RedirectToAction("Login");
                    }
                }
                
            }
            catch
            {
                return View();
            }
            finally
            {
                cn.Close();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit()
        {
            if (Session["LoginName"] == null)
            {
                return RedirectToAction("Login");
            }
            else
            {
                if (Request.Cookies["UserInfo"] != null)
                {
                    HttpCookie reqCook = Request.Cookies["UserInfo"];
                    string name = reqCook.Values["LoginName"];
                    string pass = reqCook.Values["Password"];

                    User user = new User();

                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False; MultipleActiveResultSets=True";
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Select * from Users where LoginName = @LoginName ";

                    cmd.Parameters.AddWithValue("@LoginName", name);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();

                    user.LoginName = (string)dr["LoginName"];
                    user.Password = (string)dr["Password"];
                    user.FullName = (string)dr["FullName"];
                    user.CityId = (int)dr["CityId"];
                    user.Email = (string)dr["Email"];
                    user.Phone = (string)dr["Phone"];

                    dr.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = cn;
                    cmd1.CommandType = System.Data.CommandType.Text;
                    cmd1.CommandText = "Select * from Cities";

                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    List<SelectListItem> lstCity = new List<SelectListItem>();

                    while (dr1.Read())
                    {
                        lstCity.Add(new SelectListItem { Text = (string)dr1["CityName"], Value = Convert.ToInt32(dr1["CityId"]).ToString() });

                    }

                    user.Cities = lstCity;

                    dr1.Close();
                    cn.Close();
                    return View(user);

                }
                else
                {
                    User user = new User();
                    string name = Session["LoginName"].ToString();
                    cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False; MultipleActiveResultSets=True";
                    cn.Open();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = "Select * from Users where LoginName = @LoginName ";

                    cmd.Parameters.AddWithValue("@LoginName", name);

                    SqlDataReader dr = cmd.ExecuteReader();

                    dr.Read();

                    user.LoginName = (string)dr["LoginName"];
                    user.Password = (string)dr["Password"];
                    user.FullName = (string)dr["FullName"];
                    user.CityId = (int)dr["CityId"];
                    user.Email = (string)dr["Email"];
                    user.Phone = (string)dr["Phone"];

                    dr.Close();

                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = cn;
                    cmd1.CommandType = System.Data.CommandType.Text;
                    cmd1.CommandText = "Select * from Cities";

                    SqlDataReader dr1 = cmd1.ExecuteReader();

                    List<SelectListItem> lstCity = new List<SelectListItem>();

                    while (dr1.Read())
                    {
                        lstCity.Add(new SelectListItem { Text = (string)dr1["CityName"], Value = Convert.ToInt32(dr1["CityId"]).ToString() });

                    }

                    user.Cities = lstCity;

                    dr1.Close();
                    cn.Close();
                    return View(user);
                }
            }
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(User user)
        {
            try
            {
                cn.ConnectionString = @"Data Source=(localdb)\MsSqlLocalDb;Initial Catalog=J&KDec20;Integrated Security=True;Pooling=False";
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "UpdateUser";

                cmd.Parameters.AddWithValue("@LoginName", user.LoginName);
                cmd.Parameters.AddWithValue("@Password", user.Password);
                cmd.Parameters.AddWithValue("@FullName", user.FullName);
                cmd.Parameters.AddWithValue("@Email", user.Email);
                cmd.Parameters.AddWithValue("@CityId", user.CityId);
                cmd.Parameters.AddWithValue("@Phone", user.Phone);

                cmd.ExecuteNonQuery();
                cn.Close();

                return RedirectToAction("Home");
               
            }
            catch
            {
                return View();
            }
        }

       
       

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session["LoginName"] = null;
            Session.Abandon();

            if(Request.Cookies["UserInfo"] != null)
            {
                Request.Cookies["UserInfo"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(Request.Cookies["UserInfo"]);
                return RedirectToAction("Login");

            }
            else
            {
                return RedirectToAction("Login");
            }

           
        }
    }
}
