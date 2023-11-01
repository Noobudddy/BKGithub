using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public GameObject BatOnPlayer;
    //public GameObject GrappleOnPlayer;
    //public GameObject FireballCardOnPlayer;

    //public LayerMask playerLayer;

    private void Start()
    {
        BatOnPlayer.SetActive(false);
        //GrappleOnPlayer.SetActive(false);
        //FireballCardOnPlayer.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player layer was found");

            if (Input.GetKeyDown(KeyCode.F))
            {
                Debug.Log("Player is trying to pick up item");
                this.gameObject.SetActive(false);

                BatOnPlayer.SetActive(true);
            }
        }
    }
}
