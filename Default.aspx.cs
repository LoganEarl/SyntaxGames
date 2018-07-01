using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Games;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            List<Games.Game> allGames = DatabaseHelper.GetInstance().GetAllGames(Server.MapPath(""));
            string newRow = "<div class=\"row\">";
            string rowEnd = "</div>";

            string gameHTML = newRow;
            for (int i = 0; i < allGames.Count; i++)
            {
                if (i % 3 == 0 && i != 0)
                    gameHTML += rowEnd + "\n" + newRow;
                gameHTML += new GameDisplayManger(allGames[i]).GetAsDisplayWindowHTML();
            }
            gameHTML += rowEnd;
            gamesContainer.InnerHtml = gameHTML;
        }
    }
}