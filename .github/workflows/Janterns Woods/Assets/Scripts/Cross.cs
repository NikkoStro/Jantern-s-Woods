using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cross : MonoBehaviour {

    public GameObject Player;

    public Vector3 pos;

	// Use this for initialization
	void Start () {
        pos = gameObject.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerEnter(Collider other)
    {
        if(gameObject.tag == "Block")
        {
            Player.transform.position = pos;
        }
    }
}
