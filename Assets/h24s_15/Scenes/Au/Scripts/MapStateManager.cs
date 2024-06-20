using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapStateManager : MonoBehaviour
{
    [SerializeField] private List<Image> _mapStates;
    [SerializeField] private int _stageBetweenMapState = 3;
    //[SerializeField] private int _debugCurrentStage = 0;

    void Awake()
    {      
        UpdateState();
        //_debugCurrentStage = ProgressManager.currentStage;
    }

    /* void Update()
    {
        ProgressManager.setCurrentStage(_debugCurrentStage);
        UpdateState();
    } */

    void UpdateState()
    {
        int mapStateFromCurrentStage = ProgressManager.currentStage/_stageBetweenMapState; 
        //get appropriate map state
        /**in this case  (mapState = 0 when currentStage = 0, 1, 2
                          mapState = 1 when currentStage = 3, 4, 5
                          mapState = 2 when currentStage = 6, 7) **/
        int currentState = mapStateFromCurrentStage < _mapStates.Count-1? mapStateFromCurrentStage : _mapStates.Count-1; 
        //if currentState is more than available mapStates then assign it to the last one
        foreach(Image i in _mapStates)
        {
            i.enabled = false;
        }
        if(currentState >= 0) _mapStates[currentState].enabled = true;
    }

}
