﻿namespace Hotel.WebUI.Models.Stuff
{
    public class StuffViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string LinkedinUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string InstagramUrl { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
