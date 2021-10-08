using UnityEngine;

namespace GameCore.HUD
{
    public class GamePlayWidget : MonoBehaviour
    {
        [SerializeField] private GameObject panelGamePlay;


        [SerializeField] private GameMode gameMode;

        private void Awake()
        {
            gameMode.LevelStart.AddListener(ShowPanel);
            gameMode.LevelLose.AddListener(HidePanel);
        }

        public void ShowPanel()
        {
            panelGamePlay.SetActive(true);
        }

        public void HidePanel()
        {
            panelGamePlay.SetActive(false);
        }
    }
}
