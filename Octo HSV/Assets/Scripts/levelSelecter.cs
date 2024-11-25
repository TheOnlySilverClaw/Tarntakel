using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelecter : MonoBehaviour
{
    //Levels start from 2(currently 2 is Masterscene, so level 1 will have _sceneIndex = 2)
    [SerializeField]
    private GameObject SceneManager;
    [SerializeField]
    private int _sceneIndex;
    [SerializeField]
    private GameObject levelSelectMenu;
   
   public void openLevelMenu(){
    //temporary
        levelSelectMenu.SetActive(true);
   }
   public void closeLevelMenu(){
    //temporary
        levelSelectMenu.SetActive(false);
   }
   public void selectlevel(){
        SceneManager.GetComponent<SceneLoader>().selectLevel(_sceneIndex);
        closeLevelMenu();
   }
}
