using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceGamewithBet
{
public    class Player3
    {

        Random rd = new Random();
        public int run()
        {
            return rd.Next(1, 15);
        }

    }
}
