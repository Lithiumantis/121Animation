using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    public GameObject playerReference;
    private Pickup pickupScript;

    public GameObject door;
    private new Animation animation;
    public int doorNumber;
    public int requiredScore = 0;
    string moveName;
    string closeName;
    // Start is called before the first frame update
    void Start()
    {
        animation = door.GetComponent<Animation>();
        pickupScript = playerReference.GetComponent<Pickup>();

        MeshRenderer rend = GetComponent<MeshRenderer>();
        rend.enabled = false;

        moveName = "Door" + doorNumber + "Move";
        closeName = "Door" + doorNumber + "Close";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" && pickupScript.score >= requiredScore)
        {
            animation.Play(moveName);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player" && pickupScript.score >= requiredScore)
        {
            animation.Play(closeName);
        }
    }
}
