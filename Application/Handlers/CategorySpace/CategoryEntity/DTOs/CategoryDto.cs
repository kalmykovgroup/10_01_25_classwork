﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Handlers.CategorySpace.CategoryEntity.DTOs
{
    public class CategoryDto
    {
        public Guid Id { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public string? ImageUrl { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Description { get; set; }

        public int Level { get; set; }

        public string? FullPath { get; set; }

        public List<CategoryDto> SubCategories { get; set; } = new List<CategoryDto>();
    }
}
