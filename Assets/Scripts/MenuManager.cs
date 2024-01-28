using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
   //  public Animator AN;
   public GameObject ShopPanel;
   public GameObject SettingPanel;

   public void ShopOpenPanel()
   {
      gameObject.SetActive(false);
      ShopPanel.SetActive(true);
   }

   public void ShopOpenButton()
   {
      //  AN.Play("ExitMenu");
   }

   public void SettingOpenButton()
   {
     // AN.Play("OpenSettingforMenu");
   }

   public void SettingOpenPanel()
   {
      gameObject.SetActive(false);
      SettingPanel.SetActive(true);
   }
}
