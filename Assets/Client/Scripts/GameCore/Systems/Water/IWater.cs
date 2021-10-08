
public interface IWater
{
    float GetPercentWater();
    float GetCurrentLevelWater();
    float GetMaxLevelWater();
    float GetMinimalPercentWaterForLevel();
    void ChangeLevelWater(float amount);

}
