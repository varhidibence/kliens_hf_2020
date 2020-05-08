using System;
using System.Collections.Generic;
using System.Text;

namespace GameOhThrones.Core.Models
{

    public class House
    {
        public string url { get; set; }
        public string name { get; set; }
        public string region { get; set; }
        public string coatOfArms { get; set; }
        public string words { get; set; }
        public List<string> titles { get; set; }
        public List<string> seats { get; set; }
        public Character currentLord { get; set; }
        public Character heir { get; set; }
        public House overlord { get; set; }
        public string founded { get; set; }
        public Character founder { get; set; }
        public string diedOut { get; set; }
        public List<string> ancestralWeapons { get; set; }
        public List<House> cadetBranches { get; set; }
        public List<Character> swornMembers { get; set; }
    }

}
