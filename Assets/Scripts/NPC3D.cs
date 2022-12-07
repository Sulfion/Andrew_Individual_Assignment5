using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
public class NPC3D : MonoBehaviour
{
    public string characterName = "";
    public string talkToNode = "";
    private float timer;
    public YarnProject scriptToLoad;
    public DialogueRunner dialogueRunner; //refeernce to the dialogue control
    public GameObject dialogueCanvas; //reference to the canvas
    public Vector3 PostionSpeachBubble = new Vector3(0f, 2.0f, 0.0f);

    public bool triggerTimer = false;
    /// </summary>
    // Start is called before the first frame update

    void Start()
    {
        dialogueCanvas = GameObject.Find("Dialogue Canvas"); //this is bad way to do this but hey we doing this quickly
        dialogueRunner = FindObjectOfType<Yarn.Unity.DialogueRunner>();
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

    private void Update()
    {
        if (triggerTimer)
        {
            timer += Time.deltaTime;
            if (timer >= 5)
            {
                Debug.Log(timer);
                Debug.Log("Why are you still here?");
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        //if other is player
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueCanvas.SetActive(true);

            triggerTimer = true;

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
        //control conditions for NPC1
        if (this.gameObject.CompareTag("NPC1"))
        {
            Debug.Log("Hello I am NPC1.");
        }
        //control conditions for NPC2
        if (this.gameObject.CompareTag("NPC2"))
        {
            Debug.Log("Hello I am NPC2.");
        }
        //control conditions for NPC3
        if (this.gameObject.CompareTag("NPC3"))
        {
            Debug.Log("Hello I am NPC3.");
        }
        //control conditions for NPC4
        if (this.gameObject.CompareTag("NPC4"))
        {
            Debug.Log("Hello I am NPC4");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            dialogueCanvas.SetActive(false);
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Player"))
    //    {
    //        timer = Time.deltaTime;
    //        if (timer >= 5)
    //        {
    //            Debug.Log(timer);
    //            Debug.Log("Why are you still here?");
    //        }
    //    }
    }
}