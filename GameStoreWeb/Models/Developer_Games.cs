﻿namespace GameStoreWeb.Models
{
    public class Developer_Games
    {
        public int GamesId { get; set; }
        public int DeveloperId { get; set; }
        public Game Games { get; set; }
        public Developer Developer { get; set; }
    }
}