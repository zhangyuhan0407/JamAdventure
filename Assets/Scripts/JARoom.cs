using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JARoom : MonoBehaviour
{
    public float stepLength;


    public bool isMoving;
    public Vector3 destination;


    Vector3 originalPosition;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        originalPosition = Vector3.zero;
        player = null;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if(isMoving)
        {
            return;
        }

        if(JAGameManager.Instance.isControlingPlayer)
        {
            return;
        }

        if(this.player == null)
        {
            return;
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            destination = transform.position + new Vector3(0, 0, stepLength);
            StartCoroutine(MoveAnimation());
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            destination = transform.position + new Vector3(0, 0, -stepLength);
            StartCoroutine(MoveAnimation());
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            destination = transform.position + new Vector3(-stepLength, 0, 0);
            StartCoroutine(MoveAnimation());
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("Go Right " + this.gameObject.name);
            destination = transform.position + new Vector3(stepLength, 0, 0);
            StartCoroutine(MoveAnimation());
        }
    }



    IEnumerator MoveAnimation()
    {
        originalPosition = transform.position;
        isMoving = true;
        Vector3 step = (destination - transform.position) / 60;
        int i = 0;
        while(i++ < 60)
        {
            transform.position += step;
            if(player != null)
            {
                player.transform.position += step;
            }
            yield return new WaitForEndOfFrame();
        }
        isMoving = false;
    }


    public void StopMoving()
    {
        StopCoroutine(MoveAnimation());
        transform.position = originalPosition;
    }


    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            this.player = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            this.player = null;
        }
    }

}
