using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private float speed = 5f;

    public bool point = false;

    public bool f;

    public bool b;

    public Crossroads cr;

    public Sprint sprnt;

    public int sprint;

    public bool bSprint;

    public GameObject youWin;

    public Rigidbody rb;

    public GameObject textBox;

    public Text txt1;

    public bool textBool;

    public int i;

    public Vector3 lastPos;

    public ScoreHandler scre;

    public Text obj;

    public GameObject complete;

    public bool objective1;

    public GameObject objectiveList;

    public EnemyAI enemy;

    public bool hasCandle;

    public GameObject candle;

    public GameObject flashlight;

    //public Collider coll;

    //Ray ray = Camera.main.ScreenPointToRay(Vector3.forward);

    //RaycastHit hit;

    // Use this for initialization
    void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
        //coll = GetComponent<Collider>();
        objective1 = false;
        Time.timeScale = 1;
    }
	
	// Update is called once per frame
	void Update ()
    {

        

        if (Input.GetKeyDown(KeyCode.O))
        {
            objectiveList.SetActive(true);

        }

        if (Input.GetKeyUp(KeyCode.O))
        {
            objectiveList.SetActive(false);

        }

        //Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        //Debug.DrawRay(transform.position, forward, Color.green);

        //if (Physics.Raycast (transform.position, hit))
        //{

        //}

        if (Input.GetKeyDown(KeyCode.A) && point == false && enemy.GOver == false)
        {
            i = 0;
            textBox.SetActive(false);
            transform.Rotate(new Vector3(0, -90, 0) * speed, Space.World);
            
        }

        if (Input.GetKeyDown(KeyCode.D) && point == false && enemy.GOver == false)
        {
            i = 0;
            textBox.SetActive(false);
            transform.Rotate(new Vector3(0, 90, 0) * speed, Space.World);
            
        }

        if (Input.GetMouseButton(0))
        {
            i = 0;
            textBox.SetActive(false);
        }

        if (Input.GetKey(KeyCode.Space) && sprnt.currentSprint > 0)
        {
            
            bSprint = true;
        }

        if(bSprint == true)
        {
            speed = 9f;
        }

        if (Input.GetKeyUp(KeyCode.Space) || sprnt.currentSprint < 1)
        {
            bSprint = false;
            speed = 5f;
            i = 0;
            textBox.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.W) && enemy.GOver == false)
        {
            i = 0;
            textBox.SetActive(false);
            point = true;
            
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            hasCandle = false;
        }

        if (point == true)
        {
            GetComponent<NavMeshAgent>().Move(transform.forward * Time.deltaTime * speed);
        }

        if (textBool == true)
        {
            i++;
        }

        if (i == 300)
        {
            i = 0;
            textBool = false;
            textBox.SetActive(false);
            
        }

        if(objective1 == true)
        {
            complete.SetActive(true);
        }

        if(hasCandle == true)
        {
            candle.SetActive(true);
            flashlight.SetActive(false);
        }
        else
        {
            candle.SetActive(false);
            flashlight.SetActive(true);
        }

    }

    public void OnCollisionEnter(Collision col)
    {
        //transform.position += new Vector3(1, 0, 0);
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Crys")
        {
            scre.scoreValue += 150;
            scre.crystalCount += 1;
        }

        if (col.gameObject.tag == "Goal")
        {
            Time.timeScale = 0;
            youWin.SetActive(true);
        }

        if (col.gameObject.tag == "Block")
        {
            point = false;
            transform.position = col.transform.position;
            lastPos = col.transform.position;
        }

        if (col.gameObject.tag == "T1")
        {
            textBox.SetActive(true);
            txt1.text = "You cannot leave this way...";
            textBool = true;
            point = false;
            transform.position = lastPos;
        }

        if (col.gameObject.tag == "T2")
        {
            textBox.SetActive(true);
            txt1.text = "You must complete all objectives to pass...";
            textBool = true;
            point = false;
            transform.position = lastPos;
        }

        if (col.gameObject.tag == "T3")
        {
            hasCandle = true;
        }

        if (col.gameObject.tag == "Wall")
        {
            point = false;
            transform.position = lastPos;
        }
    }

    public void OnTriggerStay(Collider col)
    {
        if (col.gameObject.tag == "Block")
        {
            bSprint = false;
        }
    }
}
