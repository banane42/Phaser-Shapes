using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuShapeController : MonoBehaviour
{

    SpriteRenderer sr;
    float lifetime = 0f;
    float rotationAngle = 0f;
    Vector3 moveVector = Vector3.one;

    private void Awake() {

        sr = GetComponent<SpriteRenderer>();

        sr.color = new Color(Random.value * 255, Random.value * 255, Random.value * 255);

        rotationAngle = Random.value * 10f;

    }

    private void Update() {

        lifetime += Time.deltaTime;

        if (lifetime > 10f) {
            //Destroy(gameObject);
        }

        transform.Rotate(new Vector3(0f, 0f, rotationAngle), Space.Self);
        //transform.Translate(moveVector, Space.World);

    }

    public void Instantiate(Vector3 mv) {

        moveVector = mv;

    }

}
