using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class ApplePicker : MonoBehaviour {

    public GameObject basketPrefab;
    public int numberOfBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

	// Use this for initialization
	void Start () {
        basketList = new List<GameObject>();
        for (var i = 0; i < numberOfBaskets; i++)
        {
            var basket = Instantiate(basketPrefab) as GameObject;
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            basket.transform.position = pos;

            basketList.Add(basket);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void AppleDestroyed() {
        var apples = GameObject.FindGameObjectsWithTag("Apple");
        foreach (var apple in apples) {
            Destroy(apple);
        }

        var index = basketList.Count - 1;
        var basketToDestroy = basketList[index];

        basketList.RemoveAt(index);
        Destroy(basketToDestroy);

        if (basketList.Count == 0)
        {
            SceneManager.LoadScene("_Scene_0");
        }
    }
}
