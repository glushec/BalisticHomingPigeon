using UnityEngine;
using UnityEngine.UI;

public class SpriteAnimator : MonoBehaviour
{
    public Image imageComponent;
    public Sprite[] spriteList;
    public float framesPerSecond = 24f;

    private int currentFrameIndex = 0;
    private float timePerFrame;
    private float timer;

    private void Start()
    {
        timePerFrame = 1f / framesPerSecond;
        timer = timePerFrame;

        if (imageComponent == null || spriteList.Length == 0)
        {
            Debug.LogError("Image component or sprite list not assigned.");
            enabled = false;
            return;
        }

        imageComponent.sprite = spriteList[currentFrameIndex];
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            currentFrameIndex = (currentFrameIndex + 1) % spriteList.Length;
            imageComponent.sprite = spriteList[currentFrameIndex];
            timer = timePerFrame;
        }
    }
}