using UnityEngine;

[System.Serializable]
public struct MinMax
{
    public float min;
    public float max;
}

public class Movement : MonoBehaviour, IMovement
{
    [Header("Status movement")]
    [SerializeField] private bool isMove;

    [Header("Move settings")]
    [SerializeField] private float moveForward;
    [SerializeField] private float moveSpeedLeftRight;

    [SerializeField] private MinMax limitLeftRightPosition;

    [Header("Rotation settings")]
    [SerializeField] private MinMax limitTurnAngelX = new MinMax();
    [SerializeField] private float angularSpeed;

    private Vector2 startTouchPosition;

    private Transform _transform;

    private void Awake() 
    {
        _transform = GetComponent<Transform>();
    }

    private void Update() 
    {
        if(isMove)
        {
            var powerAxisX = 0.0f;

            if(Input.touchCount > 0)
            {
                var currentTouch = Input.GetTouch(0);
                switch(currentTouch.phase)
                {
                    case TouchPhase.Began:
                        startTouchPosition = currentTouch.position;
                    break;
                }

                powerAxisX = GetDifferenceAxisXPositions(startTouchPosition, currentTouch.position);
            }

            var nexTurnAngles = Quaternion.Euler(limitTurnAngelX.max, 0.0f, limitTurnAngelX.min * powerAxisX);
            _transform.rotation = Quaternion.Lerp(_transform.rotation, nexTurnAngles, angularSpeed * Time.deltaTime);

            Vector3 directionMove = new Vector3(powerAxisX, 0.0f, 1.0f);
            directionMove.x *= moveSpeedLeftRight;
            directionMove.z *= moveForward;

            _transform.position += directionMove * Time.deltaTime;
            _transform.position = new Vector3(Mathf.Clamp(_transform.position.x, limitLeftRightPosition.min, limitLeftRightPosition.max), _transform.position.y, _transform.position.z);
        }
    }

    public bool IsMove()
    {
        return isMove;
    }

    public void StartMove()
    {
        isMove = true;
    }

    public void StopMove()
    {
        isMove = false;
    }

    private float GetDifferenceAxisXPositions(Vector2 startPosition, Vector2 endPosition)
    {
        return (endPosition - startPosition).normalized.x;
    }
}
