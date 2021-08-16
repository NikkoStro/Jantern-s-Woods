using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossroads : MonoBehaviour
{

    public GameObject block;
    public GameObject otherBlock;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider col)
    {
        if(gameObject.tag == "CRSwitch")
        {
            block.SetActive(false);
        }
    }

    public void OnCollisionEnter(Collision col)
    {
        if (gameObject.tag == "Block")
        {
            block.SetActive(false);
            otherBlock.SetActive(true);
        }
    }

}
