using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC4FlowerDeliveryManager : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;

    public bool correctItemFlowerDelivered = false;
    public bool wrongItemBread = false;

    //check if the correct or incorrect item is brought, set bools to true
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        { 
            variableStorage.SetValue("$deliveredTheFlower", correctItemFlowerDelivered = true);
        }
        if (other.gameObject.CompareTag("Bread"))
        {        
            variableStorage.SetValue("$deliveredNotFlower", wrongItemBread = true);
        }
    }

    //check if correct or incorrect item has left, set bools to false
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {           
            variableStorage.SetValue("$deliveredTheFlower", correctItemFlowerDelivered = false);
        }
        if (other.gameObject.CompareTag("Bread"))
        {    
            variableStorage.SetValue("$deliveredNotFlower", wrongItemBread = false);
        }
    }
}
