﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManager.Entities.Abstract;

namespace TaskManager.Entities.Concrete
{
    public class RefreshToken : IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Token { get; set; }
    }
}
