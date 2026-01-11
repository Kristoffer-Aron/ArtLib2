using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ArtLib2
{
    public class ArtRepository : IArtRepository
    {
        private List<Art> _arts = new List<Art>();
        private int _nextId;
        public ArtRepository()
        {
            _arts = new List<Art>();
            {
                _arts.Add(new Art("Mona Lisa", "Painting", 1000000) { Id = 1 });
                _arts.Add(new Art("The Starry Night", "Painting", 2000000) { Id = 2 });
                _arts.Add(new Art("The Thinker", "Sculpture", 1500000) { Id = 3 });
                _arts.Add(new Art("Den Fou", "Painting", 500000) { Id = 4 });
            }
            _nextId = _arts.Max(a => a.Id)+1;
        }
        public List<Art> GetAll()
        {
            return _arts;
        }

        public Art? GetById(int id)
        {
            return _arts.FirstOrDefault(a => a.Id == id);
        }
        public Art AddArt(Art art)
        {
            art.Id = _nextId++;
            _arts.Add(art);
            return art;
        }
        public Art? DeleteArt(int id)
        {
            var itemToDelete = GetById(id);
            if (itemToDelete != null)
            {
                _arts.Remove(itemToDelete);
            }
            return itemToDelete;
        }

    }
}
