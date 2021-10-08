using UnityEngine;
using UnityEngine.UI;

public class FollowProgressPosition : MonoBehaviour
{

    [SerializeField] private Image image;

    private float maxPosition;
    private float currentPosition;

    private Image thisImage;
    private Vector3 startPosition;

    private void Start()
    {
        thisImage = GetComponent<Image>();
        maxPosition = image.rectTransform.rect.width;
        startPosition = thisImage.rectTransform.localPosition;
    }


    private void Update()
    {
        var positionSprite = maxPosition * image.fillAmount;
        Vector3 imagePosition = new Vector3(startPosition.x + (positionSprite) - 452.0f, 0.0f, 0.0f);
        thisImage.rectTransform.localPosition = imagePosition;
    }
}
