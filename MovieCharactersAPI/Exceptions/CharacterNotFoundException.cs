namespace MovieCharactersAPI.Exceptions
{
    public class CharacterNotFoundException : Exception
    {
        public CharacterNotFoundException(int id) : base($"Movie with id: {id} was not found.")
        {
        }
    }
}
