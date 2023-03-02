using AutoMapper;
using MovieCharactersAPI.Dtos.Franchises;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Profiles
{
    public class FranchiseProfile : Profile
    {
        public FranchiseProfile()
        {
            CreateMap<FranchisePostDto, Franchise>();
            CreateMap<FranchisePutDto, Franchise>();

            CreateMap<Franchise, FranchiseDto>()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(p => p.Movies.Select(s => s.Title).ToList()));
        }
    }
}