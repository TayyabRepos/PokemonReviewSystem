using AutoMapper;
using PokemonReviewSystem.DTO;
using PokemonReviewSystem.Models;

namespace PokemonReviewSystem.Profiles
{
    public class MapperProfiles : Profile
    {
        public MapperProfiles()
        {
            CreateMap<Pokemon, PokemonDto>();
        }
    }
}
