using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class TextAnimator : MonoBehaviour
{
    public float moveDistance = 2f; // Distance to move the text
    public float animationDuration = 1f; // Duration of the animation

    private Image textComponent;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float animationTimer = 0f;

    private void Start()
    {
        textComponent = GetComponent<Image>();
        initialPosition = transform.position;
        targetPosition = initialPosition + Vector3.up * moveDistance;
    }

    private void Update()
    {
        animationTimer += Time.deltaTime;

        if (animationTimer <= animationDuration)
        {
            float t = animationTimer / animationDuration;
            transform.position = Vector3.Lerp(initialPosition, targetPosition, t);
        }
        else
        {
            transform.position = targetPosition;

            if (this.gameObject != null)
                Destroy(this.gameObject);
        }
    }
}
