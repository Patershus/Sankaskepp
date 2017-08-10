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

            gameBoardLiteral.Text = gameBoardLiteralString;


        }
    }
}