using System;
using System.Collections.Generic;
using System.Text;

namespace CrossWordApp
{
	public class CrossWord
	{
		private char[] _crossWord;
		public int Length { get; set; }
		public int Width { get; set; }

		public CrossWord(string[] crossWord)
		{
			_crossWord = ConvertToCharArray(crossWord);
		}

		public void Print()
		{
			for (int i = 1; i < _crossWord.Length + 1; i++)
			{
				Console.Write(_crossWord[i - 1]);
				if (i % 10 == 0)
					Console.WriteLine();
			}
		}

		public char this[int x, int y]
		{
			get
			{
				if (x == 0)
					return _crossWord[10 * y];
				if (y == 0)
					return _crossWord[x];

				return _crossWord[10 * y + x];
			}

		}

		private char[] ConvertToCharArray(string[] crossWord)
		{
			int x = crossWord[0].Length;
			int y = crossWord.Length;
			Width = x;
			Length = y;
			char[] charCrossWord = new char[x * y];
			int index = 0;
			foreach (var row in crossWord)
			{
				foreach (var data in row)
				{
					charCrossWord[index++] = data;
				}
			}
			return charCrossWord;
		}
	}
}
