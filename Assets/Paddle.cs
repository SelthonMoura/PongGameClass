using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed;
    public KeyCode upKey;
    public KeyCode downKey;
    private bool _isPressingUp;
    private bool _isPressingDown;
    void Start()
    {
        
    }
    void Update()
    {
        _isPressingUp = Input.GetKey(upKey);
        _isPressingDown = Input.GetKey(downKey);
    }

    private void FixedUpdate()
    {
        if (_isPressingUp)
        {
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        }
        if (_isPressingDown)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
    }
}
