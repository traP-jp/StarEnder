using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Core.Rendering;



public class StageSelectionManager : MonoBehaviour
{
    [SerializeField] private List<StageUI> _stageDisplayManagers;

    [Header("Node Connection Line")]
    [SerializeField] private GameObject _lineRenderer2D;
    private LineRenderer2D _lineRenderer;
    
    private void Start()
    {
        DisplayStageSelection(ProgressManager.currentStage);
    }

    IEnumerator AnimatedLine()
    {
        int startLoop = (int)_lineRenderer.DottedLineLength()*2; //it just works よくわからいんけどこれでループする
        int i = startLoop;
        do{
            if(i == 0) i = startLoop;
            _lineRenderer.SetDottedLineOffset(i--);
            yield return new WaitForSeconds(0.1f);
        } while(true);

    }

    void DisplayStageSelection(int currentStageIndex)
    {
        for(int i = 0; i < currentStageIndex; i++)
        {
            _stageDisplayManagers[i].SetStateCleared();
        }

        if(currentStageIndex >= 0)
        {
            _stageDisplayManagers[currentStageIndex].SetStateCurrent();
            _lineRenderer = Instantiate(_lineRenderer2D).GetComponent<LineRenderer2D>(); 
            _lineRenderer.CurrentCamera = Camera.main;
            _lineRenderer.PointA = _stageDisplayManagers[currentStageIndex].transform.GetChild(0).position;

            _stageDisplayManagers[currentStageIndex+1].SetStateNext();
            _lineRenderer.GetComponent<LineRenderer2D>().PointB = _stageDisplayManagers[currentStageIndex+1].transform.GetChild(0).position;
        }
        
        if(_lineRenderer != null && _lineRenderer.DottedLineLength() < 9999)
        {
            StartCoroutine(AnimatedLine());    
        }

    }
    
}

