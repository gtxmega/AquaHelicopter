using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform followTarget;
    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;

    [SerializeField] private float smoothnes;

    private Transform thisTransform;

    private void Start() 
    {
        thisTransform = GetComponent<Transform>();
    }

    private void Update() 
    {
        var endPosition = new Vector3(thisTransform.position.x, followTarget.position.y, followTarget.position.z);
        thisTransform.position = Vector3.Lerp(thisTransform.position, endPosition + offset, smoothnes);
    }

    
}
