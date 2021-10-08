using UnityEngine;
using UnityEngine.Events;


namespace GameCore
{
    public class FinalTrigger : MonoBehaviour
    {
        public UnityEvent EventEnterFinalTrigger = new UnityEvent();
        private IWater vatWithWater;

        private void OnTriggerEnter(Collider otherCollider) 
        {
            if(otherCollider.CompareTag("Actor") == false)
                return;

            if(vatWithWater.GetPercentWater() >= vatWithWater.GetMinimalPercentWaterForLevel())
            {
                EventEnterFinalTrigger?.Invoke();
                GameMode.Instance.LevelFinalState?.Invoke();
            }else
            {
                GameMode.Instance.LoseLevel();
            }

            gameObject.SetActive(false);
        }

        public void InjectIWater(IWater water)
        {
            vatWithWater = water;
        }
    }

}