using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    Animator anim;

    public GameObject player;

    public GameObject Gameover;

    public bool GOver;

    public GameObject GetPlayer()
    {
        return player;
    }

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        anim.SetFloat("distance", Vector3.Distance(transform.position, player.transform.position));
	}

    public void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Player")
        {
            GOver = true;
            Gameover.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
