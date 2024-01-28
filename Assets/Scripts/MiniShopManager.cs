using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniShopManager : MonoBehaviour
{
   // public Animator AN;
    public GameObject MenuPanel;

    public void OpenMenuPanel()
    {
      //  AN.Play("ExitAnimation");
    }

    public void ExitShopPanel()
    {
        gameObject.SetActive(false);
        MenuPanel.SetActive(true);
    }
}
