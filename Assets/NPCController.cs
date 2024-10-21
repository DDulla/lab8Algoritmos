using System.Collections;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    public NodeController nodeController; 
    private Node currentNode;
    private Node targetNode;
    public float speed = 5f;
    public float energy = 20f; 
    public float restDuration = 4f; 

    void Start()
    {
        currentNode = nodeController.GetRandomNode(); 
        transform.position = currentNode.transform.position; 
    }

    void Update()
    {
        if (energy <= 0)
        {
            StartCoroutine(Rest());
        }
        else if (targetNode == null)
        {
            targetNode = nodeController.GetRandomNode();
        }
        else
        {
            MoveToTarget();
        }
    }

    void MoveToTarget()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetNode.transform.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetNode.transform.position) < 0.1f)
        {
            energy -= targetNode.weight; 
            currentNode = targetNode;
            targetNode = null;
        }
    }

    IEnumerator Rest()
    {
        yield return new WaitForSeconds(restDuration);
        energy = 20f; 
    }
}



