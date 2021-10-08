using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


namespace GameCore
{
    public class GameMode : MonoBehaviour
    {
        public UnityEvent LevelStart = new UnityEvent();
        public UnityEvent LevelWon = new UnityEvent();
        public UnityEvent LevelLose = new UnityEvent();
        public UnityEvent LevelFinalState = new UnityEvent();

        public Helicopter PlayerActor{get; private set;}
        private Building building;


        public bool GameIsPause {get; private set;}

        public static GameMode Instance{get; private set;}

        private void Awake() 
        {
            if(Instance != null)
            {
                Destroy(this);
            }else
            {
                Instance = this;
            }

            PlayerActor = FindObjectOfType<Helicopter>();
            building = FindObjectOfType<Building>();

            building.OnClear.AddListener(WonLevel);
        }

        public void StartLevel()
        {
            LevelStart.Invoke();
        }
        
        public void WonLevel()
        {
            LevelWon.Invoke();
        }

        public void LoseLevel()
        {
            LevelLose.Invoke();
        }

        public void NextScene()
        {
            GameObject.FindGameObjectWithTag("SceneInit").GetComponent<SceneInitializer>().NextScene();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}