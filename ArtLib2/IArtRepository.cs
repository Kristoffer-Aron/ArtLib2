
namespace ArtLib2
{
    public interface IArtRepository
    {
        Art AddArt(Art art);
        Art? DeleteArt(int id);
        List<Art> GetAll();
        Art? GetById(int id);
    }
}