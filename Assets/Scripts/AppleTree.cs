using UnityEngine;
using System.Collections;

public class AppleTree : MonoBehaviour {

    public GameObject applePrefab;
    public GameObject orangePrefab;
    public float speed = 1f;
    public float leftAndRightEdge = 10f;
    public float chanceToChangeDirection = .1f;
    public float secondsBetweenAppleDrops = 1f;
    public float secondsBetweenOrangeDrops = 4f;

	// Use this for initialization
	void Start () {
        InvokeRepeating("DropApple", 2f, secondsBetweenAppleDrops);
        InvokeRepeating("DropOrange", 3.5f, secondsBetweenOrangeDrops);
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = transform.position;
        pos.x += speed * Time.deltaTime;
        transform.position = pos;

        if (pos.x < -leftAndRightEdge)
        {
            speed = Mathf.Abs(speed);
        }
        else if (pos.x > leftAndRightEdge)
        {
            speed = -Mathf.Abs(speed);
        }
	}

    void FixedUpdate() {
        if (Random.value < chanceToChangeDirection)
        {
            speed = -speed;
        }
    }

    void DropApple() {
        var apple = Instantiate(applePrefab) as GameObject;
        apple.transform.position = transform.position;
    }

    void DropOrange()
    {
        var orange = Instantiate(orangePrefab) as GameObject;
        orange.transform.position = transform.position;
    }
}
