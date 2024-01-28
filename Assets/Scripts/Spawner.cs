using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemy;
    private int _enemy = 1;
    private Vector3 spawnPosition;

    private float t = 2f;
    private float hard;

    public GameObject GameOverPanel;
    public GameObject TutorialPanel;
    
    

    
    void Update()
    {
        if (GameOverPanel.activeSelf == false && TutorialPanel.activeSelf == false)
        {


            _enemy = Random.Range(1, _enemy);
            t -= 1f * Time.deltaTime;
            if (t <= 0)
            {
                _Spawner();
                t = 2f;
            }

            hard = hard + Time.deltaTime;
            if (hard >= 60)
            {
                _enemy++;
                hard = 0;
            }
        }
    }

    public void _Spawner()
    {
        if (GameOverPanel.activeSelf == false && TutorialPanel.activeSelf == false)
        {


            for (int i = 0; i < _enemy; i++)
            {
                spawnPosition = new Vector3(Random.Range(-2f, 2f), Random.Range(5.5f, 6.5f), transform.position.z);
                Instantiate(enemy[Random.Range(0, enemy.Length)], spawnPosition, Quaternion.identity);
            }
        }
    }
}
