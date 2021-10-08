using UnityEngine;

using GameCore;

public enum ETYPE_MULTIPLY
{
    PLUS,
    MINUS,
    X2,
    DIVIDE
}

public class WaterTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem _particleSystem;
   
    [SerializeField] private float amountWater;
    [SerializeField] private ETYPE_MULTIPLY multiplyAdd;

    private IWater vatWithWater;

    private bool isOverlap;

    private void OnTriggerEnter(Collider otherCollider)
    {

        if(isOverlap == false && otherCollider.CompareTag("Actor"))
        {
            isOverlap = true;
            _particleSystem.Play();
            
            switch(multiplyAdd)
            {
                case ETYPE_MULTIPLY.PLUS:
                    vatWithWater.ChangeLevelWater(amountWater);
                break;
                case ETYPE_MULTIPLY.MINUS:
                    vatWithWater.ChangeLevelWater(-amountWater);
                break;
                case ETYPE_MULTIPLY.X2:
                    var levelWater = vatWithWater.GetCurrentLevelWater();
                    levelWater = levelWater * amountWater - levelWater;
                    vatWithWater.ChangeLevelWater(levelWater);
                break;
                case ETYPE_MULTIPLY.DIVIDE:
                    var clw = vatWithWater.GetCurrentLevelWater();
                    var delta = clw - (clw / amountWater);
                    vatWithWater.ChangeLevelWater(-delta);
                break;
            }
        }
    }

    public void InjectIWater(IWater water)
    {
        vatWithWater = water;
    }
}
