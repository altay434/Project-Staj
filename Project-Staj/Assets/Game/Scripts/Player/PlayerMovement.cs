using UnityEngine;



public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private Rigidbody rb;
    [SerializeField] private JoystickController joystick;
    [SerializeField] private Animator animator;

    [SerializeField] private PlayerData playerData;


    private void FixedUpdate()
    {
        var speed = playerData.Speed;
        rb.velocity = new Vector3(joystick.Horizontal * speed, 0, joystick.Vertical * speed);
        if (rb.velocity != Vector3.zero)
        {
            animator.SetBool("isRunning", true);
        }
        else
        {
            animator.SetBool("isRunning", false);
        }
    }







}
