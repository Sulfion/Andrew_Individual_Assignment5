using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using static UnityEngine.Rendering.DebugUI;

public class YarnCommandHolder : MonoBehaviour
{
    public InMemoryVariableStorage variableStorage;

    float testVariable;

    // Start is called before the first frame update
    void Start()
    {

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
        variableStorage.TryGetValue("$visited_town_crier", out testVariable);
    }
}
