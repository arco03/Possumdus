using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Lever : MonoBehaviour, IDragHandler, IEndDragHandler
{
    [Header("Lever Settings")]
    public LeverMethods leverTask; // Referencia al ScriptableObject.
    public RectTransform leverTransform; // La parte visual de la palanca.
    public Vector2 startPosition; // Posici�n inicial de la palanca.
    public Vector2 finalPosition; // Posici�n final de la palanca.
    public float tolerance = 5f; // Margen de error para considerar que la tarea est� completada.

    private void Start()
    {
      if (leverTransform != null)
      leverTransform.anchoredPosition = startPosition;
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Arrastra la palanca hacia abajo.
        Vector2 newPosition = leverTransform.anchoredPosition + eventData.delta;
        newPosition.y = Mathf.Clamp(newPosition.y, finalPosition.y, startPosition.y);
        leverTransform.anchoredPosition = new Vector2(startPosition.x, newPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Verifica si la palanca est� en la posici�n final.
        if (Vector2.Distance(leverTransform.anchoredPosition, finalPosition) <= tolerance)
        {
            leverTask.CompleteLeverTask();
        }
    }
}
