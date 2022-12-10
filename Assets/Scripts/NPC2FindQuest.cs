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
    public bool spawnedBread = false;
    public float acceptedBaker;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        VariableTracker();
        BakerQuestAcceptTracker();
    }

    //check if the correct item is brought and set bools
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Bread"))
        {
            failedTask = true;
            SetValueFromCSharp();
        }
        if (other.gameObject.CompareTag("Butter"))
        {
            broughtButter = true;
            SetValueFromCSharp();
        }
    }

    //all variables to be called in YarnScript
    [YarnCommand("set_value_from_cSharp")]
    public void SetValueFromCSharp()
    {
        variableStorage.SetValue("$broughtButter", broughtButter);
        variableStorage.SetValue("$failedDeliveryTask", failedTask);
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
