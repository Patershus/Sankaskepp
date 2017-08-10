using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace sankaskepp
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }

        protected void ButtonEasy_Click(object sender, EventArgs e)
        {
            Session["difficulty"] = 1;
            Server.Transfer($"Game.aspx");

        }

        protected void ButtonMedium_Click(object sender, EventArgs e)
        {
            Session["difficulty"] = 2;
            Server.Transfer($"Game.aspx");

        }

        protected void ButtonHard_Click(object sender, EventArgs e)
        {
            Session["difficulty"] = 3;
            Server.Transfer($"Game.aspx");

        }
    }
}