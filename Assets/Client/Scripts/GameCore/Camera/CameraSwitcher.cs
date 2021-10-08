using UnityEngine;

namespace GameCore
{
    public class CameraSwitcher : MonoBehaviour
    {
        private enum ETYPE_CAMERA
        {
            INTRO, MAIN, FINAL, VICTORY, DEFEAT,
        }

        [SerializeField] private GameObject intorCamera;
        [SerializeField] private GameObject startCamera;
        [SerializeField] private GameObject finalCamera;


        private void Start() 
        {
            SubscribeOnEvents();
        }


        private void SwitchToIntroCamera()
        {
            startCamera.SetActive(false);
            finalCamera.SetActive(false);

            intorCamera.SetActive(true);
        }

        private void SwithcToStartCamera()
        {
            finalCamera.SetActive(false);
            intorCamera.SetActive(false);

            startCamera.SetActive(true);
        }

        private void SwitchToFinalCamera()
        {
            startCamera.SetActive(false);
            intorCamera.SetActive(false);

            finalCamera.SetActive(true);
        }

        private void SubscribeOnEvents()
        {
            if(GameMode.Instance != null)
            {
                GameMode.Instance.LevelStart.AddListener(SwithcToStartCamera);
                GameMode.Instance.LevelFinalState.AddListener(SwitchToFinalCamera);
            }
        }



    }
}
