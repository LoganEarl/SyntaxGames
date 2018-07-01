using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Games;

public partial class PlayGame : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            string gameID = Request.QueryString["gameID"];
            Games.Game g = DatabaseHelper.GetInstance().GetGameOfID(gameID, Server.MapPath(""));
            GameDisplayManger gd = new GameDisplayManger(g);

            if (g != null && g.SourceExists())
                GameSlot.InnerHtml = gd.GetAsCanvasHTML();
        }
    }
}