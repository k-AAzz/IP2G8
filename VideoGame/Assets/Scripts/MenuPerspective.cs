using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuPerspective : MonoBehaviour
{
    [Header("Editable Variables")]
    public float maxShiftDistance = 10f;
    public RectTransform[] objects;

    [Header("Private Variables")]
    private Vector3 initialObjectPosition;
    private Vector3 lastMousePosition;

    void Start()
    {
        //Set the inital values of the object array's and the mouse position
        initialObjectPosition = objects[0].anchoredPosition;
        lastMousePosition = Input.mousePosition;
    }

    void Update()
    {
        //Get the live mouse position
        Vector3 mousePos = Input.mousePosition;

        //Calculate the position based on the position of the mouse within the bounds of the screen
        float normalizedX = (mousePos.x / Screen.width) * 2 - 1;
        float normalizedY = (mousePos.y / Screen.height) * 2 - 1;

        //Calculate the shift distances based on the mouse positon and negate them to invert the effect of the shift
        float shiftX = -normalizedX * maxShiftDistance;
        float shiftY = -normalizedY * maxShiftDistance;

        //For each object in the array apply the perspective shift
        foreach (RectTransform uiObjects in objects)
        {
            if (uiObjects != null)
            {
                Vector3 newPosition = initialObjectPosition + new Vector3(Mathf.Clamp(shiftX, -maxShiftDistance, maxShiftDistance),Mathf.Clamp(shiftY, -maxShiftDistance, maxShiftDistance),0f);
                uiObjects.anchoredPosition = newPosition;
            }
        }

        // Update the last mouse position
        lastMousePosition = mousePos;
    }
}