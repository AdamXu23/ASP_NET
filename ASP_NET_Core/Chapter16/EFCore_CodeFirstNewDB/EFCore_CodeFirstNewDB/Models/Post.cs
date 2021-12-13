﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EFCore_CodeFirstNewDB.Models
{
    public class Post
    {
        public int PostId { get; set; } //Primary Key
        public string Title { get; set; }
        public string Content { get; set; }
        public int BlogId { get; set; } //Foreign Key欄位

        //Navigation Property導覽屬性
        public virtual Blog Blog { get; set; }
    }
}
