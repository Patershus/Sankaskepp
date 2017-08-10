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


            int levelOfDifficulty = 0;
            Session["difficulty"] = 1; //todo ta bort denna för att kunna välja level

            if (Session["difficulty"] != null)
            {
                levelOfDifficulty = Convert.ToInt32(Session["difficulty"].ToString());
                gameBoardLiteral.Text = GenerateGamefield(levelOfDifficulty);
            }
            else
            {
                gameBoardLiteral.Text = "Something broke";
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

            return gameBoardLiteralString;
        }
    }
}