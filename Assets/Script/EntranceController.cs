using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EntranceController : MonoBehaviour {
    public UnityEvent onPlayerEnter = new UnityEvent();
    public bool triggered = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered)
        {
            return;
        }
        if (collision.gameObject.tag.Equals("Player"))
        {
            onPlayerEnter.Invoke();
            CloseDoor();
        }
    }

    public void CloseDoor()
    {
        triggered = true;
        gameObject.transform.GetChild(0).gameObject.SetActive(true);
    }

    public void OpenDoor()
    {
        Destroy(gameObject);
    }
}
