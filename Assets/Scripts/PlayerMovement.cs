using Assets.Scripts.World.Entities;
using Assets.Scripts.World.Map;
using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovement : MonoBehaviour
    {
        private Entity _player;

        public void SetPlayer(Entity player)
        {
            _player = player;
        }

        private void OnMoveUp()
        {
            Move(Direction.Up);
        }

        private void OnMoveUpLeft()
        {
            Move(Direction.UpLeft);
        }

        private void OnMoveUpRight()
        {
            Move(Direction.UpRight);
        }

        private void OnMoveDown()
        {
            Move(Direction.Down);
        }

        private void OnMoveDownLeft()
        {
            Move(Direction.DownLeft);
        }

        private void OnMoveDownRight()
        {
            Move(Direction.DownRight);
        }

        private void OnMoveLeft()
        {
            Move(Direction.Left);
        }

        private void OnMoveNone()
        {
            Move(Direction.None);
        }

        private void OnMoveRight()
        {
            Move(Direction.Right);
        }

        private void Move(Direction direction)
        {
            _player.Move(direction);
        }        
    }
}