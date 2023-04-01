﻿namespace Hotel.WebUI.Dtos.RoomDto
{
    public class ResultRoomDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public bool IsActive { get; set; } = false;
    }
}
