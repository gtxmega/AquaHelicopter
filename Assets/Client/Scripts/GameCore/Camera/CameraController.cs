using UnityEngine;
using UnityEngine.Animations;

using GameCore.Actors;

namespace GameCore.Cameras
{
    public class CameraController : MonoBehaviour
    {
        [Space]
        public bool Lerp = true;
        public Vector2 Sensitivity;
        public float Speed = 1f;
        public Vector2 XAngleLimit;
        public Vector2 YAngleLimit;
        public ParentConstraint Constraint;

        private bool _isPointerPressed;
        private bool _isPointerPressedOld;

        private Vector2 _pointerPosition;
        private Vector2 _pointerPositionOld;

        private Vector3 _initialRotationOffset;
        private Vector3 _rotationOffset;


        private void Start()
        {
            _initialRotationOffset = _rotationOffset = Constraint.GetRotationOffset(0);
        }

        private void OnEnable()
        {
            _pointerPositionOld = _pointerPosition = Input.mousePosition;
        }

        private void Update()
        {
            _isPointerPressed = Input.GetMouseButton(0);
            _pointerPosition = Input.mousePosition;

            if (_isPointerPressed)
            {
                var d = (_pointerPosition - _pointerPositionOld) * Sensitivity;
                var x = ClampAngle(_rotationOffset.x - d.y, _initialRotationOffset.x + YAngleLimit.x, _initialRotationOffset.x + YAngleLimit.y);
                var y = ClampAngle(_rotationOffset.y + d.x, _initialRotationOffset.y + XAngleLimit.x, _initialRotationOffset.y + XAngleLimit.y);
                _rotationOffset = new Vector3(x, y, _rotationOffset.z);
            }

            if (Lerp)
                Constraint.SetRotationOffset(0, Vector3.Lerp(Constraint.GetRotationOffset(0), _rotationOffset, Speed * Time.deltaTime));
            else
                Constraint.SetRotationOffset(0, _rotationOffset);

            _isPointerPressedOld = _isPointerPressed;
            _pointerPositionOld = _pointerPosition;
        }

        private float ClampAngle(float angle, float min, float max)
        {
            if (angle < -360F)
                angle += 360F;
            if (angle > 360F)
                angle -= 360F;
            return Mathf.Clamp(angle, min, max);
        }
    }
}
