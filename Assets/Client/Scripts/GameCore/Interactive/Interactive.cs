using UnityEngine;
using UnityEngine.Events;

namespace GameCore
{
    public abstract class Interactive : MonoBehaviour
    {
        public UnityEvent OnContact = new UnityEvent();

        public virtual void TriggerOverlap(GameObject overlapObject)
        {

        }

        public virtual void CollisionEnter(GameObject enterObject)
        {

        }

        private void OnTriggerEnter(Collider other) 
        {
            OnContact.Invoke();
            TriggerOverlap(other.gameObject);
        }

        private void OnCollisionEnter(Collision other) 
        {
            OnContact.Invoke();
            CollisionEnter(other.gameObject);
        }
    }
}
