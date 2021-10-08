using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;


public class SceneInitializer : MonoBehaviour
{
    public int CurrentStartID;
    public int NextSceneID;
    public List<GameObject> levels = new List<GameObject>();

    private GameObject _current;

    private void Awake()
    {
        _current = Instantiate(levels[CurrentStartID], Vector3.zero,quaternion.identity);
    }

    public void NextScene()
    {
        Destroy(_current);
        if(NextSceneID < levels.Count)
            _current = Instantiate(levels[NextSceneID], Vector3.zero, quaternion.identity);
    }
    
}
