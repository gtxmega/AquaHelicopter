using UnityEngine;
using UnityEngine.UI;

namespace GameCore.HUD
{
    public class WaterProgressBar : MonoBehaviour
    {
        [SerializeField] private GameObject progressPanel;
        [SerializeField] private Image fillColor;
        
        [SerializeField] private Vat vatWithWater;

        private void Start() 
        {

            SubscribeOnEvents();

            UpdateFillColor();
        }

        private void UpdateFillColor()
        {
            fillColor.fillAmount = vatWithWater.GetPercentWater();
        }

        private void SubscribeOnEvents()
        {
            if(vatWithWater != null)
            {
                vatWithWater.OnChangeLevelWater.AddListener(UpdateFillColor);
                GameMode.Instance.LevelFinalState.AddListener(HideHUD);
            }
        }

        private void UnsubscribeOnEvents()
        {
            if(vatWithWater != null)
            {
                vatWithWater.OnChangeLevelWater.RemoveListener(UpdateFillColor);
                GameMode.Instance.LevelFinalState.RemoveListener(HideHUD);
            }
        }

        private void OnDisable()
        {
            UnsubscribeOnEvents();
        }

        public void HideHUD()
        {
            progressPanel.SetActive(false);
        }

    }
}
