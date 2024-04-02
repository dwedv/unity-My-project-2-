using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTest : MonoBehaviour
{
    private Move moveScript;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<Move>(); // 假设Move脚本和AnimatorText脚本在同一个GameObject上

        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            animator.Play("change_color");
        }


        if (Input.GetKeyDown(KeyCode.UpArrow) && moveScript.isGrounded)
        {
            animator.Play("jump_start");
        }

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            animator.Play("rush");
        }

    }

    private bool hasPlayedJumpOver = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (!hasPlayedJumpOver && collision.gameObject.CompareTag("Ground"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("jump_holding"))
            {
                animator.Play("jump_over");
                hasPlayedJumpOver = true;
            }
        }
    }

}