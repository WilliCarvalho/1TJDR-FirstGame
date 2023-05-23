using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
   
    private Transform playerTransform;
    private Rigidbody2D rigidbody;
    private bool isOnFloor = true;


    [Header("Player movement")]
    [SerializeField] private float velocity = 10;
    [SerializeField] private float jumpForce = 10;

    private void Awake()
    {
        instance = this;
        playerTransform = GetComponent<Transform>();
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {        
        MovePlayer();
    }

    private void MovePlayer()
    {
        float moveX = Input.GetAxisRaw("Horizontal") * velocity * Time.deltaTime;
        playerTransform.Translate(new Vector3(moveX, 0));

        if (Input.GetButtonDown("Jump") && isOnFloor)
        {
            isOnFloor = false;
            rigidbody.AddForce(Vector2.up * jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOnFloor = true;

        if (collision.gameObject.tag == "Enemy")
        {
            StartCoroutine(DestroyPlayer());
        }
    }

    IEnumerator DestroyPlayer()
    {
        Color c = GetComponent<Renderer>().material.color;
        for (float alpha = 1f; alpha >= 0; alpha -= 0.1f)
        {
            c.a = alpha;
            GetComponent<Renderer>().material.color = c;
            yield return new WaitForSeconds(.01f);
        }
        GameManager.instance.OnGameOnver();
        Destroy(gameObject);
    }

    public Transform GetPlayerTransform()
    {
        return playerTransform;
    }
}
