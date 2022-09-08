using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody rb;
    Vector3 velocity;
    Vector3 firstPos;
    Vector3 endPos;
    public float rlSpeed;
    public float bikeSpeed;
    public GameObject tabak;
    public float rotateAngle;
    public static bool hadPizza;
    public static int currentPizza;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void MoveForward()
    {
        transform.position += new Vector3(0, 0, bikeSpeed) * Time.fixedDeltaTime;
    }

    void PhoneController()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            transform.position += new Vector3(parmak.deltaPosition.x, 0, 0) * Time.fixedDeltaTime * rlSpeed;
        }
    }

    void MouseController()
    {
        if (Input.GetMouseButtonDown(0))
        {
            firstPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            endPos = Input.mousePosition;

            float fark = endPos.x - firstPos.x;

            transform.position += new Vector3(fark, 0, 0) * Time.fixedDeltaTime * rlSpeed;

            if(hadPizza)
            {
                tabak.transform.rotation = Quaternion.Euler(0, 0, fark / rotateAngle);
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            firstPos = Vector3.zero;
            endPos = Vector3.zero;
            tabak.transform.rotation = Quaternion.Euler(0, 0, 0);
            if(currentPizza>0)
            {
                hadPizza = true;
            }
            
        }
    }

    void KeyboardController()
    {
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        transform.position += velocity * 2 * Time.fixedDeltaTime;
    }

    void Update()
    {
        if (GameManager.gameStarted)
        {
            //KeyboardController();

            MouseController();

            PhoneController();

            MoveForward();



        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            Debug.Log("Lose");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag=="PizzaPoint")
        {
            Destroy(collision.gameObject);
            PizzaHolder.takePizza = true;
        }

        if(collision.gameObject.tag=="ClientPoint")
        {
            Destroy(collision.gameObject);
            Destroy(GameObject.FindGameObjectWithTag("Pizza"));
            PizzaHolder.givePizza = true;
        }
    }
}
