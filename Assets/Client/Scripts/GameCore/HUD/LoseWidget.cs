using UnityEngine;

using GameCore;

public class LoseWidget : MonoBehaviour
{
    [SerializeField] private GameObject panelLose;


    [SerializeField] private GameMode gameMode;


    private void Awake() 
    {
        gameMode.LevelLose.AddListener(ShowPanel);
    }

    public void ShowPanel()
    {
        panelLose.SetActive(true);
    }

    public void HidePanel()
    {
        panelLose.SetActive(false);
    }

}
