using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class AmmoDisplay : MonoBehaviour
{
    public int fireballammo;
    public bool isFiring;
    public Text fireballammoDisplay;

    void Start()
    {
        
    }

    void Update()
    {
        fireballammoDisplay.text = fireballammo.ToString();
        if (Input.GetMouseButtonDown(0) && !isFiring && fireballammo > 0) 
        {
            isFiring = true;
            fireballammo--;
            isFiring = false;
        }

    }


}
