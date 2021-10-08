using UnityEngine;

public class MoveToTarget : MonoBehaviour, IMovement
{
    [Header("Status movement")]
    [SerializeField] private bool isMove;

    [Header("Move settings")]
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform targetTransform;

    private Transform _transform;

    private void Start() 
    {
        _transform = GetComponent<Transform>();
    }

    private void Update() 
    {
        if(isMove)
        {
            var distance = (_transform.position - targetTransform.position).sqrMagnitude;
            if(distance >= 0.0f)
            {
                _transform.position = Vector3.MoveTowards(_transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
            }else
            {
                _transform.rotation = targetTransform.rotation;
            }
        }
    }

    public bool IsMove()
    {
        return isMove;
    }

    public void StartMove()
    {
        _transform.SetParent(targetTransform); // O_O
        isMove = true;
    }

    public void StopMove()
    {
        isMove = false;
    }
}
