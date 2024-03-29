﻿using SQLite;

namespace Countr.Core.Models
{
    public class Counter
    {
        [PrimaryKey, AutoIncrement]
        public int? Id { get; set; }

        public string Name { get; set; }
        public int Count { get; set; }
        public string Account{get; set; }
        public string Password { get; set; }
    }
}