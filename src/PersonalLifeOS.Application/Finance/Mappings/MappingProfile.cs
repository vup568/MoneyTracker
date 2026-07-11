using AutoMapper;
using PersonalLifeOS.Domain.Finance;
using PersonalLifeOS.Application.Finance.DTOs;

namespace PersonalLifeOS.Application.Finance.Mappings
{
    public class MappingProfile : Profile // extend Profile class of AutoMapper
    {
        public MappingProfile(){
            //Mapping from Model -> DTO ( use for Get method)
            // Vì DTO của bạn dùng tên `CategoryDescription` thay vì `Description`, nên phải chỉ định rõ:
            CreateMap<Category, CategoryDto>()
            //Dest là destination 
                    .ForMember(dest => 
                    dest.CategoryDescription, opt => opt.MapFrom(src => src.Description)); // có nghĩa là hãy nhắm tới đích đến là CategoryDescription, lấy dữ liệu từ src và gắn dữ liệu vào thằng destination 
                                                //opt là tùy chọn cấu hình 
            //Map from DTO to Model 

            //syntax of annonymous function => (tham số) => { biểu thức }, anonymous thường dùng cho delegate và event
            CreateMap<CategoryCreateDto, Category>()
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.CategoryDescription));
            
            CreateMap<TransactionCreateDto, Transaction>();

            CreateMap<Transaction, TransactionDto>()
                .ForMember(dest => dest.TransactionName, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.TransactionType, opt => opt.MapFrom(src => src.Type.ToString()))
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category == null ? null : src.Category.CategoryName));


                 

        }
    }
}
