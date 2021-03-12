using System.Collections.Generic;

using UnityEngine;
using UnityEngine.UI;

public class SelectionBox_2D_2D_Example : MonoBehaviour
{
    [SerializeField] SelectionBox_2D_2D selectionBox;
    [SerializeField] float rayCastDist = 100;

    [SerializeField] List<GameObject> SelectableGO;

    List<GameObject> highlightedObjects = new List<GameObject>();
    void Awake()
    {
        selectionBox.OnSelectionBoxRelease = () => 
        {
            ChangeColor(highlightedObjects,Color.white);
            highlightedObjects.Clear();
        };
        selectionBox.OnSelectionBoxSelectObjects = (List<GameObject> SelectedObjects) => 
        {
            ChangeColor(highlightedObjects, Color.white);
            highlightedObjects.Clear();

            highlightedObjects.AddRange(SelectedObjects);

            ChangeColor(highlightedObjects, Color.blue);

            print($"You have selected {SelectedObjects.Count} Objects");
        };
        selectionBox.OnSelectionPointObjectSelect = (GameObject SelectedObject) => 
        {
            highlightedObjects.Add(SelectedObject);

            ChangeColor(highlightedObjects, Color.blue);

            print(SelectedObject.name);
        };

        List<GameObject> selectables = new List<GameObject>();
        selectionBox.SetSelectableObjects(SelectableGO.ToArray());
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            selectionBox.StartSelectionBox(Input.mousePosition, rayCastDist);
        }
        else if (Input.GetMouseButton(0))
        {
            selectionBox.UpdateSelectionBox(Input.mousePosition);
        }
        else if(Input.GetMouseButtonUp(0))
        {
            selectionBox.ReleaseSelectionBox();
        }
    }
    void ChangeColor(List<GameObject> gos, Color color)
    {
        foreach(GameObject go in gos)
        {
            MeshRenderer meshRenderer = go.GetComponent<MeshRenderer>();
            if (meshRenderer)
            {
                meshRenderer.material.color = color;
            }
            else
            {
                Image img = go.GetComponent<Image>();
                if(img) img.color = color;
            }
        }
    }
}
