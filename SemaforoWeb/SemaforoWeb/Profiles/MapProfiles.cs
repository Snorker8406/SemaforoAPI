using AutoMapper;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using SemaforoWeb.DTO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SemaforoWeb.Profiles
{
    public class MapProfiles : Profile
    {
        public MapProfiles()
        {
            CreateMap<Provider, ProviderBO>();
            CreateMap<ProviderBO, Provider>();
            CreateMap<ProviderBO, ProviderDTO>();
            CreateMap<ProviderDTO, ProviderBO>();

            CreateMap<Client, ClientBO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.LastName + " " + src.LastNameMother + " " + src.Name));
            CreateMap<ClientBO, Client>();
            CreateMap<ClientBO, ClientDTO>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName));
            CreateMap<ClientDTO, ClientBO>();

            CreateMap<Brand, BrandBO>();
            CreateMap<BrandBO, Brand>();
            CreateMap<BrandBO, BrandDTO>();
            CreateMap<BrandDTO, BrandBO>();

            CreateMap<Employee, EmployeeBO>();
            CreateMap<EmployeeBO, Employee>();
            CreateMap<EmployeeDTO, EmployeeBO>();
            CreateMap<EmployeeBO, EmployeeDTO>();

            CreateMap<Product, ProductBO>();
            CreateMap<ProductBO, ProductDTO>();

            CreateMap<Brand, BrandBO>();
            CreateMap<BrandBO, BrandDTO>();

            CreateMap<Category, CategoryBO>();
            CreateMap<CategoryBO, CategoryDTO>();

            CreateMap<Size, SizeBO>();
            CreateMap<SizeBO, SizeDTO>();

            CreateMap<AccountStatus, AccountStatusBO>();
            CreateMap<AccountStatusBO, AccountStatusDTO>();

            CreateMap<AccountType, AccountTypeBO>();
            CreateMap<AccountTypeBO, AccountTypeDTO>();

            CreateMap<ClientStatus, ClientStatusBO>();
            CreateMap<ClientStatusBO, ClientStatusDTO>();

            CreateMap<Embroidery, EmbroideryBO>();
            CreateMap<EmbroideryBO, EmbroideryDTO>();

            CreateMap<ProductCombo, ProductComboBO>();
            CreateMap<ProductComboBO, ProductComboDTO>();

            CreateMap<SchoolLevel, SchoolLevelBO>();
            CreateMap<SchoolLevelBO, SchoolLevelDTO>();

            CreateMap<School, SchoolBO>();
            CreateMap<SchoolBO, SchoolDTO>();

            CreateMap<Site, SiteBO>();
            CreateMap<SiteBO, SiteDTO>();

            CreateMap<ApplicationUser, ApplicationUserBO>()
                .ForMember(dest => dest.AppUserId, opt => opt.MapFrom(src => src.Id));
            CreateMap<ApplicationUserBO, ApplicationUserDTO>();
            CreateMap<ApplicationUserDTO, ApplicationUserBO>();
                

            CreateMap<ApplicationUserBO, Employee>();
            CreateMap<ApplicationUserBO, EmployeeDTO>();

            
        }
    }
}
