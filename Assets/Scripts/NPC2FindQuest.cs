using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class NPC2FindQuest : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;
    public GameObject butterPrefab;

    public bool broughtButter = false;
    public bool failedTask = false;
    private bool spawnedBread = false;
    public float acceptedBaker;

    // Update is called once per frame
    void Update()
    {
        BakerQuestAcceptTracker();
        VariableTracker();
    }

    //check if the correct item is brought and set bools
    //if incorrect item is brought, do something in yarnspinner
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Butter"))
        {
            variableStorage.SetValue("$broughtButter", broughtButter = true);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$failedDeliveryTask", failedTask = true);
        }
    }

    //check if the correct item is taken away and set bools
    //if incorrect item is taken away, allow quest completion to be possible again
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Butter"))
        {
            variableStorage.SetValue("$broughtButter", broughtButter = false);
        }
        if (other.gameObject.CompareTag("Flower"))
        {
            variableStorage.SetValue("$failedDeliveryTask", failedTask = false);
        }
    }

    //this method tracks what variables have changed.
    //For example, if a player accepts a quest, delivers an item to the correct item, the current state will be stored here
    private void VariableTracker()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        variableStorage.TryGetValue("$accepted_baker", out acceptedBaker);
    }

    private void BakerQuestAcceptTracker()
    {
        if (acceptedBaker == 1 && spawnedBread == false)
        {
            Instantiate(butterPrefab);
            spawnedBread = true;
        }
    }
}
