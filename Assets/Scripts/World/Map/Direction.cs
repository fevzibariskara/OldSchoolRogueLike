using UnityEngine;

namespace Assets.Scripts.World.Map
{
    public class Direction
    {
        public readonly int DeltaX;
        public readonly int DeltaY;

        static Direction()
        {
            Up = new Direction((int)Vector2.up.x, (int)Vector2.up.y);

            var upLeftDelta = Vector2.up + Vector2.left;
            UpLeft = new Direction((int)upLeftDelta.x, (int)upLeftDelta.y);

            var upRightDelta = Vector2.up + Vector2.right;
            UpRight = new Direction((int)upRightDelta.x, (int)upRightDelta.y);

            Down = new Direction((int)Vector2.down.x, (int)Vector2.down.y);

            var downLeftDelta = Vector2.down + Vector2.left;
            DownLeft = new Direction((int)downLeftDelta.x, (int)downLeftDelta.y);

            var downRightDelta = Vector2.down + Vector2.right;
            DownRight = new Direction((int)downRightDelta.x, (int)downRightDelta.y);

            Left = new Direction((int)Vector2.left.x, (int)Vector2.left.y);

            None = new Direction(0, 0);

            Right = new Direction((int)Vector2.right.x, (int)Vector2.right.y);
        }

        public static Direction Up { get; }
        public static Direction UpLeft { get; }
        public static Direction UpRight { get; }
        public static Direction Down { get; }
        public static Direction DownLeft { get; }
        public static Direction DownRight { get; }
        public static Direction Left { get; }
        public static Direction None { get; }
        public static Direction Right { get; }

        private Direction(int dx, int dy)
        {
            DeltaX = dx;
            DeltaY = dy;
        }
    }
}