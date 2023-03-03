using AutoMapper;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Profiles
{
    public class MovieProfile : Profile
    {
        public MovieProfile()
        {
            CreateMap<MoviePostDto, Movie>();
            CreateMap<MoviePutDto, Movie>();

            CreateMap<Movie, MovieDto>()
            .ForMember(dto => dto.Characters, opt => opt
            .MapFrom(m => m.Characters.Select(c => c.FullName).ToList()))
            .ForMember(dto => dto.Franchise, opt => opt
            .MapFrom(f => f.FranchiseId));
        }
    }
}