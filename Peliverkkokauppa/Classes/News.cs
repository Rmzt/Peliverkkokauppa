using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Peliverkkokauppa
{
    public class News
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTimeOffset Date { get; set; }
        public string StringDate { get; set; }

        public News(string title, string content, DateTimeOffset date)
        {
            Title = title;
            Content = content;
            Date = date;
            StringDate = Date.ToString("MMMM dd, yyyy");
        }


    }
}
