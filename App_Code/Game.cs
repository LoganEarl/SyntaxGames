using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Drawing;

namespace Games
{
    public class Game
    {
        private const string sourceFileName = "psCode.txt";
        private const string thumbnailFileName = "thumbnail.png";

        public string gameName { set; get; }
        public string gameID { set; get; }
        public string authorID { set; get; }
        public string sourceCode { set; get; }

        private string rootFileLocation;

        public Game(string authorID, string gameID, string rootFileLocation)
        {
            this.authorID = authorID;
            this.gameID = gameID;
            this.rootFileLocation = rootFileLocation;
        }

        public Game(string authorID, string name, string sourceCode, string rootFileLocation)
        {
            this.gameName = name;
            this.authorID = authorID;
            this.sourceCode = sourceCode;
            this.gameID = DateTime.Now.ToString("yyyyMMddHHmmssffff");
            this.rootFileLocation = rootFileLocation;
        }

        public bool WriteGameToFileSystem()
        {
            if (SourceExists()) return true;

            if (sourceCode.Equals("")) return false;

            return CreateSourceFile(sourceCode);
        }

        public bool SourceExists()
        {
            return File.Exists(GetFullFilePath());
        }

        public bool DirectoryExists()
        {
            return Directory.Exists(GetFullDirectory());
        }

        private bool CreateSourceFile(string sourceCode)
        {
            try
            {
                if (!DirectoryExists())
                    Directory.CreateDirectory(GetFullDirectory());

                if (!SourceExists())
                {
                    FileStream f = File.Create(GetFullFilePath());
                    f.Close();
                }

                File.WriteAllText(GetFullFilePath(), sourceCode);
                return true;
            }
            catch (IOException)
            {
                return false;
            }
        }

        public string GetPartialFilePath()
        {
            return GetFileDirectory() + "/" + sourceFileName;
        }

        public string GetFullFilePath()
        {
            return rootFileLocation + "/" + GetFileDirectory() + "/" + sourceFileName;
        }

        public string GetFullDirectory()
        {
            return rootFileLocation + "/" + GetFileDirectory();
        }

        private string GetFileDirectory()
        {
            return "Games/" + authorID + "/" + gameID;
        }

        public string GetThumbnailDirectory()
        {
            return GetFileDirectory() + "/" + thumbnailFileName;
        }
    }
}


