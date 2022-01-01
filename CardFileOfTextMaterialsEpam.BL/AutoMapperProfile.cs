using System.Linq;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Entities;


namespace CardFileOfTextMaterialsEpam.BL
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Card, CardModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<User,UserModel>().ReverseMap();
        }
    }
}
