using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Yarn.Unity;
public class NPC3D : MonoBehaviour
{
    public YarnProject scriptToLoad;
    public DialogueRunner dialogueRunner; //refeernce to the dialogue control
    public GameObject dialogueCanvas; //reference to the canvas
    public YarnCommandHolder yarnCommandVariables;

    public string characterName = "";
    public string talkToNode = "";
    public Vector3 PostionSpeachBubble = new Vector3(0f, 2.0f, 0.0f);
    public bool triggerTimer = false;



    // Start is called before the first frame update
    void Start()
    {
        dialogueCanvas = GameObject.Find("Dialogue Canvas"); //this is bad way to do this but hey we doing this quickly
        dialogueRunner = FindObjectOfType<DialogueRunner>();
        if (scriptToLoad == null)
        {
            Debug.LogError("NPC3D not set up with yarn scriptToLoad ", this);
        }
        if (string.IsNullOrEmpty(characterName))
        {
            Debug.LogWarning("NPC3D not set up with characterName", this);
        }
        if (string.IsNullOrEmpty(talkToNode))
        {
            Debug.LogError("NPC3D not set up with talkToNode", this);
        }
        if (dialogueRunner == null)
        {
            Debug.LogError("dialogueRunner not set up", this);
        }

        if (dialogueCanvas == null)
        {
            Debug.LogError("Dialogue Canvas not set up", this);
        }

        if (scriptToLoad != null && dialogueRunner != null && dialogueRunner != null)
        {
            dialogueRunner.yarnProject = scriptToLoad; //adds the script to the dialogue system
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueCanvas.SetActive(true);

            triggerTimer = true; //start the timer

            if (!string.IsNullOrEmpty(talkToNode))
            {
                if (dialogueCanvas != null)
                {
                    //move the Canvas to the object and off set
                    dialogueCanvas.transform.SetParent(transform); // use the root to prevent scaling
                    dialogueCanvas.GetComponent<RectTransform>().anchoredPosition3D = transform.TransformVector(PostionSpeachBubble);
                }
                if (dialogueRunner.IsDialogueRunning)
                {
                    dialogueRunner.Stop();
                }
                Debug.Log("start dialogue");
                dialogueRunner.StartDialogue(talkToNode);
            }
        }
    }

    //hide dialogue canvas when player moves away
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueCanvas.SetActive(false);
            triggerTimer = false;
        }
    }
}