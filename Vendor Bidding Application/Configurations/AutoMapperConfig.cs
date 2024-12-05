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
            CreateMap<CreateProjectDTO, Project>().ReverseMap();
            CreateMap<VendorDTO, Vendor>().ReverseMap();
            CreateMap<CreateVendorDTO, Vendor>().ReverseMap().ForMember(n => n.Password, opt => opt.MapFrom(n => n.PasswordHash)); ;
            CreateMap<VendorLoginDTO, Vendor>().ReverseMap().ForMember(n => n.Password, opt => opt.MapFrom(n => n.PasswordHash)); 
            CreateMap<BidDTO, Bid>().ReverseMap();
            CreateMap<CreateBidDTO, Bid>().ReverseMap();
        }
    }
}
