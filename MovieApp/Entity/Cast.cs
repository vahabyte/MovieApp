﻿namespace MovieApp.Entity
{
    public class Cast
    {

        public int CastId { get; set; }
        public Movie Movie { get; set; }
        public int MovieId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }



    }
}
