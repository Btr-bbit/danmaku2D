using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{

    private GameObject def, shine;
    public GameObject pointerPrefab;
    private GameObject pointer;
    public float changeTime = 1.0f;
    public Vector3 upPos = new Vector3(-0.18f, 1.8f, 0);
    public bool switchedAway = false;

    // Use this for initialization
    void Start()
    {
        def = transform.GetChild(0).gameObject;
        shine = transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void OnTriggerStay2D(Collider2D other)
	{
        if (Input.GetKey(KeyCode.Return) && !switchedAway)
        {
            SceneController.instance.switch2Game();
            switchedAway = true;
        }
	}

	private void OnTriggerEnter2D(Collider2D collision)
	{
        Color col = def.GetComponent<SpriteRenderer>().color;
        col.a = 0;
        def.GetComponent<SpriteRenderer>().color = col;

        col = shine.GetComponent<SpriteRenderer>().color;
        col.a = 1;
        shine.GetComponent<SpriteRenderer>().color = col;

        pointer = Instantiate(pointerPrefab, transform.position - upPos, transform.rotation);
	}

	private void OnTriggerExit2D(Collider2D collision)
	{
        Color col = def.GetComponent<SpriteRenderer>().color;
        col.a = 1;
        def.GetComponent<SpriteRenderer>().color = col;

        col = shine.GetComponent<SpriteRenderer>().color;
        col.a = 0;
        shine.GetComponent<SpriteRenderer>().color = col;

        Destroy(pointer);
	}
}
