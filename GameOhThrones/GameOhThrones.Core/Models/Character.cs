using System;
using System.Collections.Generic;
using System.Text;

namespace GameOhThrones.Core.Models
{

    public class Character
    {
        public string url { get; set; }
        public string name { get; set; }
        public string gender { get; set; }
        public string culture { get; set; }
        public string born { get; set; }
        public string died { get; set; }
        public List<string> titles { get; set; }
        public List<string> aliases { get; set; }
        public Character father { get; set; }
        public Character mother { get; set; }
        public List<Character> spouse { get; set; }
        public List<House> allegiances { get; set; }
        public List<Book> books { get; set; }
        public List<Book> povBooks { get; set; }
        public List<string> tvSeries { get; set; }
        public List<string> playedBy { get; set; }

        public override string ToString()
        {
            return name;
        }
    }

}
