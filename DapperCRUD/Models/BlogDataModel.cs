using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Models
{
    public class BlogDataModel
    {
        public int BlogId { get; set; }

        public string BlogTitle { get; set; } = string.Empty;

        public string BlogAuthor { get; set; } = string.Empty;

        public string BlogContent { get; set; } = string.Empty;

        public bool DeleteFlag { get; set; }

    }
}
