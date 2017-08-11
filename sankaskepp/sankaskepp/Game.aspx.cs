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
                //Session["difficulty"] = 1; //todo ta bort denna för att kunna välja level

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
            switch (levelOfDifficulty)

            {

                case 1:
                    return GenerateNoobGameFeild();                
                    
                case 2:
                    return GenerateIntermediateGameFeild();
                case 3:
                    return GenerateProGameFeild();
                default:
                    return "";
                    
            }

            
        }

        //Todo
        private string GenerateNoobGameFeild()
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

            gameBoardLiteralString += "  <table style='width:100%'><tr><td><span id='ContentPlaceHolder1_ShotLabel'>Shots</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ShotCounter'>0</span></td></tr>";
            gameBoardLiteralString += "<tr><td><span id='ContentPlaceHolder1_ScoreLabel'>Score</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ScoreCounterLabel'>0</span>";
            gameBoardLiteralString += "</td></tr></table>";

            return gameBoardLiteralString;

           
        }
        //Todo
        private string GenerateIntermediateGameFeild()
        {
            int size = 20;

            //Skepp 2 rutor

            int shipRowStart = rng.Next(1, size - 1);
            int shipColStart = rng.Next(1, size - 1);
            int shipRowSecond;
            int shipColSecond;

            if (rng.Next(0,2)==1)
            {
                shipRowSecond = shipRowStart;

                if (rng.Next(0,2)==1)
                {
                    shipColSecond = shipColStart + 1;
                }
                else
                {
                    shipColSecond = shipColStart - 1;
                }

            }
            else
            {
                shipColSecond = shipColStart;
                if (rng.Next(0, 2) == 1)
                {
                    shipRowSecond = shipRowStart + 1;
                }
                else
                {
                    shipRowSecond = shipRowStart - 1;
                }
            }


            //Ubåtar
            int row;
            int col;
            int row2;
            int col2;
            do
            {
                row = rng.Next(0, size);
                col = rng.Next(0, size);

                row2 = rng.Next(0, size); // todo kan bli samma, fixa sen
                col2 = rng.Next(0, size);
            } while (false);
            



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
                    else if (j==shipColStart && i==shipRowStart || j==shipColStart&& i==shipRowSecond || j==shipColSecond&&i==shipRowStart||j==shipColSecond&&i==shipRowSecond)
                    {
                        gameBoardLiteralString += "<td><input type='button' class='gameButtonShip'/></td>";
                        continue;
                    }
                    
                    else
                    gameBoardLiteralString += "<td><input type='button' class='gameButton'/></td>";

                }
                gameBoardLiteralString += "</tr>";
            }

            gameBoardLiteralString += "</table>";

            gameBoardLiteralString += "  <table style='width:100%'><tr><td><span id='ContentPlaceHolder1_ShotLabel'>Shots</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ShotCounter'>0</span></td></tr>";
            gameBoardLiteralString += "<tr><td><span id='ContentPlaceHolder1_ScoreLabel'>Score</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ScoreCounterLabel'>0</span>";
            gameBoardLiteralString += "</td></tr></table>";

            return gameBoardLiteralString;


          
        }

        //Todo
        private string GenerateProGameFeild()
        {

            int size = 30;
            //Hangaren
            int hangarRowStart = rng.Next(2, size - 2);
            int hangarColStart = rng.Next(2, size - 2);
            int hangarRowSecond;
            int hangarColSecond;
            int hangarRowThird;
            int hangarColThird;


            if (rng.Next(0, 2) == 1)
            {
                hangarRowSecond = hangarRowStart;
                hangarRowThird = hangarRowStart;

                if (rng.Next(0, 2) == 1)
                {
                    hangarColSecond = hangarColStart + 1;
                    hangarColThird = hangarColStart+2;
                }
                else
                {
                    hangarColSecond = hangarColStart - 1;
                    hangarColThird = hangarColStart - 2;

                }

            }
            else
            {
                hangarColSecond = hangarColStart;
                hangarColThird = hangarColStart;
                if (rng.Next(0, 2) == 1)
                {
                    hangarRowSecond = hangarRowStart + 1;
                    hangarRowThird = hangarRowStart + 2;
                }
                else
                {
                    hangarRowSecond = hangarRowStart - 1;
                    hangarRowThird = hangarRowStart - 2;

                }
            }

            //Skepp 2 rutor

            int shipRowStart = rng.Next(1, size - 1);
            int shipColStart = rng.Next(1, size - 1);
            int shipRowSecond;
            int shipColSecond;

            if (rng.Next(0, 2) == 1)
            {
                shipRowSecond = shipRowStart;

                if (rng.Next(0, 2) == 1)
                {
                    shipColSecond = shipColStart + 1;
                }
                else
                {
                    shipColSecond = shipColStart - 1;
                }

            }
            else
            {
                shipColSecond = shipColStart;
                if (rng.Next(0, 2) == 1)
                {
                    shipRowSecond = shipRowStart + 1;
                }
                else
                {
                    shipRowSecond = shipRowStart - 1;
                }
            }


            //Ubåtar
            int row;
            int col;
            int row2;
            int col2;
            do
            {
                row = rng.Next(0, size);
                col = rng.Next(0, size);

                row2 = rng.Next(0, size); // todo kan bli samma, fixa sen
                col2 = rng.Next(0, size);
            } while (false);




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
                    else if (j == shipColStart && i == shipRowStart || j == shipColStart && i == shipRowSecond || j == shipColSecond && i == shipRowStart || j == shipColSecond && i == shipRowSecond)
                    {
                        gameBoardLiteralString += "<td><input type='button' class='gameButtonShip'/></td>";
                        continue;
                    }

                    else
                        gameBoardLiteralString += "<td><input type='button' class='gameButton'/></td>";

                }
                gameBoardLiteralString += "</tr>";
            }

            gameBoardLiteralString += "</table>";

            gameBoardLiteralString += "  <table style='width:100%'><tr><td><span id='ContentPlaceHolder1_ShotLabel'>Shots</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ShotCounter'>0</span></td></tr>";
            gameBoardLiteralString += "<tr><td><span id='ContentPlaceHolder1_ScoreLabel'>Score</span></td>";
            gameBoardLiteralString += "<td><span id='ContentPlaceHolder1_ScoreCounterLabel'>0</span>";
            gameBoardLiteralString += "</td></tr></table>";

            return gameBoardLiteralString;
        }

    }
}