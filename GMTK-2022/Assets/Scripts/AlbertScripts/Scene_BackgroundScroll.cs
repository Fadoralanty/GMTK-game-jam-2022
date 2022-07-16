using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene_BackgroundScroll : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] float maxScrollPosition;
    Vector2 _startPosition;

    void Start()
    {
        _startPosition = transform.position;
    }

    void Update()
    {
        ScrollTheBackground();
        RestartPosition();
    }

    void ScrollTheBackground()
    {
        transform.Translate(Vector3.down * scrollSpeed * Time.deltaTime);
    }

    void RestartPosition()
    {
        if (transform.position.y < maxScrollPosition)
        {
            transform.position = _startPosition;
        }
    }

}
