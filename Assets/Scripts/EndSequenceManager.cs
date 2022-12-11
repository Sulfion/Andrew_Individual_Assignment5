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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        VariableTracker();
    }

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
