using UnityEngine;

public class WaterShooting : MonoBehaviour, IShooting
{
    [SerializeField] private float rayCastDistance;
    private float damage;
    private Vector2 screenCenterPosition;

    private Camera m_Camera;

    private void Start() 
    {
        m_Camera = Camera.main;

        screenCenterPosition = new Vector2(Screen.width / 2, Screen.height / 2);
    }

    public void Init(float damage)
    {
        this.damage = damage;
    }

    public void Shoot()
    {
        Ray ray = m_Camera.ScreenPointToRay(screenCenterPosition);
        
        if(Physics.Raycast(ray, out RaycastHit hitInfo, rayCastDistance))
        {
            var damageable = hitInfo.collider.GetComponent<Damageable>();
            if(damageable != null)
                damageable.ApplyDamage(damage, hitInfo.point);
        }
    }
}
