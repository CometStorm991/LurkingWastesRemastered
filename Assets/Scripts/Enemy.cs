using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 3f;
    public float turnSpeed = 360f;
    public GameObject player;

    private CharacterController controller;
    private Animator anim;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;

        Vector3 direction = player.transform.position - transform.position;
        direction.y = 0f;

        if (direction.magnitude > 0.1f)
        {
            // Move forward
            Vector3 move = direction.normalized * speed;
            controller.Move(move * Time.deltaTime);

            // Rotate toward the player
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

            // Optional: trigger walk animation
            if (anim != null)
                anim.SetBool("running", true);
        }
        else
        {
            // Optional: stop walk animation
            if (anim != null)
                anim.SetBool("running", false);
        }
    }
}
