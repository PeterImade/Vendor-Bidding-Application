using AutoMapper; 
using Vendor_Bidding_Application.DTOs;
using Vendor_Bidding_Application.Models;

namespace Vendor_Bidding_Application.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ProjectDTO, Project>().ReverseMap();
            CreateMap<VendorDTO, Vendor>().ReverseMap();
            CreateMap<BidDTO, Bid>().ReverseMap();
        }
    }
}
