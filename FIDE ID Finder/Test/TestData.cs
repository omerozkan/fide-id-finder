using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FIDE_ID_Finder.Model;

namespace FIDE_ID_Finder.Test
{
    public class TestData
    {
        private readonly IList<Player> _players = new List<Player>();

        public TestData()
        {
           var p1 =  new Player();
           p1.Name = "Mustafa";
           p1.Surname = "Yilmaz";
           p1.Birthday = "1992";

           var p2 = new Player();
           p2.Name = "Vahap";
           p2.Surname = "Sanal";
           p2.Birthday = "1998";

           var p3 = new Player();
           p3.Name = "Dragan";
           p3.Surname = "Solak";
           p3.Birthday = "1980";

           var p4 = new Player();
           p4.Name = "Emre";
           p4.Surname = "Can";
           p4.Birthday = "1990";

           var p5 = new Player();
           p5.Name = "Cemil Can";
           p5.Surname = "Ali Marandi";
           p5.Birthday = "1998";

           _players.Add(p1);
           _players.Add(p2);
           _players.Add(p3);
           _players.Add(p4);
           _players.Add(p5);
        }

        public IList<Player> GetPlayers()
        {
            return _players;
        }
    }
}
