using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //Tüm pizzalarý kurye aracýnýn tabak parçasýna child olarak ekler
        if(collision.gameObject.tag=="Tabak" ||collision.gameObject.tag=="Pizza")
        {
            transform.parent = GameObject.FindGameObjectWithTag("Tabak").transform;
        }
    }
}
