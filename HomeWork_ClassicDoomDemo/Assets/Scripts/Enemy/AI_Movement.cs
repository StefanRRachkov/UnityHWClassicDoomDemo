using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class AI_Movement : MonoBehaviour
{
    public GameObject pointOfInterest;
    public int direction = 1; // 1 -> forward; -1 -> backwards
    
    [SerializeField]
    [Range(0.5f, 3)]
    private float speed = 1;

    private float initialSpeed;
    private float initialAngularSpeed;
    private float initialAccelaration;

    private NavMeshAgent agent;

    private Vector3 forwardDirection = Vector3.forward;
    private Vector3 sidewaysDirection = Vector3.right;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        initialSpeed = agent.speed;
        initialAngularSpeed = agent.angularSpeed;
        initialAccelaration = agent.acceleration;
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(pointOfInterest.transform);
        
        agent.speed = initialSpeed * speed;
        agent.angularSpeed = initialAngularSpeed * speed;
        agent.acceleration = initialAccelaration * speed;

        agent.destination = transform.position + (forwardDirection * direction).normalized;

        // Get forward vector towards pointOfInterest 
        forwardDirection = pointOfInterest.transform.position - this.transform.position;
    }
}
