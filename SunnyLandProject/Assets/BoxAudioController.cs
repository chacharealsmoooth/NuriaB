using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxAudioController : MonoBehaviour
{

bool isMoving = false;
bool isDoing = false;

AudioSource[] allSources;
AudioSource impact;
AudioSource rumble;
Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
    allSources = GetComponents<AudioSource>();
    impact = GetComponents<AudioSource>()[0];
    rumble = GetComponents<AudioSource>()[1];
  
    rb = GetComponent<Rigidbody2D>();
    }

void FixedUpdate()
    {
	
    float b = rb.velocity.magnitude;

        if (b > 0.1 && !isMoving) {
            rumble.Play();
            isMoving = true;
        } else if (b < 0.1 && isMoving) {
            rumble.Stop();
            isMoving = false;
        }
    }

void OnCollisionEnter2D(Collision2D other) {
        float randomModifier = Random.Range(0.8f,1.2f);
        impact.pitch = randomModifier;
        impact.Play();
        
    }
}