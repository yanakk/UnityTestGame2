using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rigidBody.velocity = new Vector2(10, rigidBody.velocity.y);

            //设置自身缩放的值
            transform.localScale = new Vector2(1f, 1f);
        }
        //角色水平移动
        //按住A键，判断如果小于0，则向左开始移动
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            rigidBody.velocity = new Vector2(-10, rigidBody.velocity.y);

            //如果new Vector2(-1f, 1f)  x值为负数，则图片进行反转显示
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
        
        {
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
        }


        if (Input.GetAxisRaw("Vertical") > 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, 10);

            //设置自身缩放的值
            transform.localScale = new Vector2(1f, 1f);
        }
        
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, -10);

            //如果new Vector2(-1f, 1f)  x值为负数，则图片进行反转显示
            transform.localScale = new Vector2(-1f, 1f);
        }
        else
       
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x,0);
        }

    }
}
