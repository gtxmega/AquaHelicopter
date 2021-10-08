using UnityEngine;

public class WaterGunVFX : MonoBehaviour, IParticalSystemPlay
{
    [SerializeField] private Hovl_Laser2 hoverLaser;

    public void PlayPartical()
    {
        hoverLaser.gameObject.SetActive(true);
        hoverLaser.PlayVFX();
    }

    public void StopPartical()
    {
       hoverLaser.gameObject.SetActive(false);
       hoverLaser.StopVFX();
    }
}
