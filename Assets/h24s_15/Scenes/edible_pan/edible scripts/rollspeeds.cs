using System;
using UnityEngine;

public class rollspeeds : MonoBehaviour {
    public Animator animator;
    public float animationSpeed = 1.0f; // アニメーションの速度

    private void Awake() {
        animator.speed = animationSpeed;
    }
}
