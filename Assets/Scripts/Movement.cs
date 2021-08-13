using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private float speed = 5;
    [SerializeField] private Vector2 move;
    private bool Canmove = false;
    public static Movement instance;
    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null)
        {
            instance = this;
            Canmove = true;
            rb2d = GetComponent<Rigidbody2D>();
        }
        

    }
    private void Anim()
    {
        if(move.x == 1)
        {
            anim.SetFloat("FaceRight", 1);
        }
        else
        {
            anim.SetFloat("FaceRight", 0);
        }

    }

    private void Movements()
    {
        move = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if(Canmove && move.magnitude != 0)
        {
           
            rb2d.MovePosition(rb2d.position + move * speed * Time.deltaTime);
        }

    }

    private void Update()
    {
        Anim();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Movements();
    }
}
