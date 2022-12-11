using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;

public class NPC3FollowQuest : MonoBehaviour
{
    public Transform playerPosition;
    public Transform npc3Home;
    public Transform flowerbedLocation;
    public InMemoryVariableStorage variableStorage;
    NavMeshAgent agent;

    public float acceptedEscort;
    public float tryAgain = 0;
    private float timer;

    public bool boolForYarn = false;
    public bool failedTask = false;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        VariableTracker();
        TryAgain();
        EscortQuestAcceptTracker();
    }

    //this method tracks gets vaaribles from yarnspinner
    //For example, if a player accepts a quest, delivers an item to the correct item, the current state will be stored here
    private void VariableTracker()
    {
        variableStorage = GameObject.FindObjectOfType<InMemoryVariableStorage>();
        variableStorage.TryGetValue("$accepted_escort", out acceptedEscort);
        variableStorage.TryGetValue("$tryAgain", out tryAgain);
    }

    //script for making the NPC follow player and return home condition
    public void followThePlayer()
    {
        agent.destination = playerPosition.position;
        timer += Time.deltaTime;
        if (boolForYarn == true)
        {
            agent.destination = npc3Home.transform.position;
        }
        if (timer > 60.0f)
        {
            agent.destination = npc3Home.transform.position;
            variableStorage.SetValue("$acceptedEscort", acceptedEscort = 0);
            variableStorage.SetValue("$failedTask", failedTask = true);

        }
    }

    //if the player has accepted the quest, start following the player, if the player takes too long to bring them to the flowers, they'll go home
    private void EscortQuestAcceptTracker()
    {
        if (acceptedEscort == 1)
        {
            //Debug.Log("Thanks!");
            GetComponent<NavMeshAgent>().speed = (1.0f);
            followThePlayer();
        }
    }

    private void TryAgain()
    {
        if(tryAgain == 1)
        {
            timer = 0.0f;
            followThePlayer();
        }
    }

    //when the NPC arrives, set quest completion to complete
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flowerbed"))
        {
            //Debug.Log("FLOWERS!!");
            variableStorage.SetValue("$dummyBoolVisitedFlowers", boolForYarn = true);
        }
    }
}