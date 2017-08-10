using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sankaskepp
{
    public partial class Game : System.Web.UI.Page
    {
        Random rng = new Random();

        protected void Page_Load(object sender, EventArgs e)
        {
            string action = "";
            string savedString = "";
            if (Request["action"]!=null)
            {
                action = Request["action"];
            }

            if (Request["savedString"] != null)
            {
                savedString = Request["savedString"];

            }

            string decodedString= System.Uri.UnescapeDataString(savedString);
            //gameBoardLiteral.Text = decodedString;

            if (action=="save")
            {
                SQLConnection.SaveGame(savedString);



            }
           
            int saveIdInt=0;
            if (Request["saveId"]!=null)
            {
                saveIdInt = Convert.ToInt32(Request["saveId"]);          
            }


            if (action == "load" && saveIdInt != 0)
            {
                gameBoardLiteral.Text = SQLConnection.GetSaveString(saveIdInt);
            }
            else
            {
                int levelOfDifficulty = 0;
                Session["difficulty"] = 1; //todo ta bort denna för att kunna välja level

                if (Session["difficulty"] != null)
                {
                    levelOfDifficulty = Convert.ToInt32(Session["difficulty"].ToString());
                    gameBoardLiteral.Text = GenerateGamefield(levelOfDifficulty);
                    //gameBoardLiteral.Text = decodedString;
                }
                else
                {
                    gameBoardLiteral.Text = "Something broke";
                }

            }

        }

        private string GenerateGamefield(int levelOfDifficulty)
        {
            int size = 15;
            int row = rng.Next(0, size);
            int col = rng.Next(0, size);

            int row2 = rng.Next(0, size); // todo kan bli samma, fixa sen
            int col2 = rng.Next(0, size);

            string gameBoardLiteralString = "";

            gameBoardLiteralString += "<table id='gameBoardTable'><tr>";

            for (int i = 0; i < size; i++)
            {

                for (int j = 0; j < size; j++)
                {
                    if ((j == col && row == i) || (j == col2 && i == row2))
                    {
                        gameBoardLiteralString += "<td><input type='button' class='gameButtonShip'/></td>";
                        continue;
                    }

                    gameBoardLiteralString += "<td><input type='button' class='gameButton'/></td>";

                }
                gameBoardLiteralString += "</tr>";
            }

            gameBoardLiteralString += "</table>";

            gameBoardLiteralString += "  <table style='width:100%'><tr><td><asp:Label ID='ShotLabel' runat='server' Text='Shots'></asp:Label >";
            gameBoardLiteralString += "</td><td><asp:Label ID = 'ShotCounter' runat = 'server' Text = '0'></asp:Label>";
            gameBoardLiteralString += "</td></tr><tr><td><asp:Label ID = 'ScoreLabel' runat = 'server' Text = 'Score'></asp:Label>";
            gameBoardLiteralString += "</td><td><asp:Label ID = 'ScoreCounterLabel' runat = 'server' Text ='0'></asp:Label>";
            gameBoardLiteralString +="</td></tr></table>";

            return gameBoardLiteralString;
        }

        //Todo
        private string GenerateNoobGameFeild()
        {


            return "";
        }
        //Todo
        private string GenerateIntermediateGameFeild()
        {


            return "";
        }

        //Todo
        private string GenerateProGameFeild()
        {


            return "";
        }

    }
}