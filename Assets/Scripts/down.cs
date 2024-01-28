using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class down : MonoBehaviour
{
    private float t1;
    private float t1max;
    private float t2;

    private bool _tap = false;
    private bool t2bool = false;

    public GameObject panel;
    public GameObject boom;
    public GameObject gameover;
    public GameObject partical;
    public GameObject poz;

    private Vector3 position;

    public  AudioSource hit;
    public static AudioSource hit2;
    private void Start()
    {
        t1max = Random.Range(20, 30);
        hit2 = hit;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject);
            JoysticController.hp--;
        }
        if (collision.gameObject.CompareTag("vase"))
        {
            Destroy(collision.gameObject);
        }
    }
    
    private void DeleteObjects()
    {
        GameObject[] objectsToDelete = GameObject.FindGameObjectsWithTag("enemy"); 
        
        foreach (GameObject obj in objectsToDelete)
        {
            Destroy(obj, 2f); 
        }
        GameObject[] objectsDelete = GameObject.FindGameObjectsWithTag("vase");

        foreach (GameObject obj in objectsToDelete)
        {
            Destroy(obj, 2f);
        }
    }

    public void Spawner()
    {
        Instantiate(partical, position, Quaternion.identity);
    }
    private void Update()
    {
        position = poz.transform.position;
        t1 = t1 + Time.deltaTime;
        if (t1 >= t1max)
        {
            t1 = 0;
            t1max = Random.Range(20, 30);
            
            
            t2bool = true;
        }
        
        if (t2bool)
        {
            boom.SetActive(true);
            t2 = t2 + Time.deltaTime;

            if (t2 >= 5)
            {
                t2 = 0;
                boom.SetActive(false);
                t2bool = false;
                t1 = 0;
                JoysticController.hp--;
               

            }
            

            if (_tap)
            {
                boom.SetActive(false);
                DeleteObjects();
                _tap = false;
                t2bool = false;
                t1 = 0;
                t2 = 0;
                Spawner();
            }
        }
        if (JoysticController.hp == 0)
        {
            Time.timeScale = 0;
            gameover.gameObject.SetActive(true);
            panel.SetActive(false);
        }
    }

   

    public void Tap()
    {
        _tap = true;
    }

    //public void Restart()
    //{
    //    SceneManager.LoadScene("SampleScene");
    //    Time.timeScale = 1;
    // }
}
