using UnityEngine;

public class AiBoss : MonoBehaviour
{
    public Rigidbody rigidbody;
    public Animator animator;

    public GameObject player;

    public float walkingSpeed;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        float playerX = player.transform.position.x;
        float playerZ = player.transform.position.z;

        Vector3 walkingForce = Vector3.zero;
        walkingForce += (new Vector3(walkingSpeed, 0.0f, 0.0f)) * (x > playerX ? -1.0f : 1.0f);
        walkingForce += (new Vector3(0.0f, 0.0f, walkingSpeed)) * (z > playerZ ? -1.0f : 1.0f);

        rigidbody.AddForce(walkingForce);
        animator.SetFloat("Speed", rigidbody.linearVelocity.magnitude);
    }
}
