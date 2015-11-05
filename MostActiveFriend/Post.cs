using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MostActiveFriend
{
    public class Post
    {

        public long from_id { get; set; }
        public long to_id { get; set; }

        public Post()
        {
            from_id = new long();
            to_id = new long();
        }
    }
}
