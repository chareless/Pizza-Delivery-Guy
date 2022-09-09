using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public static bool takePizza;
    public static bool givePizza;

    public GameObject[] clients;
    public int[] clientPizza;
    public int pizzaPrice;
    public static int completedClient;
    public Text[] clientText;

    public GameObject[] trucks;
    public Text[] truckText;
    public int[] truckPizza;
    public static int completedTruck;

    public GameObject pizzaBox;
    public Transform reference;
    public static int pizzaCount;
    public int neededClient;
    public static bool endControl;
    public static int collectedMoney;

    public static int truckNumber;
    public static int clientNumber;

    void Start()
    {
        completedTruck = 0;
        completedClient = 0;
        collectedMoney = 0;
        endControl = false;
        pizzaCount = 0;
    }
    //B�l�m�n tamamlanmas� i�in gereken m��teri say�s� sa�land���nda kazan�lan paray� kaydediyor
    void WinLoseControl()
    {
        if(endControl)
        {
            if (completedClient >= neededClient)
            {
                GameManager.winOrLose = 1;
                GameManager.money += collectedMoney;
                endControl = false;
            }
            else
            {
                GameManager.winOrLose = -1;
                endControl = false;
            }
        }
    }

    //Kuryenin tepsisindeki referans noktas�na pizza ekliyor ve referans noktas�n� pizza
    //boyutu kadar artt�r�yor
    void SpawnPizza()
    {
        for (int i = 0; i < pizzaCount; i++)
        {
            Instantiate(pizzaBox, reference.transform.position, reference.transform.rotation);
            reference.transform.position += new Vector3(0, pizzaBox.transform.localScale.y, 0);
            Player.currentPizza++;
        }
    }

    void PizzaControl()
    {
        //Pizza alma noktas�na gelindiyse noktan�n indexindeki pizzay� araca ekliyor
        if(takePizza==true)
        {
            pizzaCount = truckPizza[truckNumber];
            completedTruck++;
            SpawnPizza();
            takePizza = false;
        }

        //M��teriye verildikten sonra kalan pizza say�s�n� tekrar olu�turuyor
        if (givePizza==true)
        {
            int kalan = Player.currentPizza - clientPizza[clientNumber];
            if (kalan >= 0)
            {
                collectedMoney += pizzaPrice * clientPizza[clientNumber];
                pizzaCount = kalan;
                completedClient++;
            }
            reference.transform.position -= new Vector3(0, Player.currentPizza * pizzaBox.transform.localScale.y, 0);
            Player.currentPizza = 0;
            SpawnPizza();
            givePizza = false;
        }
    }

    void ClientTextControl()
    {
        for(int i=0;i<clients.Length;i++)
        {
            clientText[i].text = "-" + clientPizza[i].ToString();
        }
    }

    void TruckTextControl()
    {
        for (int i = 0; i < trucks.Length; i++)
        {
            truckText[i].text = "+" + truckPizza[i].ToString();
        }
    }

    void Update()
    {
        ClientTextControl();
        TruckTextControl();
        PizzaControl();
        WinLoseControl();
    }
}