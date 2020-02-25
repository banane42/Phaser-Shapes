using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    public GameObject[] shapePrefabs;
    public Text Title;

    int titleResizeDelta = 1;
    float spawnTime = 1f;
    float ellapsedTime = 0f;

    private void Update() {

        ellapsedTime += Time.deltaTime;
        ResizeTitle();

        if (ellapsedTime >= spawnTime) {

            YeetShape();
            ellapsedTime = 0f;
            spawnTime = Random.value * 4f;

        }

    }

    void ResizeTitle() {

        if (Title.fontSize > 55) {
            titleResizeDelta = -1;
        }
        else if (Title.fontSize < 30) {
            titleResizeDelta = 1;
        }

        Title.fontSize += titleResizeDelta;

    }

    void YeetShape() {

        int shapeIndex = Random.Range(0, shapePrefabs.Length);

        float xPos = Random.Range(0f, Camera.main.pixelWidth);
        float yPos = Random.Range(0f, Camera.main.pixelHeight);

        Vector3 yeetVector = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 1f);

        Vector3 locationVector = Camera.main.ScreenToWorldPoint(new Vector3(xPos, yPos, 10f));

        Vector3 spawnPoint = locationVector + (yeetVector.normalized * 25f);

        Instantiate(shapePrefabs[shapeIndex], spawnPoint, Quaternion.identity).GetComponent<MenuShapeController>().Instantiate(spawnPoint);
                

    }

}
