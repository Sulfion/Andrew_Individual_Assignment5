using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;

public class EndSequenceManager : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;

    private float completeAllQuests = 0;
    private bool startEndSequence = false;


    // Update is called once per frame
    void Update()
    {
        VariableTracker();
    }

    //these script checks if all of the quests have been completed in yarn
    //if that is true, it sets the end sequence start flag to true
    //then it checks if the player is near the correct NPC and completed all the quests, which lets you move onto the final dialogue
    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.CompareTag("NPC1") && completeAllQuests == 1)
        {
            variableStorage.SetValue("$endSequence", startEndSequence = true);
        }
    }
    private void VariableTracker()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        variableStorage.TryGetValue("$completed_all_quests", out completeAllQuests);
    }
}
