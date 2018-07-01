using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Games;

public partial class AddGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["LoggedInUser"] == null)
            Server.Transfer("Default.aspx");
        string userID = Session["LoggedInUser"].ToString();

        if (IsPostBack)
        {
            string gameName = inputGameName.Value;
            string sourceCode = inputSourceCode.Value;
            Games.Game g = new Games.Game(userID, gameName, sourceCode, Server.MapPath(""));
            g.WriteGameToFileSystem();
            inputScreenshot.PostedFile.SaveAs(Server.MapPath("") + "/" + g.GetThumbnailDirectory());

            DatabaseHelper.GetInstance().saveGame(g);

            Server.Transfer("Default.aspx");
        }
    }
}