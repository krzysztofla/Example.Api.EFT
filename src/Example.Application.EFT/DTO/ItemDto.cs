﻿namespace Example.Application.EFT.DTO
{
    public class ItemDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public int Value { get; set; }

        public string Price { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }
}
