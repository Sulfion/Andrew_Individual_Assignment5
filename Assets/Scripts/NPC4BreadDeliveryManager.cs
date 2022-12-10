using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class NPC4BreadDeliveryManager : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;

    public bool correctItemBreadDelivered = false;
    public bool wrongItemFlower = false;

    //check if the correct or incorrect item is brought, set bools to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            variableStorage.SetValue("$deliveredTheBread", correctItemBreadDelivered = true);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$deliveredNotBread", wrongItemFlower = true);
        }
    }

    //check if correct or incorrect item has left, set bools to false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            variableStorage.SetValue("$deliveredTheBread", correctItemBreadDelivered = false);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$deliveredNotBread", wrongItemFlower = false);
        }
    }
}
