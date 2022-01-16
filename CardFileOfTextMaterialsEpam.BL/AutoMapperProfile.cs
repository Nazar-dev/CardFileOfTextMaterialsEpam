﻿using System.Linq;
using AutoMapper;
using CardFileOfTextMaterialsEpam.BL.Models;
using CardFileOfTextMaterialsEpam.BL.Models.Auth;
using CardFileOfTextMaterialsEpam.DAL.Entities;
using CardFileOfTextMaterialsEpam.DAL.Entities.Auth;


namespace CardFileOfTextMaterialsEpam.BL
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookModel>().ReverseMap();
            CreateMap<Category, CategoryModel>().ReverseMap();           
            CreateMap<Card, CardModel>().ReverseMap();
            // CreateMap<Card, CardModel>()
            //     .ForMember(c => c.BooksIds, 
            //     p => p.MapFrom(book => book.Books.Select(x=>x.BookId)))
            //     .ReverseMap();
            //
            // CreateMap<Person,PersonModel>()
            //     .ForMember(u => u.CardIds,
            //         b => b.MapFrom(user => user.Cards.Select(x=>x.CardId))).ReverseMap();
            CreateMap<UserSignUpModel, User>()
                .ForMember(u => u.UserName,
                    opt => opt.MapFrom(ur => ur.Email));
        }
    }
}
