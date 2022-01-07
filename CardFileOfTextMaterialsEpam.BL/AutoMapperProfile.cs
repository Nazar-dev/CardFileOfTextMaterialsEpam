using System.Linq;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Auth;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.DAL.Entities;


namespace CardFileOfTextMaterialsEpam.BL
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();
            CreateMap<Card, CardModel>()
                .ForMember(c => c.BooksIds, 
                p => p.MapFrom(book => book.Books.Select(x=>x.Id)))
                .ReverseMap();

            CreateMap<MyPerson,MyPersonModel>()
                .ForMember(u => u.CardIds,
                    b => b.MapFrom(user => user.Cards.Select(x=>x.Id))).ReverseMap();
            CreateMap<UserSignUpModel, User>()
                .ForMember(u => u.UserName,
                    opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
