using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    // keep track of the jumping state ... 
    bool isJumping = false;
    bool isWalking = false;
    // make sure to keep track of the movement as well !

    AudioSource[] allSources;

    AudioSource jumpSource;
    AudioSource landSource;
    AudioSource walkSource;
    AudioSource cherrySource;
    AudioSource crouchSource;
    Rigidbody2D rb; // note the "2D" prefix 
    
    // Start is called before the first frame update
    void Start()
    {
	
    allSources = GetComponents<AudioSource>();
    
    jumpSource = GetComponents<AudioSource>()[0];
    landSource = GetComponents<AudioSource>()[1];
    walkSource = GetComponents<AudioSource>()[2];
    cherrySource = GetComponents<AudioSource>()[3];
    crouchSource = GetComponents<AudioSource>()[4];

    rb = GetComponent<Rigidbody2D>();
    // get the references to your audio sources here !        
    }

    // FixedUpdate is called whenever the physics engine updates
    void FixedUpdate()
    {
	
    float w = rb.velocity.magnitude;

        if (w > 1 && !isWalking && !isJumping) {
            walkSource.Play();
            isWalking = true;
        } else if (w < 1 && isWalking) {
            walkSource.Stop();
            isWalking = false;
        }
    // Use the ridgidbody instance to find out if the fox is
	// moving, and play the respective sound !
	// Make sure to trigger the movement sound only when
	// the movement begins ...

	// Use a magnitude threshold of 1 to detect whether the
	// fox is moving or not !
	// i.e.
	// if ( ??? > 1 && ???) {
	//    play sound here !
	// } else if ( ??? < 1 &&) {
	//   stop sound here !
	// }	
    }
    
    // trigger your landing sound here !
    public void OnLanding() {
        float randomModifier = Random.Range(0.8f,1.2f);
        landSource.pitch = randomModifier;
        isJumping = false;
        print("the fox has landed");
        landSource.Play();
	// to keep things cleaner, you might want to
	// play this sound only when the fox actually jumoed ...
    }

    // trigger your crouching sound here
    public void OnCrouching() {
        float randomModifier = Random.Range(0.8f,1.2f);
        crouchSource.pitch = randomModifier;
        print("the fox is crouching");
        crouchSource.Play();
    }
 
    // trigger your jumping sound here !
    public void OnJump() {
        float randomModifier = Random.Range(0.9f,1.1f);
        jumpSource.pitch = randomModifier;
        isJumping = true;
        print("the fox has jumped");
        jumpSource.Play();
        walkSource.Stop();
    }

    // trigger your cherry collection sound here !
    public void OnCherryCollect() {
        print("the fox has collected a cherry");
        cherrySource.Play();
    }
}
