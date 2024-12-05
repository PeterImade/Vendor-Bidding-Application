﻿using System.ComponentModel.DataAnnotations;

namespace Vendor_Bidding_Application.DTOs
{
    public class BidDTO
    {
        public int Id { get; set; }
        public int VendorId { get; set; }
        public int ProjectId { get; set; }
        public decimal Amount { get; set; }
    }
}