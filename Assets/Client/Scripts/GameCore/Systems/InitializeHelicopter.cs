using UnityEngine;

using GameCore;
using GameCore.Guns;

public class InitializeHelicopter : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private Movement movementInterface;
    [SerializeField] private MoveToTarget moveToTargetInterface;

    [Header("Triggers")]
    [SerializeField] private FinalTrigger finalTrigger;

    [Header("Gun")]
    [SerializeField] private WaterGunVFX waterGunVFX;
    [SerializeField] private WaterShooting waterShooting;
    [SerializeField] private WaterGun waterGun;

    [Header("Vat with water")]
    [SerializeField] private VatScaler vatScaler;
    [SerializeField] private Vat vatWithWater;

    [Header("Main Actor")]
    [SerializeField] private Helicopter _helicopter;

    private void Start() 
    {
        _helicopter.InjectMovementSystem(movementInterface);
        GameMode.Instance.LevelStart.AddListener(movementInterface.StartMove);

        finalTrigger.InjectIWater(vatWithWater);
        finalTrigger.EventEnterFinalTrigger.AddListener(SwitchMovementSystem);


        vatScaler.InjectIWater(vatWithWater);
        vatWithWater.EventIncreaseWater.AddListener(vatScaler.VFXIncreaseWater);
        vatWithWater.EventDecreaseWater.AddListener(vatScaler.VFXDecreaseWater);

        waterGun.InjectVFX(waterGunVFX);
        waterGun.InjectShooting(waterShooting);

        WaterTrigger[] waterTriggers = FindObjectsOfType<WaterTrigger>();
        for(int i = 0; i < waterTriggers.Length; ++i)
        {
            waterTriggers[i].InjectIWater(vatWithWater);
        }

    }

    private void SwitchMovementSystem()
    {
        movementInterface.StopMove();
        
        _helicopter.InjectMovementSystem(moveToTargetInterface);
        moveToTargetInterface.StartMove();

    }


}
