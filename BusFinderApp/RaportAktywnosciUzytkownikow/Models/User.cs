﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaportAktywnosciUzytkownikow.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public DateTime Time { get; set; }
    }
}
