using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //float yMovement = 0f; // for checking whether player is pressing keys related to moving up or down
    //float xMovement = 0f; // for checking whether player is pressing keys relating to moving left or right
    //Vector2 targetVelocity = new Vector2(0, 0); // this is where the new velocity vector will be stored
    //Rigidbody2D myRigidBody; // for accessing the Rigid Body component of the player character
    //[Range(0, .3f)][SerializeField] private float smoothTime = .1f; // how much to smooth out the velocity changes. This will add a range value into the editor. So we can change it outwith the code.
    //private Vector2 velocity = Vector2.zero; // 
    public float BoatSpeed = 1f; // sets the movement speed for the player character and makes it editable within Unity
    public int m_ScreenID = -1;
    private Vector2 inputDirection = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        //myRigidBody = GetComponent<Rigidbody2D>(); // calls the previously accessed RigidBody at the first frame.
    }
    public void HandleDirectionalInput(Vector2 direction)
    {
        //Save the direciton to use later
        inputDirection = direction;

        if (direction.y == 1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 0f);
        }

        if (direction.x == -1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 90f);
        }

        if (direction.y == -1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 180f);
        }

        if (direction.x == 1f)
        {
            transform.eulerAngles = new Vector3(0, 0, 270f);
        }
    }
    void checkAxis() // This checks if user pressed left or right
    {                // All the inputs can be viewed in ProjectSettings
        //xMovement = Input.GetAxis("Horizontal");
        //yMovement = Input.GetAxis("Vertical");

        // if (xMovement >= 0.1||xMovement <= -0.1||yMovement >= 0.1||yMovement <= -0.1)
        // {
        //   GetComponent<Animator>().SetBool("Moving", true);
        //  }
        //  else
        //  {
        //      GetComponent<Animator>().SetBool("Moving", false);
        //  }

      
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveDirection = inputDirection;
        transform.position += (Vector3)moveDirection * BoatSpeed * Time.deltaTime; // Time.deltaTime makes our movement consistent regardless of framerate
        transform.position = ScreenUtility.ClampToScreen(transform.position, m_ScreenID, 0.5f);
    }
}
