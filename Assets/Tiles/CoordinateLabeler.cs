using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] // Always execute script even when in editing mode
public class CoordinateLabeler : MonoBehaviour
{
    TextMeshPro label; // variable label of type TMP
    Vector2Int coordinates = new Vector2Int(); // Vector 2 Int for coordinates

    // Awake is first in order of execution
    void Awake()
    {
        label = GetComponent<TextMeshPro>(); 
        DisplayCoordinates();
    }

    void Update()
    {
        // When app is not active call the following methods
        if (!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }
    }

    void DisplayCoordinates()
    {
        // Rounding of float cordinates to int value + adapt to snap settings
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / UnityEditor.EditorSnapSettings.move.x);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / UnityEditor.EditorSnapSettings.move.z);

        label.text = coordinates.x + "," + coordinates.y;
    } 

    void UpdateObjectName()
    {
        // Displayed coordinates update with the position on the grid
        transform.parent.name = coordinates.ToString();
    }
}
