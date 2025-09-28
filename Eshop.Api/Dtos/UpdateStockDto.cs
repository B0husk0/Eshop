﻿using System.ComponentModel.DataAnnotations;

namespace Eshop.Api.Dtos
{
    public class UpdateStockDto
    {
        [Range(0, int.MaxValue, ErrorMessage = "Quantity must be non-negative.")]
        public int Quantity { get; set; }
    }
}
