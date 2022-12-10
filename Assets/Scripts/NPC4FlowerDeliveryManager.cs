using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC4FlowerDeliveryManager : MonoBehaviour
{

    public bool correctItemFlowerDelivered = false;
    public bool wrongItemBread = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            correctItemFlowerDelivered = true;
        }
        if (other.gameObject.CompareTag("Bread"))
        {
            wrongItemBread = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Flower"))
        {
            correctItemFlowerDelivered = false;
        }
        if (other.gameObject.CompareTag("Bread"))
        {
            wrongItemBread = false;
        }
    }
}
