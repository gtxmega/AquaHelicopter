using UnityEngine;

namespace GameCore.Guns
{
    public class WaterGun : MonoBehaviour
    {
        [SerializeField] private float power;

        private IParticalSystemPlay particalSystem;
        private IShooting shooting;

        private void Start() 
        {
            shooting.Init(power);
        }

        private void Update()
        {
            if(Input.GetMouseButton(0))
            {
               shooting.Shoot();
               particalSystem.PlayPartical();
            }else
            {
                particalSystem.StopPartical();
            }
        }

        public void InjectVFX(IParticalSystemPlay _particleSystem)
        {
            particalSystem = _particleSystem;
        }

        public void InjectShooting(IShooting shooting)
        {
            this.shooting = shooting;
        }
    }

}
