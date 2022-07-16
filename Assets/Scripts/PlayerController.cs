using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public InputMaster controls;
    public float moveSpeed = 5f;
    public Transform movePoint;

    public LayerMask whatStopsMovement;

    private bool movingAllowed = true;

    public int healthPoints = 20;
    public int movementPoints = 0;
    public int inventoryPoints = 0;

    private void Awake()
    {
        //Instanciate the input handler and bind actions.
        controls = new InputMaster();
        controls.Combat.Move.performed += ctx => Move(ctx.ReadValue<Vector2>());
    }


    // Start is called before the first frame update
    void Start()
    {
        //Unbind the movePoint from the player.
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //move the player to the movePoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);
        
        //Check if the player has reached the movePoint
        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            movingAllowed = true;
        }
        else
        {
            movingAllowed = false;
        }
    }

    void Move(Vector2 movement)
    {
        if (movingAllowed)
            if (movementPoints != 0)
            {
                {
                    //Create a copy of the movement vector to keep things safe
                    Vector3 calcMove = new Vector3(movement.x, movement.y, 0.0f);

                    //Hacky fix to prevent diagonal movement.
                    if (Mathf.Abs(calcMove.x) == Mathf.Abs(calcMove.y))
                    {
                        calcMove = Vector3.zero;
                    }

                    //Check if we can move to a place without colliding.
                    if (!Physics2D.OverlapCircle(movePoint.position + calcMove, .2f, whatStopsMovement))
                    {
                        movePoint.position += calcMove;
                    }

                    movementPoints--;
                }
            }

        
    }


    //Enable / Disable the input master
    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
