using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    GameObject[] goalLocations;
    NavMeshAgent agent;
    private bool dontStop = true;

    // Start is called before the first frame update
    void Start()
    {
        SetRandomGoalForAgents();
        StartCoroutine(RandomMoveSpeed());
    }

    private void Update()
    {
        SetNewRandomGoalForAgents();
    }

    private void SetRandomGoalForAgents()
    {
        goalLocations = GameObject.FindGameObjectsWithTag("goal");
        agent = this.GetComponent<NavMeshAgent>();
        agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
    }

    private void SetNewRandomGoalForAgents()
    {
        if (agent.remainingDistance < 1)
        {
            agent.SetDestination(goalLocations[Random.Range(0, goalLocations.Length)].transform.position);
        }
    }

    IEnumerator RandomMoveSpeed()
    {
        while (dontStop == true)
        {
            GetComponent<NavMeshAgent>().speed = Random.Range(1.0f, 5.0f); //set a random speed for each agent
            yield return new WaitForSeconds(Random.Range(5.0f, 20.0f));
        }
    }
}
