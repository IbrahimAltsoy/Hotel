﻿namespace Hotel.WebUI.Dtos.Subscribe
{
    public class ResultSubscribeDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
