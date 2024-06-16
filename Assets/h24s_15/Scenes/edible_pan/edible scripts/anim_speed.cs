using UnityEngine;

public class rollspeeds : MonoBehaviour
{
    public Animator animator;
    public float animationSpeed = 1.0f; // アニメーションの速度

    void Update()
    {
        // アニメーターの速度を設定する
        animator.speed = animationSpeed;
    }
}
