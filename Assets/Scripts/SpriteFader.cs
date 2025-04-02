using UnityEngine;

public class SpriteFader : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    public float fadeSpeed = 2f; // Adjust speed for faster/slower fade
    private int spriteIndex = 0;
    private float alpha = 1f;
    private bool fadingOut = true;

    void Start()
    {
        if (!spriteRenderer) spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (fadingOut)
        {
            alpha -= fadeSpeed * Time.deltaTime;
            if (alpha <= 0f)
            {
                alpha = 0f;
                ChangeSprite();
                fadingOut = false;
            }
        }
        else
        {
            alpha += fadeSpeed * Time.deltaTime;
            if (alpha >= 1f)
            {
                alpha = 1f;
                fadingOut = true;
            }
        }

        spriteRenderer.color = new Color(1f, 1f, 1f, alpha);
    }

    void ChangeSprite()
    {
        spriteIndex = (spriteIndex + 1) % sprites.Length;
        spriteRenderer.sprite = sprites[spriteIndex];
    }
}
