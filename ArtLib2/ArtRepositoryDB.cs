using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLib2
{
    public class ArtRepositoryDB : IArtRepository
    {
        private readonly ArtRepositoryContext _context;
        public ArtRepositoryDB(ArtRepositoryContext context)
        {
            _context = context;
        }
        public Art AddArt(Art art)
        {
            art.Id = 0; // Ensure EF Core treats this as a new entity
            _context.ArtDB.Add(art);
            _context.SaveChanges();
            return art;
        }

        public Art? DeleteArt(int id)
        {
            var art = GetById(id);
            GetById(id);
            if (art != null)
            {
                _context.ArtDB.Remove(art);
                _context.SaveChanges();
            }
            return art;
        }

        public List<Art> GetAll()
        {
            return _context.ArtDB.ToList();
        }

        public Art? GetById(int id)
        {
            return _context.ArtDB.FirstOrDefault(x => x.Id == id);
        }
    }
}
