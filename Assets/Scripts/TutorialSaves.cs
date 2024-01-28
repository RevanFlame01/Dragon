using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSaves : MonoBehaviour
{
   public int Tutorial;
   private void Start()
   {
      Tutorial = PlayerPrefs.GetInt("Tutorial", Tutorial);
   }

   private void Update()
   {
       Tutorial = PlayerPrefs.GetInt("Tutorial", Tutorial);
   }
}
