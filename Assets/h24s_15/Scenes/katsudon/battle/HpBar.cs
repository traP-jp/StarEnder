using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UI使うときは忘れずに。
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{

    //Sliderを入れる
    public Slider slider;

    //ColliderオブジェクトのIsTriggerにチェック入れること。
    public void HPDown(int maxHp,int currentHp,int downHP)
    {
            //ダメージは1～100の中でランダムに決める。
        Debug.Log("damage : " + downHP);

            //現在のHPからダメージを引く
        Debug.Log("After currentHp : " + currentHp);

            //最大HPにおける現在のHPをSliderに反映。
            //int同士の割り算は小数点以下は0になるので、
            //(float)をつけてfloatの変数として振舞わせる。
         slider.value = (float)currentHp / (float)maxHp; ;
        Debug.Log("slider.value : " + slider.value);
    }
}