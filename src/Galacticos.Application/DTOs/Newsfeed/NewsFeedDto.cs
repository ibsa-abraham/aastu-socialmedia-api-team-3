using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Galacticos.Application.DTOs.Newsfeed
{
    public class NewsFeedDto
    {
        public string PostId { get; set; }
        public string Content { get; set; }
        public string AuthorId { get; set; }
        public string AuthorUsername { get; set; }
    }
}