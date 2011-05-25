using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LyricMania
{
    class LyricLine
    {
        public LyricLine(string timestamp, string line )
        {
            this.timestamp = timestamp;
            this.line = line;
        }

        string timestamp, line;

        public override string ToString( )
        {
            return "[" + timestamp + "]" + line;
        }
    }
}
