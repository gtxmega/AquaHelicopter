using UnityEngine;

namespace GameCore.HUD
{
    public class LevelStartWidget : MonoBehaviour
    {
        [SerializeField] private GameObject panelStartLevel;

        [SerializeField] private GameMode gameMode;

        private void Awake() 
        {
            panelStartLevel.SetActive(true);
            gameMode.LevelStart.AddListener(HideWidget);
        }

        public void ShowWidget()
        {
            panelStartLevel.SetActive(true);
        }
        public void HideWidget()
        {
            panelStartLevel.SetActive(false);
        }
    }
}
