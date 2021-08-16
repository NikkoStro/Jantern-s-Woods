using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    public Camera cam;

    public NavMeshAgent agent;

    public GameObject Flashlight;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {

            GetComponent<NavMeshAgent>().Move(transform.forward * Time.deltaTime);

            //Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            //RaycastHit hit;

            //if (Physics.Raycast(ray, out hit)) ;
            //{
            //    agent.SetDestination(hit.point);
            //}
        }
    }
}
