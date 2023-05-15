using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class striker : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody;
    Transform selftrans;
    Vector2  startpos;
    public Slider myslider;
    Vector2 direction;
    Vector3 mousepos;
    Vector3 mousepos2;
    public LineRenderer line;
    bool hasStriked = false;
    bool positionset = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        selftrans = transform;
        startpos = transform.position;

    }
    public void shootstriker()
    {
        float x = 0;
        if (positionset && rigidbody.velocity.magnitude == 0) {
            x = Vector2.Distance(transform.position, mousepos);
        }
        direction = (Vector2)(mousepos2 = transform.position);
        direction.Normalize();
        rigidbody.AddForce(direction*x* 100);
        hasStriked = true;

    }
    // Update is called once per frame
    void Update()
    {
        line.enabled = false;
        mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousepos2 = new Vector3(-mousepos.x, -mousepos.y-3, mousepos.z);
        if (mousepos2.y > 0.45) 
        {
            mousepos2.y = 0.45f;
        
        
        }
        if (mousepos2.y < -3.2)
        {
            mousepos2.y = -3.2f;


        }
        if (mousepos2.x < -3.12)
        {
            mousepos2.y = -3.12f;


        }
        if (mousepos2.x < -2.112f)
        {
            mousepos2.x = -2.112f;


        }


        if (!hasStriked && !positionset) 
        {
            selftrans.position = new Vector2(myslider.value, startpos.y);


        }
        if(Input.GetMouseButton(0) && rigidbody.velocity.magnitude==0 && positionset) 
        {
            shootstriker();
        }
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        if (hit.collider != null)
        {


            if (Input.GetMouseButtonDown(0))
            {
                if (!positionset)
                {
                    positionset = true;

                }


            }
        }
        if(positionset && rigidbody.velocity.magnitude == 0) 
        {
            line.enabled = true;
            line.SetPosition(0, selftrans.position);
            line.SetPosition(1, mousepos2);
            
        }
        if(rigidbody.velocity.magnitude<0.1f&& rigidbody.velocity.magnitude != 0 )
        {
            strikerreset();
        }
    }
    public void strikerreset()
    {
        rigidbody.velocity = Vector2.zero;
        hasStriked = false;
        positionset = false;
        line.enabled = false;


    }
}
