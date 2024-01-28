using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class item : MonoBehaviour
{
    public GameObject _item;
    public int _isItem;

    private void Start()
    {
        _isItem = PlayerPrefs.GetInt("item");
    }

    private void Update()
    {
        _isItem = PlayerPrefs.GetInt("item");
        if (_isItem == 1)
        {
            _item.SetActive(true);
        }
        
    }
    public void Tap()
    {
        JoysticController.hp+=1;
        _item.SetActive(false);
        PlayerPrefs.SetInt("item", 0);
    }
}
