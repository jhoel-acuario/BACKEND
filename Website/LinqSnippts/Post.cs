using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSnippts
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }= string.Empty;   
        public string Description { get; set; } = string.Empty;
        public DateTime Created { get; set; }
        public List<Comment> Comments { get; set; }= new List<Comment>();
    }
}
