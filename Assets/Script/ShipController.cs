using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    [SerializeField] 
    Transform spawnPoint;
    float speed = 10f;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float move = Input.GetAxis("Horizontal");
     //   rb.velocity = Vector2.right * (move * speed);
     
        rb.rotation += -1 * move;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = Instantiate(Resources.Load("bullet"),spawnPoint.position,transform.rotation) as GameObject;
            bullet.SetActive(true);

            GameObject scoreObj = GameObject.Find("ScoreObject");
            if (scoreObj != null)
            {
                ScoreController scoreC = scoreObj.GetComponent<ScoreController>();
                scoreC.score++;
                if (scoreC.score > 2)
                {
                    SceneManager.LoadScene("ScoreScene");

                }
            }
        } } }