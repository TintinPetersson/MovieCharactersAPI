using AutoMapper;
using MovieCharactersAPI.Dtos.Characters;
using MovieCharactersAPI.Dtos.Movies;
using MovieCharactersAPI.Models;

namespace MovieCharactersAPI.Profiles
{
    public class CharacterProfile: Profile
    {
        public CharacterProfile()
        {
            CreateMap<CharacterPostDto, Character>();
            CreateMap<CharacterPutDto, Character>();

            CreateMap<Character, CharacterDTO>()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(c => c.Movies.Select(m => m.Title).ToList()));
        }
    }
}