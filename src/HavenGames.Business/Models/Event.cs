﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HavenGames.Business.Models
{
    public class Event:BaseEntity
    {
        public string Name { get; set; }
        public string Imagem { get; set; }
        public string Description { get; set; }
        public  string Location { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<Ticket> Tickets { get; set; }
    }
}
