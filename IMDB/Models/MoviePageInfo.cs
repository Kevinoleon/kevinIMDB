using System.Collections.Generic;

namespace IMDB.Models
{

    public class MoviePageInfo
    {
        public IList<Movie> PageItems { get; set; }

        public int PageIndex { get; set; }

        public int PageCount { get; set; }

        public string SearchCriteria { get; set; }
    }
}