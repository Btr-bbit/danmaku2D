using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {
    public GameObject runAnimation;

	// Use this for initialization
	void Start () {
        gameObject.GetComponent<Player>().onPlayerContinuouslyMove.AddListener(generateRunAnimation);
    }
	
	// Update is called once per frame
	void Update () {

	}

    public void generateRunAnimation()
    {
        Vector3 moveDirection = getMoveDirection();
        Debug.Log(moveDirection);
        Quaternion rot = Quaternion.identity;
        rot.SetFromToRotation(Vector3.right, moveDirection);
        Instantiate(runAnimation, gameObject.transform.position, rot);
    }

    private Vector3 getMoveDirection()
    {
        return gameObject.GetComponent<Player>().moveDirection;
    }
}
