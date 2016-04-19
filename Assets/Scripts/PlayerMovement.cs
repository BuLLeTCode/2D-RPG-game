using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    private Rigidbody2D playerBody;
    private Animator playerAnimator;

	// Use this for initialization
	void Start () {
        playerBody = this.GetComponent<Rigidbody2D>();
        playerAnimator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        //get player inputs
        Vector2 playerMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        //Control animations
        if(playerMovement != Vector2.zero)
        {
            playerAnimator.SetBool("isWalking", true);
            playerAnimator.SetFloat("input_x", playerMovement.x);
            playerAnimator.SetFloat("input_y", playerMovement.y);
        }
        else
        {
            playerAnimator.SetBool("isWalking", false);
        }
        //using RigidBody2D, move character
        playerBody.MovePosition(playerBody.position + playerMovement * Time.fixedDeltaTime);

	}
}
