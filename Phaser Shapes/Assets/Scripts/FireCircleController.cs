using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCircleController : MonoBehaviour
{

    public Transform MaskTransform;
    public float radiusDelta = 1f;
    public float initialRadius = 60f;
    float currentRadius;

    private void Awake() {

        currentRadius = initialRadius;

    }

    void Update()
    {
        if (!GameController.gc.gameOver) {

            float newRadius = currentRadius - (radiusDelta * Time.deltaTime);

            if (newRadius < 5f) {
                currentRadius = 5f;
            }
            else {
                currentRadius = newRadius;
            }

            MaskTransform.localScale = new Vector3(currentRadius, currentRadius, 1f);
        }

    }

    public void Restart() {

        currentRadius = initialRadius;
        MaskTransform.localScale = new Vector3(initialRadius, initialRadius, 1f);

    }

}
