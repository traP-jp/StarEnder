using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class StageUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private Image _currentIndicator;
    [SerializeField] private Image _clearedIndicator;

    [SerializeField] private Material _hoverEffectMaterial;

    bool _isSelectable = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if(_hoverEffectMaterial != null && _isSelectable)
        {
            GetComponent<Image>().material = _hoverEffectMaterial; 
        }
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        if( _isSelectable)
        {
            GetComponent<Image>().material = null; 
        }
    }

    public void SetStateCleared()
    {
        _clearedIndicator.enabled = true;
    }

    public void SetStateCurrent()
    {
        _currentIndicator.enabled = true;
    }

    public void SetStateNext()
    {
        GetComponent<Button>().enabled = true;
        _isSelectable = true;
    }

    public void EnterBattleStage()
    {
        ProgressManager.toBattle();
    } 

}
