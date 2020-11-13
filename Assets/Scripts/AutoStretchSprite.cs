using UnityEngine;
using System.Collections;
[RequireComponent(typeof(SpriteRenderer))]

public class AutoStretchSprite : MonoBehaviour
{

    private void Start()
    {
       
    }

    void Resize()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        float worldScreenHeight = Camera.main.orthographicSize * 2;
        float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

        transform.localScale = new Vector3(
            worldScreenWidth / sr.sprite.bounds.size.x,
            worldScreenHeight / sr.sprite.bounds.size.y-0.2f, 1);


    }

    private void Update()
    {
        Resize();
    }
    //void OnMouseDown()
    //{
    //    Debug.Log("Sprite Clicked");
    //}
}