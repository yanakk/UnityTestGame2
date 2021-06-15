using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMovement : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    Vector2 dis;


    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        dis = Vector2.zero;
    }

    // Update is called once per frame
    void Update()
    {


        Vector2 movement = Vector2.zero;
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            movement=new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        }


        //Vector2 movement = Vector2.zero;


        Vector2 current = rigidBody.position;
        //Vector3 mTargetPos;
        if (Input.GetMouseButtonDown(1))
        {
            movement = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            dis = movement-current;
            //while (dis != Vector2.zero) {


            //}


        }
        if (dis != Vector2.zero)
        {
            if (dis.y > 0)
            {
                moveUp(dis, out dis);
            }
            else if (dis.y < 0)
            {
                moveDown(dis, out dis);
            }
            else if (dis.x < 0)
            {
                moveLeft(dis, out dis);
            }
            else
            {
                moveRight(dis, out dis);
            }
        }

        //ËÉ¿ªÊó±êÓÒ¼üÊ±
        if (Vector2.zero==dis)
        {
            animator.SetBool("is_Walking", false);
        }

    }




    void moveUp(Vector2 now, out Vector2 currentDis)
    {

        if ( now.y < 1&&now.y>-1)
        {
            currentDis.y = 0;
            currentDis.x = now.x;
            return;
        }
        if (now.y > 0)
        {
            animator.SetBool("is_Walking", true);
            animator.SetFloat("input_x", 0);
            animator.SetFloat("input_y", 1f);
            Vector2 run = new Vector2(0, 1f);
            //gameObject.transform.localRotation = Quaternion.Euler(0, 1, 0);
            //rigidBody.MovePosition(rigidBody.position + run * Time.deltaTime * 10);
            transform.Translate(0, Time.deltaTime , 0);
            currentDis = now - run;
        }
        else {
            currentDis = now;
        }
    }
    void moveDown(Vector2 now, out Vector2 currentDis)
    {
        if (now.y < 1 && now.y > -1)
        {
            currentDis.y = 0;
            currentDis.x = now.x;
            return;
        }
        if (now.y < 0)
        {
            animator.SetBool("is_Walking", true);
            animator.SetFloat("input_x", 0);
            animator.SetFloat("input_y", -1f);
            Vector2 run = new Vector2(0, -1f);
            //rigidBody.MovePosition(rigidBody.position + run * Time.deltaTime * 10);
            transform.Translate(0, -1*Time.deltaTime , 0);
            currentDis = now - run;
        }
        else {
            currentDis = now;
        }
    }
    void moveLeft(Vector2 now, out Vector2 currentDis)
    {
        if (now.x < 1f && now.x > -1f)
        {
            currentDis.x = 0;
            currentDis.y = now.y;
            return;
        }
        if (now.x < 0)
        {
            animator.SetBool("is_Walking", true);
            animator.SetFloat("input_x", -1f);
            animator.SetFloat("input_y", 0);
            Vector2 run = new Vector2(-1f, 0);
            transform.Translate(-1*Time.deltaTime , 0, 0);
            //rigidBody.MovePosition(rigidBody.position + run * Time.deltaTime * 10);
            currentDis = now - run;
        }
        else {
            currentDis = now;
        }
    }
    void moveRight(Vector2 now, out Vector2 currentDis)
    {
        if (now.x < 1f && now.x > -1f)
        {
            currentDis.x = 0;
            currentDis.y = now.y;
            return;
        }
        if (now.x > 0)
        {
            animator.SetBool("is_Walking", true);
            animator.SetFloat("input_x", 1f);
            animator.SetFloat("input_y", 0);
            Vector2 run = new Vector2(1f, 0);
            transform.Translate(Time.deltaTime , 0, 0);
            //rigidBody.MovePosition(rigidBody.position + run * Time.deltaTime * 10);
            currentDis = now - run;
        }
        else {

            currentDis = now;
        }
    }
}
