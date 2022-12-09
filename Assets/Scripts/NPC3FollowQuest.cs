using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class NPC3FollowQuest : MonoBehaviour
{
    public Transform playerToFollow;
    public InMemoryVariableStorage variableStorage;
    NavMeshAgent agent;

    public float acceptedEscort;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        VariableTracker();
        EscortQuestAcceptTracker();
    }
    private void VariableTracker()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        variableStorage.TryGetValue("$accepted_escort", out acceptedEscort);
    }

    public void followThePlayer()
    {
        agent.destination = playerToFollow.position;
    }

    //if the player has accepted the quest, start following the player
    private void EscortQuestAcceptTracker()
    {
        if (acceptedEscort == 1)
        {
            Debug.Log("Thanks!");
            GetComponent<NavMeshAgent>().speed = (0.3f);
            followThePlayer();
        }
    }
}