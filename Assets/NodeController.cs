using UnityEngine;

public class NodeController : MonoBehaviour
{
    public Transform[] nodeTransforms;
    public SimpleLinkedList<Node> nodes = new SimpleLinkedList<Node>(); 

    void Start()
    {
        nodes.Clear();
        for (int i = 0; i < nodeTransforms.Length; i++)
        {
            Transform nodeTransform = nodeTransforms[i];
            Node node = nodeTransform.GetComponent<Node>();
            if (node != null)
            {
                AddNode(node);
            }
        }
    }

    public void AddNode(Node node)
    {
        nodes.InsertAtEnd(node);
    }

    public Node GetRandomNode()
    {
        Node randomNode = nodes.GetAtPosition(Random.Range(0, nodes.GetCapacity()));
        return randomNode;
    }
}



