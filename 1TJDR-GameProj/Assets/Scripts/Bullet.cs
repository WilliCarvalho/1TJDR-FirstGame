using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletVelocity = 100f;

    private void Start()
    {
        StartCoroutine(LifeSpan());
    }

    private IEnumerator LifeSpan()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }

    void Update()
    {
        transform.Translate(Vector3.right * bulletVelocity * Time.deltaTime);
    }
}
