using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;
using static System.Runtime.CompilerServices.RuntimeHelpers;

public class Player : MonoBehaviour
{
    public float speed; 
    Rigidbody2D rb;
    SpriteRenderer sr;
    Animator animator;
    string currentAnimation; 
    public InventoryManager inventoryManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    //public void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        inventoryManager.AddItem(itemTmp);
    //    }
    //}
    void FixedUpdate()
    {
        float movementHorizontal = Input.GetAxis("Horizontal");
        float movementVertical = Input.GetAxis("Vertical");
        transform.position += new Vector3(movementHorizontal, movementVertical, 0) * speed * Time.deltaTime;
        if (movementHorizontal == 0 && movementVertical == 0)
        {
            ChangeAnim("Idle");
        }
        else if (movementHorizontal != 0)
        {
            ChangeAnim("Walk");
        }
        else if (movementVertical > 0)
        {
            ChangeAnim("WalkUp");
        }
        else if (movementVertical < 0)
        {
            ChangeAnim("WalkDown");
        } 
        if (sr)
            sr.flipX = movementHorizontal < 0 ? true : false; 
    }
    private void ChangeAnim(string animation)
    {
        if (currentAnimation == animation) return;
        currentAnimation = animation;
        animator.Play(currentAnimation);
    }
}
