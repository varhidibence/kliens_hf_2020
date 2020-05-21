﻿using System;
using System.Collections.Generic;
using System.Text;

namespace GameOhThrones.Core.Models
{
    /// <summary>
    /// Data class of book in Game of Thrones world
    /// </summary>
    public class Book
    {
        public string url { get; set; }
        public string name { get; set; }
        public string isbn { get; set; }
        public string[] authors { get; set; }
        public int numberOfPages { get; set; }
        public string publisher { get; set; }
        public string country { get; set; }
        public string mediaType { get; set; }
        public DateTime released { get; set; }
        public List<string> characters { get; set; }
        public List<string> povCharacters { get; set; }
    }

}
