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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            variableStorage.SetValue("$failedNPC4Task", correctItemBreadDelivered = true);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$failedNPC4Task", wrongItemFlower = true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            variableStorage.SetValue("$failedNPC4Task", correctItemBreadDelivered = false);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$failedNPC4Task", wrongItemFlower = false);
        }
    }
}
