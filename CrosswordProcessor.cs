using System;
using System.Collections.Generic;
using System.Text;

namespace CrossWordApp
{
	public class CrossWordProcessor
	{
		CrossWord _crossWord;
		public CrossWordProcessor(CrossWord crossWord)
		{
			_crossWord = crossWord;
		}

		public void FindWordLocations(Position startPosition, List<Position> visited, Stack<OrientedWord> path)
		{
			if (visited == null) visited = new List<Position>();
			if (path == null) path = new Stack<OrientedWord>();
			visited.Add(startPosition);
			Stack<Position> surroundingLocations = GetSurroundingLocations(startPosition);

			if (_crossWord[startPosition.x, startPosition.y] == '-')
            {
				var word = GetOrientedWord(startPosition);
				path.Push(word);
            }
			
			while(surroundingLocations.Count > 0)
            {
				var pos = surroundingLocations.Pop();
				if (visited.Contains(pos)) 
					continue;
				FindWordLocations(pos, visited, path);
            }

			if(surroundingLocations.Count == 0)
            {
				return;
            }
			
			
		}

		public OrientedWord GetOrientedWord(Position position)
        {
            var surroundingPositions = GetSurroundingLocations(position);
            var positions = GetPositionsWithLetters(surroundingPositions);
			var nextPos = positions.Pop();
			return GetPositionOrientation(position, nextPos);
        }

        private OrientedWord GetPositionOrientation(Position position, Position nextPos)
        {
			OrientedWord orientedWord;
			orientedWord.position = position;
			if (nextPos.x > position.x)
			{
				orientedWord.orientation = Orientation.RIGHT;
			}
			else if (nextPos.x < position.x)
			{
				orientedWord.orientation = Orientation.LEFT;
			}
			else if (nextPos.y > position.y)
			{
				orientedWord.orientation = Orientation.DOWN;
			}
			else if (nextPos.y < position.y)
			{
				orientedWord.orientation = Orientation.UP;
			}
			else
				orientedWord.orientation = Orientation.LEFT;

			orientedWord.length = GetLength(position, orientedWord.orientation);
			return orientedWord;
        }

        public int GetLength(Position position, Orientation orientation)
        {
			int a = 0;
			int d = 0;
			int length = 0;
			int x = position.x;
			int y = position.y;

			if (orientation == Orientation.LEFT)
            {
				d = -1;
				a = 1;
            }else if (orientation == Orientation.RIGHT)
            {
				d = 1;
				a = 1;
            }else if (orientation == Orientation.UP)
            {
				d = -1;
            }else if (orientation == Orientation.DOWN)
            {
				d = 1;
            }

			while(x >= 0 && x < 10 && y >= 0 && y < 10 && _crossWord[x, y] == '-')
            {
				length++;
				if (a == 1)
					x += d;
				else
					y += d;
            }
			return length;
		}

        private Stack<Position> GetPositionsWithLetters(Stack<Position> surroundingPositions)
        {
            Stack<Position> goodPositions = new Stack<Position>();
            while (surroundingPositions.Count > 0)
            {
                var adjacentPos = surroundingPositions.Pop();
                if (PositionContainsLetter(adjacentPos))
                {
                    goodPositions.Push(adjacentPos);
                }
            }
			return goodPositions;
        }

        public bool PositionContainsLetter(Position pos)
        {
			return _crossWord[pos.x, pos.y] == '-';
        }

		public Stack<Position> GetSurroundingLocations(Position startPosition)
		{
			Stack<Position> stack = new Stack<Position>();
			Position nextX = startPosition;
			nextX.x += 1;
			if(nextX.x < 10)
				stack.Push(nextX);
			nextX = startPosition;
			nextX.y += 1;
			if (nextX.x >= 0 && nextX.y < 10)
				stack.Push(nextX);
			nextX = startPosition;
			nextX.y -= 1;
			if (nextX.x >= 0 && nextX.y >= 0)
				stack.Push(nextX);
			nextX = startPosition;
			nextX.x -= 1;
			if (nextX.x >= 0 && nextX.y >= 0)
				stack.Push(nextX);
			return stack;
		}
	}
}
