using System;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Generic;
using Games;

public class DatabaseHelper
{
    private string rootFileLocation;

    private static DatabaseHelper instance = null;
    private static string connectionString = "Data Source = SQL7002.site4now.net; Initial Catalog = DB_A38E9B_SyntaxGames; User Id = DB_A38E9B_SyntaxGames_admin; Password=Abcd12123;";

    private SqlConnection connection;

    private DatabaseHelper()
    {
        connection = new SqlConnection(connectionString);
    }

    public static DatabaseHelper GetInstance()
    {
        if (instance == null)
            instance = new DatabaseHelper();
        return instance;
    }

    public bool saveGame(Game g)
    {
        return insertContentValues(
            "INSERT INTO Games VALUES(@GameID, @GameName, @AuthorID, @SourceFile)",
            new string[] { "@GameID", "@GameName", "@AuthorID", "@SourceFile" },
            new string[] { g.gameID, g.gameName, g.authorID, g.GetPartialFilePath() });
    }

    private bool insertContentValues(string insert, string[] rows, string[] values)
    {
        bool success = false;
        SqlCommand cmd;
        try
        {
            connection.Open();
            using (cmd = new SqlCommand(insert, connection))
            {
                for (int i = 0; i < rows.Length; i++)
                    cmd.Parameters.AddWithValue(rows[i], values[i]);
                cmd.ExecuteNonQuery();
            }
            success = true;
        }
        catch (Exception){}
        finally
        {
            cmd = null;
            connection.Close();
        }
        return success;
    }

    public bool ValidateCredentials(string id, string passHash)
    {
        Object[] user = GetQueryResult(
            "SELECT * FROM Users WHERE Id='" + id + "' AND HashPass='" + passHash + "'",
            new string[] {"Id" });
        if (user == null)
            return false;
        return true;
    }

    public string GetUsernameOfID(string id)
    {
        Object[] user = GetQueryResult(
            "SELECT UserName FROM Users WHERE Id='" + id + "'",
            new String[] { "UserName" });
        if (user != null)
            return user[0].ToString();
        else
            return "";
    }

    public List<Game> GetAllGames(string root)
    {
        List<Object[]> rawValues = GetQueryResults(
                "SELECT * FROM Games", 
                new string[] { "GameName","GameID","AuthorID" });

        List<Game> returns = new List<Game>();

        foreach(Object[] values in rawValues)
        {
            Game g = new Game(
                values[2].ToString(),
                values[1].ToString(),
                root);
            g.gameName = values[0].ToString();
            returns.Add(g);
        }
        
        return returns;
    }

    private Object[] GetQueryResult(string query, string[] parameters)
    {
        List<Object[]> rawValues = GetQueryResults(query,parameters);

        if (rawValues.Count > 0)
        {
            return rawValues[0];
        }

        return null;
    }

    private List<Object[]> GetQueryResults(string query, string[] parameters)
    {
        SqlCommand cmd;
        SqlDataReader reader;

        List<Object[]> returns = new List<object[]>();

        try
        {
            connection.Open();
            cmd = new SqlCommand();
            cmd.Connection = connection;
            cmd.CommandText = query;
            reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Object[] values = new Object[parameters.Length];
                for(int i = 0; i < parameters.Length; i++)
                {
                    values[i] = reader[parameters[i]];
                }

                returns.Add(values);
            }
        }
        catch (Exception e){}
        finally
        {
            cmd = null;
            reader = null;
            connection.Close();
        }

        return returns;
    }

    public Game GetGameOfID(string id, string root)
    {
        Object[] values = GetQueryResult(
                "SELECT * FROM Games WHERE GameID='" + id + "'",
                new string[] { "GameName", "GameID", "AuthorID"});
        if (values == null) return null;

        Game returns = new Game(
            values[2].ToString(),
            values[1].ToString(),
            root);
        returns.gameName = values[0].ToString();
       
        return returns;

    }

}