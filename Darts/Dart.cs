using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Darts
{
    public class Dart
    {
        public int Throw(Random random)
        {
            int boardNum = random.Next(0, 21);
            return boardNum;
        }
    }
}