using Raamen.Model;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.Views
{
    public partial class UpdateUser : System.Web.UI.Page
    {
        UserRepository ur = new UserRepository();
        protected void Page_Load(object sender, EventArgs e)
        {
            User currentUser = (User)Session["USer"];
            if (Session["User"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
            }
            if (IsPostBack == false)
            {
                TbUsername.Text = currentUser.Username;
                TbEmail.Text = currentUser.Email;
                GenderList.SelectedValue = GenderList.Items.FindByText(currentUser.Gender).ToString();
            }
        }

        protected void Update_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(Session["UserID"].ToString());
            string username = TbUsername.Text;
            string email = TbEmail.Text;
            string gender = GenderList.SelectedItem.Text;
            string password = TbPassword.Text;

            User curUser = (User)Session["User"];

            TbUsername.Text = curUser.Username;
            TbEmail.Text = curUser.Email;
            GenderList.SelectedValue = GenderList.Items.FindByText(curUser.Gender).ToString();
            ur.updateUser(userId, username, email, gender, password);
        }
    }
}