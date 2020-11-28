using System;

namespace CrossWordApp
{
	public struct Position
	{
		public int x;
		public int y;

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public static bool operator ==(Position a, Position b) => a.x == b.x && a.y == b.y;

		public static bool operator !=(Position a, Position b) => a.x != b.x || a.y != b.y;
	}

    public struct OrientedWord
    {
        public Position position;
        public int length;
        public Orientation orientation;
    }

    public enum Orientation
    {
        UP,
        DOWN,
        LEFT,
        RIGHT
    }
}