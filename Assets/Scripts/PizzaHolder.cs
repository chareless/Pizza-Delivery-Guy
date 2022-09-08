using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaHolder : MonoBehaviour
{
    public GameObject pizzaBox;
    public Transform reference;
    public int pizzaCount;
    public static bool takePizza;
    public static bool givePizza;
    public Vector3 firstReference;
    void Start()
    {
        firstReference = reference.transform.position;
    }

    void SpawnPizza()
    {
        for (int i = 0; i < pizzaCount; i++)
        {
            Instantiate(pizzaBox, reference.transform.position, reference.transform.rotation);
            reference.transform.position += new Vector3(0, pizzaBox.transform.localScale.y, 0);
            Player.currentPizza++;
        }
    }

    void Update()
    {
        if (takePizza)
        {
            SpawnPizza();
            takePizza = false;
        }

        if (givePizza)
        {
            int musteri = 5;
            int kalan = Player.currentPizza - musteri;
            reference.transform.position -= new Vector3(0, Player.currentPizza * pizzaBox.transform.localScale.y, 0);
            pizzaCount = kalan; //müþterinin istediði pizzadan kalan
            Player.currentPizza = 0;
            SpawnPizza();
            givePizza = false;
            
        }
    }
}
