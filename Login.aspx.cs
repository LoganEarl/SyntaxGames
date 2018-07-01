using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedInUser"] != null)
            Server.Transfer("AddGame.aspx");

        if (IsPostBack)
        {
            string userID = inputUserID.Value;
            string password = inputPassword.Value;
            int hash = password.GetHashCode();

            bool success = DatabaseHelper.GetInstance().ValidateCredentials(userID, hash.ToString());
            if (success)
            {
                Session["LoggedInUser"] = userID;
                badPskLbl.Visible = false;
                Server.Transfer("AddGame.aspx");
            } 
            else
                badPskLbl.Visible = true;

        }
    }
}