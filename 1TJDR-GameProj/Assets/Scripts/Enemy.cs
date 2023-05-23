using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float velocity;

    private void Start()
    {
        StartCoroutine(LifeSpan());
        Transform playerLocation = Player.instance.GetPlayerTransform();
        if (transform.position.x - playerLocation.position.x < 0)
        {
            velocity *= -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * velocity * Time.deltaTime);

        //can change the 'if' in the start for this statements if you want
        //if (transform.position.x - playerLocation.position.x < 0)
        //{
        //    transform.Translate(Vector3.right * velocity * Time.deltaTime);
        //}
        //else
        //{
        //    transform.Translate(Vector3.left * velocity * Time.deltaTime);
        //}
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            GameManager.instance.AddScore();
            Destroy(gameObject);
        }
    }

    IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(5f);
        Destroy(gameObject);
    }
}
