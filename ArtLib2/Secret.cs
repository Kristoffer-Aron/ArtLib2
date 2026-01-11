using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtLib2
{
    //static betyder at klassen ikke kan instantieres og kun kan indeholde static medlemmer
    public static class Secret
    {
        // Tilføj din connection string her. Inde i SQL Server Management Studio kan du højreklikke på din database, Properties, og finde connection string under "Connection String".
        private static string _connectionString = "Tilføj Connection String her.";
        public static string ConnectionString
        {
            get { return _connectionString; }
        }
    }
}
