using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterController : MonoBehaviour
{
    private Rigidbody2D _rb2d;
    private float _speed = 10f;
    private float _moveInput;
    private float _topScore = 0.0f;

    private bool _isStarted = false;

    public Text scoreText;
    public Text startText;


    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        _rb2d.gravityScale = 0;
        _rb2d.velocity = Vector2.zero;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isStarted == false)
        {
            _isStarted = true;
            startText.gameObject.SetActive(false);
            _rb2d.gravityScale = 5f;
        }


        if (_isStarted == true)
        {
            //karakterin kontrolu sirasinda sag sol animasyonlari yapmayi saglar
            if (_moveInput < 0)
            {
                this.GetComponent<SpriteRenderer>().flipX = false;
            }
            else
            {
                this.GetComponent<SpriteRenderer>().flipX = true;
            }

            if (_rb2d.velocity.y > 0 && transform.position.y > _topScore)
            {
                _topScore = transform.position.y;
            }
            scoreText.text = "Score: " + Mathf.Round(_topScore).ToString();
        }
    }

    void FixedUpdate() //physic material
    {
        _moveInput = Input.GetAxis("Horizontal");
        _rb2d.velocity = new Vector2(_moveInput * _speed, _rb2d.velocity.y);
    }
}