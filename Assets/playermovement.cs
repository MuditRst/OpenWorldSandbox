using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermovement : MonoBehaviour
{
    [SerializeField] private string HorizontalInput;
    [SerializeField] private string VerticalInput;
     private float movementspeed;
    [SerializeField] private float jumpMultiplier;
    [SerializeField] private AnimationCurve jumpfalloff;
    [SerializeField] private KeyCode jumpKey;
    [SerializeField] private float runspeed,walkspeed;
    [SerializeField] private float runbuildup;
    [SerializeField] private KeyCode runKey;
    

    private CharacterController charController;
    private bool isJumping;

    private void Awake()
    {
        
        charController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        float vertInput = Input.GetAxis(VerticalInput) * movementspeed;
        float horiInput = Input.GetAxis(HorizontalInput) * movementspeed;
        Vector3 forwardmove = transform.forward * vertInput;
        Vector3 rightmove = transform.right * horiInput;

        charController.SimpleMove(forwardmove + rightmove);

        JumpInput();
        runmovement();
    }

    private void runmovement()
    {
        if(Input.GetKey(runKey))
        {
            movementspeed = Mathf.Lerp(movementspeed,runspeed,Time.deltaTime * runbuildup);
        }else
        {
            movementspeed = Mathf.Lerp(movementspeed,walkspeed,Time.deltaTime * runbuildup);
        }
    }

    private void JumpInput()
    {
        if(Input.GetKeyDown(jumpKey) && !isJumping)
        {
            isJumping = true;
            StartCoroutine(JumpEvent());
        }
    }

    private IEnumerator JumpEvent()
    {
        charController.slopeLimit = 90.0f;
        float timeInAir = 0.0f;

        do
        {
            float jumpforce = jumpfalloff.Evaluate(timeInAir);
            charController.Move(Vector3.up * jumpforce * jumpMultiplier * Time.deltaTime);
            timeInAir += Time.deltaTime;
            yield return null; 
        } while (!charController.isGrounded && charController.collisionFlags != CollisionFlags.Above);

        charController.slopeLimit = 45.0f;
        isJumping = false;
    }
}
