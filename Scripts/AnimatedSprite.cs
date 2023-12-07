using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedSprite : MonoBehaviour
{
    //declares an array of sprites
    public Sprite[] sprites;

    //cycles this index through our array and updating the sprite accordingly
    private SpriteRenderer spriteRenderer;
    private int frame;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    //restarts animation after death
    private void OnEnable()
    {
        Invoke(nameof(Animate), 0f);
    }
    //stops animation after a game over
    private void OnDisable()
    {
        CancelInvoke();
    } 

    //animating our dino
    private void Animate()
    {
        frame++;

        if (frame >= sprites.Length) {
            frame = 0;
        }

        if (frame >= 0 && frame < sprites.Length) {
            spriteRenderer.sprite = sprites[frame];
        }

        //as game speed increases makes our dino animation faster
        Invoke(nameof(Animate), 1f / GameManager.Instance.gameSpeed);
    }
}
