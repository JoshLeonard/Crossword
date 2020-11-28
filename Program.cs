using System;
using System.Collections.Generic;

namespace CrossWordApp
{
    class Program
    {
        static void Main(string[] args)
        {
			string[] data = new string[] {
				"XXXXXX-XXX",
				"XX------XX",
				"XXXXXX-XXX",
				"XXXXXX-XXX",
				"XXX------X",
				"XXXXXX-X-X",
				"XXXXXX-X-X",
				"XXXXXXXX-X",
				"XXXXXXXX-X",
				"XXXXXXXX-X"
			};
			CrossWord crossWord = new CrossWord(data);
			crossWord.Print();
			CrossWordProcessor crossWordProcessor = new CrossWordProcessor(crossWord);

			Position pos;
			pos.x = 0;
			pos.y = 0;

			Stack<OrientedWord> path = new Stack<OrientedWord>();

			crossWordProcessor.FindWordLocations(pos, null, path);
			var d = crossWordProcessor.GetLength(new Position { x = 2, y = 1 }, Orientation.RIGHT);
        }
    }
}
