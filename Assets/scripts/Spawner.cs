using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objectToInstantiate;
    public TextMeshProUGUI timerText;
    private Camera cam;
    private float speed = 4f;
    private float spawnInterval = 0.5f;
    private bool on = false;

    private float intervalTimer = 0f;
    private float timer;
    private Vector3 position;
    private bool left = true;
    private int generationType;

    void Start(){
        
        cam = FindObjectOfType<Camera>();
    }

    void Update()
    {
        intervalTimer += Time.deltaTime;
        if(on){
            updateTimer();
            if (intervalTimer >= spawnInterval){
                SpawnBox();
                if(generationType == 0)
                {
                    nextPositionAlternate();
                }else if(generationType == 1)
                {
                    nextPositionRandom();
                }
                intervalTimer = 0f;
            }
        }
    }

    void SpawnBox()
    {
        GameObject newBox = Instantiate(objectToInstantiate, position, Quaternion.identity);
        CubeMovement mov = newBox.GetComponent<CubeMovement>();
        mov.setSpeed(speed);
    }

    void nextPositionAlternate(){
        if(left){
            position += new Vector3(0.25f,0,0);
        }else{
            position -= new Vector3(0.25f,0,0);
        }
        left = !left;
    }

    void nextPositionRandom()
    {
        float randomValue = Random.Range(0f, 1f);
        if(randomValue > 0.5f)
        {
            nextPositionAlternate();
        }
    }

    void updateTimer()
    {
        if (on)
        {
            timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(timer / 60f);
            int seconds = Mathf.FloorToInt(timer % 60f);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            if(timer <= 0f)
            {
                on = false;
                timerText.text = "00:00";
                GameObject[] objectsWithTag = GameObject.FindGameObjectsWithTag("cube");

                // Destroy each GameObject found
                foreach (GameObject obj in objectsWithTag)
                {
                    Destroy(obj);
                }
            }
        }
    }

    public void turnOn(float speed, float spawnInterval, float timer, int generationType)
    {
        this.speed = speed;
        this.spawnInterval = spawnInterval;
        this.timer = timer;
        this.generationType = generationType;
        this.on = true;
        Debug.Log(this.transform.position);
        Vector3 newPos = this.transform.position;
        newPos.y = cam.transform.position.y;
        this.transform.position = newPos;
        Debug.Log(this.transform.position);
        position = transform.position - new Vector3(0.25f, 0, 0);
    }

    public void turnOff(){
        this.on = false;
    }
}
