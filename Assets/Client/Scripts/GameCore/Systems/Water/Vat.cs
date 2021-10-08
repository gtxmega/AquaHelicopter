using UnityEngine;
using UnityEngine.Events;

public class Vat : MonoBehaviour, IWater
{
    [HideInInspector] public UnityEvent OnChangeLevelWater = new UnityEvent();
    [HideInInspector] public UnityEvent EventIncreaseWater = new UnityEvent();
    [HideInInspector] public UnityEvent EventDecreaseWater = new UnityEvent();

    [Header("Water attributes")]
    [SerializeField] private MinMax minMaxLevelWater;
    [SerializeField] private float currentLevelWater;
    [SerializeField] private float minimalPercentWaterForLevel;


    private void Start() 
    {
        currentLevelWater = minMaxLevelWater.min;
    }

    public float GetPercentWater()
    {
        return currentLevelWater / minMaxLevelWater.max;
    }

    public float GetCurrentLevelWater()
    {
        return currentLevelWater;
    }
    public float GetMaxLevelWater()
    {
        return minMaxLevelWater.max;
    }
    public float GetMinimalPercentWaterForLevel()
    {
        return minimalPercentWaterForLevel;
    }

    public void ChangeLevelWater(float amount)
    {
        currentLevelWater += amount;
        currentLevelWater = Mathf.Clamp(currentLevelWater, 1.0f, minMaxLevelWater.max);

        if(amount < 0)
        {
            EventDecreaseWater?.Invoke();
        }else
        {
            EventIncreaseWater?.Invoke();
        }

        OnChangeLevelWater?.Invoke();
    }


}
