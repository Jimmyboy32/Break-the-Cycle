using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways] // Always execute script even when in editing mode
public class CoordinateLabeler : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.gray;

    TextMeshPro label; // variable label of type TMP
    Vector2Int coordinates = new Vector2Int(); // Vector 2 Int for coordinates
    Waypoint waypoint;

    // Awake is first in order of execution
    void Awake()
    {
        label = GetComponent<TextMeshPro>();
        label.enabled = false; // We want coordinates to be disabled on Awake

        waypoint = GetComponentInParent<Waypoint>();
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
        ColorCoordinates();
        ToggleLabels();
    }

    // Toggle coodinate labels on/off for debugging
    void ToggleLabels()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
        }
    }
    // Change label color depending on if object can be placed on grid location or not
    void ColorCoordinates()
    {
        if (waypoint.IsPlaceable)
        {
            label.color = defaultColor;
        }
        else
        {
            label.color = blockedColor;
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
