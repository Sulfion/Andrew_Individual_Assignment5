using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4BreadDeliveryManager : MonoBehaviour
{

    public bool correctItemBreadDelivered = false;
    public bool wrongItemFlower = false;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            correctItemBreadDelivered = true;
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            wrongItemFlower = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            correctItemBreadDelivered = false;
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            wrongItemFlower = false;
        }
    }
}
