using System.Collections.Generic;


namespace FrontEnd.Models
{
    public class GroupedJokes
    {
        public List<Joke> SmallJokes { get; set; }
        public List<Joke> MediumJokes { get; set; }
        public List<Joke> LargeJokes { get; set; }
    }
}