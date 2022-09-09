using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
    public TextMeshProUGUI pizzaText;

    GameObject[] pizzaPoints;
    GameObject[] clientPoints;

    GameObject[] pizza;

    void Start()
    {
        Application.targetFrameRate = 120;
        rb = GetComponent<Rigidbody>();
        hadPizza = false;
        currentPizza = 0;
    }

    void MoveForward()
    {
        transform.position += new Vector3(0, 0, bikeSpeed) * Time.fixedDeltaTime ;
    }

    void PhoneController()
    {
        if (Input.touchCount > 0)
        {
            Touch parmak = Input.GetTouch(0);
            transform.position += new Vector3(parmak.deltaPosition.x, 0, 0) * Time.fixedDeltaTime * rlSpeed;

            //Araçta pizza varsa pizzalarýn sallanmasýný gerçekleþtiriyor
            if (hadPizza)
            {
                tabak.transform.rotation = Quaternion.Euler(0, 0, parmak.deltaPosition.x / rotateAngle);
            }
        }
        else
        {
            tabak.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (currentPizza > 0)
            {
                hadPizza = true;
            }
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

            //Araçta pizza varsa pizzalarýn sallanmasýný gerçekleþtiriyor
            if (hadPizza)
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
        transform.position += velocity * 5 * Time.fixedDeltaTime;
    }

    void ShowText()
    {
        pizzaText.text=currentPizza.ToString();
    }

    void Update()
    {
        if (GameManager.gameStarted && GameManager.winOrLose == 0)
        {
            //KeyboardController();

            MouseController();

            PhoneController();

            MoveForward();

            ShowText();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Road")
        {
            GameManager.winOrLose = -1;
        }
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="PizzaPoint")
        {
            tabak.transform.rotation = Quaternion.Euler(0, 0, 0);
            hadPizza = false;
            LevelManager.takePizza = true;
            
            //Kaçýncý pizza noktasýna temas edildiðini levelmanagere iletiyor
            for(int i=0;i<pizzaPoints.Length;i++)
            {
                if (collision.gameObject == pizzaPoints[i])
                {
                    LevelManager.truckNumber = i;
                }
            }
            
            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag=="ClientPoint")
        {
            tabak.transform.rotation = Quaternion.Euler(0, 0, 0);
            hadPizza = false;
            LevelManager.givePizza = true;

            //Kaçýncý müþteri noktasýna temas edildiðini levelmanagere iletiyor
            for (int i = 0; i < clientPoints.Length; i++)
            {
                if (collision.gameObject == clientPoints[i])
                {
                    LevelManager.clientNumber = i;
                }
            }

            Destroy(collision.gameObject);
        }

        if(collision.gameObject.tag=="Car")
        {
            GameManager.winOrLose = -1;
        }

        if(collision.gameObject.tag=="EndRoad")
        {
            LevelManager.endControl = true;
        }

        if(collision.gameObject.tag=="StartRoad")
        {
            pizzaPoints = GameObject.FindGameObjectsWithTag("PizzaPoint");
            clientPoints = GameObject.FindGameObjectsWithTag("ClientPoint");
        }
    }
}
