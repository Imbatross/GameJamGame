using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Rewired;

public class PlayerController : MonoBehaviour
{
    public int playerId;

    [Range(0, 5)]public float moveSpeed;

    private Player player; // The rewired player
    private Rigidbody2D rb;
    private Vector3 moveVector;
    private bool action;

    private bool isColliding;
    private InteractableObject currentObject;

    // Start is called before the first frame update
    void Start()
    {
        player = ReInput.players.GetPlayer(playerId);

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        ProcessInput();
        //Debug.Log(player.GetAxis("Move Horizontal"));
        //Debug.Log(player.GetAxis("Move Vertical"));
        //Debug.Log(player.GetButtonDown("Action"));
    }

    private void GetInput()
    {
        moveVector.x = player.GetAxis("Move Horizontal");
        moveVector.y = player.GetAxis("Move Vertical");
        action = player.GetButtonDown("Action");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliding");

        isColliding = true;
        currentObject = collision.gameObject.GetComponent<InteractableObject>();

        Debug.Log(currentObject.gameObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == currentObject.gameObject)
        {
            isColliding = false;
            currentObject = null;
        }
    }

    private void ProcessInput()
    {
        if (moveVector.x != 0.0f || moveVector.y != 0.0f)
        {
            rb.velocity = moveVector * moveSpeed * Time.deltaTime * 100;
        }
        else
        {
            rb.velocity *= 0;
        }

        if (action && isColliding)
        {
            currentObject.Activate();
        }
    }
}
