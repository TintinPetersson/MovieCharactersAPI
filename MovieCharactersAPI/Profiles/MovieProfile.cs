using AutoMapper;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<Movie, MovieDto>()
            .ForMember(dto => dto.Characters, opt => opt
            .MapFrom(p => p.Characters.Select(s => s.FullName).ToList()))
            .ForMember(dto => dto.Franchise, opt => opt
            .MapFrom(p => p.FranchiseId));
        }
    }
}