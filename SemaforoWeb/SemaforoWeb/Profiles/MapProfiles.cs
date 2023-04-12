using AutoMapper;
using Microsoft.AspNetCore.Http;
using Semaforo.Logic.BO;
using Semaforo.Logic.Models;
using SemaforoWeb.DTO;
using SemaforoWeb.DTO.CatalogsDTO;
using SemaforoWeb.DTO.CatalogsDTO.Catalogs;
using System;

namespace SemaforoWeb.Profiles
{
    public class MapProfiles : Profile
    {
        private byte[] mapFile(IFormFile file) {
            if (file == null) return null;
            using (var stream = new System.IO.MemoryStream())
            {
                file.CopyTo(stream);
                return stream.ToArray();
            }
        }
        public MapProfiles()
        {
            CreateMap<Provider, ProviderBO>();
            CreateMap<ProviderBO, Provider>();
            CreateMap<ProviderBO, ProviderDTO>();
            CreateMap<ProviderDTO, ProviderBO>();

            CreateMap<Client, ClientBO>()
                .ForMember(dest => dest.EmployeeName, opt => opt.MapFrom(src => src.Employee.Name))
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.LastName + " " + src.LastNameMother + " " + src.Name));
            CreateMap<ClientBO, Client>()
                .ForMember(dest => dest.LastModify, opt => opt.MapFrom(src => DateTime.UtcNow));
            CreateMap<ClientBO, ClientDTO>()
                .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.ProfileImage.Length > 0 ? src.ProfileImage : null));
            CreateMap<ClientDTO, ClientBO>()
                .ForMember(dest => dest.ProfileImage, opt => opt.MapFrom(src => mapFile(src.Image)))
                .ForMember(dest => dest.Files, opt => opt.MapFrom(src => src.Files));

            CreateMap<ClientCategory, ClientCategoryBO>();
            CreateMap<ClientCategoryBO, ClientCategory>();
            CreateMap<ClientCategoryBO, ClientCategoryDTO>();
            CreateMap<ClientCategoryDTO, ClientCategoryBO>();

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

            
            CreateMap<FileBO, File>();
            CreateMap<File, FileBO>()
                .ForMember(dest => dest.Archive, opt => opt.Ignore());
            CreateMap<FileBO, FileDTO>();
            CreateMap<FileDTO, FileBO>();
            CreateMap<IFormFile, FileDTO>()
                .ForMember(dest => dest.Archive, opt => opt.MapFrom(src => mapFile(src)))
                .ForMember(dest => dest.Size, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.FieldType, opt => opt.MapFrom(src => src.Name));


        }
    }
}
