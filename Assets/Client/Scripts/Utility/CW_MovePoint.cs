using UnityEngine;

namespace GameCore.Utility
{
    public class CW_MovePoint : MonoBehaviour
    {
        [SerializeField] private Transform fixedPoint;
        [SerializeField] private Transform curveWorldPoint;

        public void SetFixedPosition()
        {
            curveWorldPoint.SetParent(null);
            curveWorldPoint.position = fixedPoint.position;
        }


    }
}
