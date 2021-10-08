using UnityEngine;

public class VatWithWaterVFX : MonoBehaviour, IParticalSystemPlay
{
    [SerializeField] ParticleSystem _particleSystem;

    public void PlayPartical()
    {
        if(_particleSystem.isPlaying == false)
            _particleSystem.Play();
    }

    public void StopPartical()
    {
        _particleSystem.Stop();
    }
}
