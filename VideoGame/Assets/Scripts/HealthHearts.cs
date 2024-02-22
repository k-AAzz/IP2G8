using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthHearts : MonoBehaviour
{
    public Sprite fullHeart;
    public Sprite halfHeart;
    public Sprite emptyHeart;

    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
    }

    private void Start()
    {
        SetHeartSize(new Vector2(25f, 25f));
    }

    public void SetHeartImage(HeartStatus heartStatus)
    {
        switch (heartStatus)
        {
            case HeartStatus.Empty:
                heartImage.sprite = emptyHeart;
                break;

            case HeartStatus.Half:
                heartImage.sprite = halfHeart;
                break;

            case HeartStatus.Full:
                heartImage.sprite = fullHeart;
                break;
        }
    }
    //Changes the size of the hearts
    public void SetHeartSize(Vector2 newSize)
    {
        RectTransform rectTransform = GetComponent<RectTransform>();
        rectTransform.sizeDelta = newSize;
    }
}



public enum HeartStatus
{
    Empty = 0,
    Half = 1,
    Full = 2
}
