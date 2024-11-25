using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class levelSelecter : MonoBehaviour
{
    //Levels start from 2(currently 2 is Masterscene, so level 1 will have _sceneIndex = 2)
    [SerializeField] private GameObject SceneManager;
    [SerializeField] private int _sceneIndex;
    [SerializeField] private GameObject levelSelectMenu;
    [SerializeField] private GameObject Buttons;
    [SerializeField] private Camera mainCamera;
    private bool camIsMoving = false;
    private Vector3 camGoalPos;
    private float camGoalZoom;
    public float speed;
   
   void Update(){
    if(camIsMoving){
        float multiplier = 1;
        if(mainCamera.orthographicSize < camGoalZoom) multiplier = 1;
        else if(mainCamera.orthographicSize > camGoalZoom) multiplier = -1;
        else if(mainCamera.orthographicSize >= camGoalZoom +0.2f || mainCamera.orthographicSize <= camGoalZoom - 0.2f) camIsMoving = false;
        
        Vector2 helpVector = new Vector2 (mainCamera.orthographicSize, 0);
        helpVector = Vector2.Lerp(helpVector, new Vector2(camGoalZoom, 0), speed);
        mainCamera.orthographicSize = helpVector.x;
        mainCamera.transform.position = Vector3.MoveTowards(mainCamera.transform.position, camGoalPos, speed);
    }

   }
   public void openLevelMenu(){
    //temporary
        levelSelectMenu.SetActive(true);
        Buttons.SetActive(false);

        //actual camera movement
        camIsMoving = true;
        camGoalZoom = 1.2f;
        camGoalPos = new Vector3 (1.2f, -1.2f, -10f);

   }
   public void closeLevelMenu(){
    //temporary
        levelSelectMenu.SetActive(false);
        Buttons.SetActive(true);

        //actual camera movement
        camIsMoving = true;
        camGoalZoom = 5f;
        camGoalPos = new Vector3 (0f, 0f, -10f);
   }
   public void selectlevel(){
        SceneManager.GetComponent<SceneLoader>().selectLevel(_sceneIndex);
        closeLevelMenu();
   }
}
