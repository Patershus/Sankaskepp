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
        protected void Page_Load(object sender, EventArgs e)
        {
            int size = 7;

            string gameBoardLiteralString = "";

            gameBoardLiteralString += "<table id='gameBoardTable'><tr>";

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    gameBoardLiteralString += "<td><input type='button' class='gameButton'/></td>";


                }
                gameBoardLiteralString += "</tr>";
            }

            gameBoardLiteralString += "</table>";

            gameBoardLiteral.Text = gameBoardLiteralString;


        }
    }
}