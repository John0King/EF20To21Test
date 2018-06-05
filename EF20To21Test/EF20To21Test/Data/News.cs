using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EF20To21Test.Data
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset AddTime { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
