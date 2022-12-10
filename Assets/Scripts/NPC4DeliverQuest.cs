using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;

public class NPC4DeliverQuest : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;
    public NPC4BreadDeliveryManager breadDeliveryManager;
    public NPC4FlowerDeliveryManager flowerDeliveryManager;
    private NPC2FindQuest setValueMethodCaller;

    public float acceptedDelivery;
    public bool deliveredBread = false;
    public bool deliveredFlower = false;
    public bool failedDeliveryTask = false;
    public bool succeedDeliveryTask = false;

    public GameObject bread;
    public GameObject flower;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(bread);
        Instantiate(flower);
    }

    // Update is called once per frame
    void Update()
    {
        VariableTracker();
    }

    //this method tracks what variables have changed.
    //For example, if a player accepts a quest, delivers an item to the correct item, the current state will be stored here
    private void VariableTracker()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        variableStorage.TryGetValue("$accepted_delivery", out acceptedDelivery);
    }

    //check if the correct item is brought and set bools
    private void OnTriggerEnter(Collider other)
    {
        if (breadDeliveryManager.correctItemBreadDelivered == true)
        {
            deliveredBread = true;
        }
        if (flowerDeliveryManager.correctItemFlowerDelivered)
        {
            deliveredFlower = true;
        }
    }

    //check to see if both items were delivered to correct NPC
    public void CheckIfBothItemsDelivered()
    {
        if (deliveredBread == true && deliveredFlower == true)
        {
            succeedDeliveryTask = true;
        }
    }

    //check to see if at least one item was delivered to the wrong NPC
    public void CheckIfWrongDelivery()
    {
        if (flowerDeliveryManager.wrongItemBread == true || breadDeliveryManager.wrongItemFlower == true)
        {
            failedDeliveryTask = true;
        }
    }
}
