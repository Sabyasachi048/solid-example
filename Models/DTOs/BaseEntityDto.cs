﻿namespace SolidExample.Models.DTOs
{
    public class BaseEntityDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
