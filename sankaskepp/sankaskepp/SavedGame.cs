using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sankaskepp
{
    public class SavedGame
    {
        private int id;

        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        private string html;

        public string HTML
        {
            get { return html; }
            set { html = value; }
        }

        private string date;

        public string Date
        {
            get { return date; }
            set { date = value; }
        }

        public SavedGame(int id, string html, string date)
        {
            ID = id;
            HTML = html;
            Date = date;
        }
    }
}