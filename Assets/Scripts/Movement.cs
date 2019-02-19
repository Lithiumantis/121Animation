using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 0.1f;
    public float mouseSensitivity = 1f;
    Animator animator;
    Rigidbody rb;

    bool rotating;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

        float x;
        float side; float fwd;

        Vector3 rotateValue;
        Vector3 moveValue;

        if(Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            speed = 0.3f;
        }
        else
        {
            speed = 0.1f;
        }

        x = Input.GetAxis("Mouse X") * mouseSensitivity;
        if (x != 0) rotating = true;
        else rotating = false;

        rotateValue = new Vector3(0, x * -1, 0);
        transform.eulerAngles = transform.eulerAngles - rotateValue;

        side = Input.GetAxis("Horizontal");
        fwd = Input.GetAxis("Vertical");
        moveValue = new Vector3(side, 0, fwd);
        transform.Translate(moveValue * speed);

        AnimatePlayer(side, moveValue.magnitude * speed, fwd);
        //Debug.Log(x);

	}

    void AnimatePlayer(float horizontal, float forward, float positive)
    {
        float direction = (horizontal + 1) / 2;

        animator.SetFloat("Direction", direction);
        animator.SetFloat("Positive", positive);

        if(rotating && forward == 0)
        {
            //Unity-chan doesn't seem to have an animation for rotating in place, so this will have to do.
            animator.SetFloat("Move Speed", 1f);
        }
        else
        {
            animator.SetFloat("Move Speed", forward);
        }

    }
}
