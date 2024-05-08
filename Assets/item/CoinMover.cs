using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMover : MonoBehaviour
{
    public float speed = 15f;
    public int speedUp = 5;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CharacterMovement characterMovement = FindAnyObjectByType<CharacterMovement>();
            characterMovement.speed += speedUp;
            characterMovement.StartCoroutine(CountDownSpeedDown(speedUp));
            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator CountDownSpeedDown(float speedDown)
    {
        yield return new WaitForSeconds(3f);
        CharacterMovement characterMovement = FindAnyObjectByType<CharacterMovement>();
        characterMovement.speed -= speedDown;
    }
}