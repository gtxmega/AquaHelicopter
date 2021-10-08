using System.Collections;
using UnityEngine;

namespace GameCore
{
    public class VatScaler : MonoBehaviour
    {
        [SerializeField] private float maxSizeVat = 2f;

        [SerializeField] private float timeToMorph;

        [SerializeField] private SkinnedMeshRenderer[] skinnedComponents;

        private Transform _transform;
        private IWater vatWithWater;

        public void InjectIWater(IWater water)
        {
            vatWithWater = water;
        }

        private void Start() 
        {
            _transform = GetComponent<Transform>();
        }

        public void VFXIncreaseWater()
        {
            StartCoroutine(VFXBounceIncrement(GetMultiplySpeed(true)));
        }

        public void VFXDecreaseWater()
        {
            StartCoroutine(VFXBounceIncrement(GetMultiplySpeed(false)));
        }

        private IEnumerator VFXBounceIncrement(float multiplyScale)
        {
            var scaleSpeed = multiplyScale / timeToMorph;
            var timer = timeToMorph;

            while(timer >= 0.00f)
            {
                ChangeScalePerSpeed(scaleSpeed * Time.deltaTime);
                timer -= Time.deltaTime;
                yield return null;
            }

            timer = 0.1f;
            scaleSpeed = -10.0f;
            scaleSpeed /= timer;
            while(timer >= 0.00f)
            {
                ChangeScalePerSpeed(scaleSpeed * Time.deltaTime);
                timer -= Time.deltaTime;
                yield return null;
            }
        }

        private void ChangeScalePerSpeed(float scaleSpeed)
        {
            float blendShapeWidth = skinnedComponents[0].GetBlendShapeWeight(0);

            blendShapeWidth += scaleSpeed;

            skinnedComponents[0].SetBlendShapeWeight(0, blendShapeWidth);
            skinnedComponents[1].SetBlendShapeWeight(0, blendShapeWidth);
        }

        private float GetMultiplySpeed(bool isPositive)
        {
            var multiplyScale = maxSizeVat * vatWithWater.GetPercentWater();
            
            if(isPositive)
                multiplyScale -= skinnedComponents[0].GetBlendShapeWeight(0);

            if(isPositive == false)
                multiplyScale = skinnedComponents[0].GetBlendShapeWeight(0) - multiplyScale;

            return isPositive ? multiplyScale : -multiplyScale;
        }
    }
}
