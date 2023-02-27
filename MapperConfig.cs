using AutoMapper;
using dumplingsOrderBackend.Models;
using Google.Cloud.Firestore;

namespace dumplingsOrderBackend
{
    public class MapperConfig: Profile
    {
        public MapperConfig()
        {
            // from ItemDto to item(cloudstore)
            CreateMap<ItemDto, Item>()
                .ForMember(dest => dest.updatedTime, opt => opt.MapFrom(x => Timestamp.GetCurrentTimestamp()));

            CreateMap<DocumentSnapshot, ItemDto>()
                .ForMember(dest => dest.id, opt => opt.MapFrom(x => x.Id))
                .ForMember(dest => dest.name, opt => opt.MapFrom(x => x.GetValue<string>("name")))
                .ForMember(dest => dest.unit, opt => opt.MapFrom(x => x.GetValue<int>("unit")))
                .ForMember(dest => dest.price, opt => opt.MapFrom(x => x.GetValue<int>("price")))
                .ForMember(dest => dest.memo, opt => opt.MapFrom(x => x.GetValue<string>("memo")));
        }
    }
}