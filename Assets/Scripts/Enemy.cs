using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform movePoint;
    public float moveSpeed = 5f;

    public GameObject player;
    private Transform playerTransform;
    [SerializeField] private int moves = 0;
    private bool movingAllowed = true;
    public MovePattern movePattern;
    public LayerMask playerLayerMask;

    public enum MovePattern
    {
        Slime,
        Dragon,
        Skeleton,
        Sans
    }

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.GetComponent<Transform>();

        movePoint.parent = null;

        StartCoroutine("MakeRandomMove");
    }

    // Update is called once per frame
    void Update()
    {
        //move the player to the movePoint
        transform.position = Vector3.MoveTowards(transform.position, movePoint.position, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, movePoint.position) <= 0.05f)
        {
            movingAllowed = true;
        }
        else
        {
            movingAllowed = false;
        }
    }

    IEnumerator MakeRandomMove()
    {
        yield return new WaitForSeconds(1);
        move();
        StartCoroutine(MakeRandomMove());
    }

    void move()
    {
        Vector3 calcMove;
        switch (movePattern)
        {
            case MovePattern.Slime:

                calcMove = new Vector3(Random.Range(-1, 1), Random.Range(-1, 1), 0.0f);

                //Check if we can move to a place without colliding.
                if (!Physics2D.OverlapCircle(movePoint.position + calcMove, .2f, playerLayerMask))
                {
                    movePoint.position += calcMove;
                }
                else
                {
                    player.GetComponent<PlayerController>().health -= 5;
                }
                break;

            case MovePattern.Dragon:
                if (playerTransform.position.y - movePoint.position.y == 0)
                {
                    if (playerTransform.position.x - movePoint.position.x > 0)
                    {
                        calcMove = new Vector3(1.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        calcMove = new Vector3(-1.0f, 0.0f, 0.0f);
                    }
                    
                }
                else
                {
                    if (playerTransform.position.y - movePoint.position.y > 0)
                    {
                        calcMove = new Vector3(0.0f, 1.0f, 0.0f);
                    }
                    else
                    {
                        calcMove = new Vector3(0.0f, -1.0f, 0.0f);
                    }
                }
                break;
            case MovePattern.Skeleton:
                if (playerTransform.position.y - movePoint.position.y == 0)
                {
                    if (playerTransform.position.x - movePoint.position.x > 0)
                    {
                        calcMove = new Vector3(1.0f, 0.0f, 0.0f);
                    }
                    else
                    {
                        calcMove = new Vector3(-1.0f, 0.0f, 0.0f);
                    }

                }
                else
                {
                    if (playerTransform.position.y - movePoint.position.y > 0)
                    {
                        calcMove = new Vector3(0.0f, 1.0f, 0.0f);
                    }
                    else
                    {
                        calcMove = new Vector3(0.0f, -1.0f, 0.0f);
                    }
                }
                break;
            case MovePattern.Sans:
                calcMove = new Vector3(playerTransform.position.x, playerTransform.position.y, playerTransform.position.z);
                break;

            default:
                calcMove = new Vector3(0.0f, 0.0f, 0.0f);
                break;
        }

        //Hacky fix to prevent diagonal movement.
        if (Mathf.Abs(calcMove.x) == Mathf.Abs(calcMove.y))
        {
            calcMove = Vector3.zero;
        }

        //Check if we can move to a place without colliding.
        if (!Physics2D.OverlapCircle(movePoint.position + calcMove, .2f, playerLayerMask))
        {
            movePoint.position += calcMove;
        }
        else
        {
            Debug.Log("Gottem.");
            player.GetComponent<PlayerController>().health -= 5;
        }
    }
}
