using UnityEngine;

namespace GameCore
{
    public class Helicopter : MonoBehaviour
    {
        private IMovement movementSystem;

        public void InjectMovementSystem(IMovement movementSystem)
        {
            this.movementSystem = movementSystem;
        }

    }
}
