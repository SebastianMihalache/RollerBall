using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;

    private Rigidbody rb;
    private int count;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        count = 0;
        UpdateText();
        winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {

        float moveHorizontal = Input.acceleration.x;
        float moveVertical = Input.acceleration.y;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement.sqrMagnitude > 1)
            movement.Normalize();

        rb.AddForce(movement * speed);
		
	}

    void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("PickUp")) { 
        other.gameObject.SetActive(false);
            count = count + 1;
            UpdateText();
            
        }

    }

    void UpdateText() { 
    countText.text = "Count: " + count.ToString();
        if (count >= 7) {
            winText.text = "YOU WIN!";
        }
    }
}
