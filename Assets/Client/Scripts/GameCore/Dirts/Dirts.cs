using System.Collections;
using UnityEngine;


namespace GameCore
{
    public class Dirts : MonoBehaviour, Damageable
    {
        [SerializeField] private float strength;

        private float currentStrength;
        
        [Tooltip("Force for shards")]
        [SerializeField] private float explosionForce;

        [SerializeField] private Rigidbody[] m_ShardsRigidBodies;

        private bool activeState = true;
        public bool IsDestroy{ get; private set;}

        private Transform thisTransform;
        private Vector3 rayPosition;

        [SerializeField] private Building m_Building;

        private void Start() 
        {
            thisTransform = GetComponent<Transform>();
            currentStrength = strength;
        }

        public void ApplyDamage(float damage, Vector3 hitPoint)
        {
            if(activeState == false)
                return;

            if(currentStrength <= 0.0f)
            {
                activeState = false;
                SetKinematicState(false);
                rayPosition = hitPoint;
                AddExplosion();
                StartCoroutine(FlyShard());
            }else
            {
                currentStrength -= damage;
            }
        }

        private IEnumerator FlyShard()
        {
            var timer = 2.0f;
            
            while(timer > 0.0f)
            {
                timer -= Time.deltaTime;
                yield return null;
            }

            SetKinematicState(true);
            IsDestroy = true;
            m_Building.OnApply?.Invoke();
            gameObject.SetActive(false);
        }

        private void AddExplosion()
        {
            foreach(var rb in m_ShardsRigidBodies)
            {
                rb.AddExplosionForce(Random.Range(0.1f, 0.01f), rayPosition, 10.0f);
            }
        }

        private void SetKinematicState(bool state)
        {
            foreach(var rb in m_ShardsRigidBodies)
                rb.isKinematic = state;
        }
    }
}
