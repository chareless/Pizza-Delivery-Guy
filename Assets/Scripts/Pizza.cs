using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pizza : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //T?m pizzalar? kurye arac?n?n tabak par?as?na child olarak ekler
        if(collision.gameObject.tag=="Tabak" ||collision.gameObject.tag=="Pizza")
        {
            transform.parent = GameObject.FindGameObjectWithTag("Tabak").transform;
        }
    }
}
