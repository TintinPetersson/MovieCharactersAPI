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
            CreateMap<Character, CharacterDTO>()
                .ForMember(dto => dto.Movies, opt => opt
                .MapFrom(p => p.Movies.Select(s => s.Title).ToList()));
        }
    }
}
