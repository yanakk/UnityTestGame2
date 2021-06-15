using UnityEngine;
using UnityEngine.AI;

public class PlayMovementMouse : MonoBehaviour
{
    public float speed = 1.5f;
    private Vector2 target;
    private Animator animator;
    private Rigidbody2D rigidBody;
    private SpriteRenderer spriteRenderer;
    private float rotation=0;

    // Use this for initialization
    void Start()
    {
        target = transform.position;
        animator= GetComponent<Animator>();
        rigidBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 current = rigidBody.position;
        if (Input.GetMouseButtonDown(1)) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 dis=target - current;        
            animator.SetBool("is_Walking", true);

            if (dis.x < 0)
            {

                spriteRenderer.flipX = true;
            }
            else {
                spriteRenderer.flipX = false;


            }

        }
        if (current== target) {
            animator.SetBool("is_Walking", false);
        }

        

        transform.position = Vector2.MoveTowards(transform.position,target,speed*Time.deltaTime);

       
    }

}
