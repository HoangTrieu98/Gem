using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenGemMover : MonoBehaviour
{
    public float speed = 15f;
    public int multiplescore = 2;

    private void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.MultipleScore(multiplescore);
            AudioSource audioSource = other.GetComponent<AudioSource>();
            audioSource.Play();
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
