using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sankaskepp
{
    public partial class LoadGame : System.Web.UI.Page
    {
        public List<SavedGame> savedGames = new List<SavedGame>();

        protected void Page_Load(object sender, EventArgs e)
        {
            savedGames = SQLConnection.GetSavedGames();
            string literalString = "<ul>";

            foreach (var save in savedGames)
            {
                literalString += $"<li><a href='Game.aspx?action=load&saveId={save.ID}'><input type='button' onclick value='Load'/> Save id: {save.ID}, Saved: {save.Date}</li>";
            }

            literalString += "</ul>";

            savedGamesLiteral.Text = literalString;
        }
    }
}