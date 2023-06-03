using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed;
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    string currentAnimation;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        if (movementHorizontal == 0 && movementVertical == 0)
        {
            ChangeAnimation("ZombieIdle");
        }
        else if (movementHorizontal != 0)
        {
            ChangeAnimation("ZombieWalk");
        }
        else if (movementVertical > 0)
        {
            ChangeAnimation("ZombieWalk");
        }
        else if (movementVertical < 0)
        {
            ChangeAnimation("ZombieWalk");
        }
        if (sr)
            sr.flipX = movementHorizontal < 0 ? true : false;
    }
    void ChangeAnimation(string animation)
    {
        if (currentAnimation == animation) return;

        animator.Play(animation);
        currentAnimation = animation;
    }
}
