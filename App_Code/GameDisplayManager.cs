using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Games;

public class GameDisplayManger
{
    private Game game;
    public GameDisplayManger(Game g)
    {
        this.game = g;
    }

    public string GetAsCanvasHTML()
    {
        return "<canvas data-processing-sources=\"" + game.GetPartialFilePath() + "\" class=\"center-block\" runat=\"server\" style=\"width:100%\"></canvas>";
    }

    public string GetAsDisplayWindowHTML()
    {
        string author = DatabaseHelper.GetInstance().GetUsernameOfID(game.authorID);

        return "<div class=\"col-sm-4\">" +
                "<div class=\"panel panel-primary\">" +
                "<div class=\"panel-heading\"><a href=\"PlayGame.aspx?gameID=" + game.gameID + "\">" + game.gameName + "</a></div>" +
                "<div class=\"panel-body\"><img src = \"" + game.GetThumbnailDirectory() +  "\" class=\"img-responsive\" style=\"width:100%\" alt=\"Image\"></div>" +
                "<div class=\"panel-footer\">Author: " + author + "</div>" +
                "</div>" +
                "</div>";
    }
}