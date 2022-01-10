using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    [SerializeField] private string selectableTag = "Selectable";


    private Transform _selection;

    private void Update()
    {
        if (_selection != null)
        {
            var outline = _selection.GetComponent<Outline>();
            if (outline != null) outline.OutlineWidth = 0;
        }

        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit))
        {
             _selection = hit.transform;
            if (_selection.CompareTag(selectableTag))
            {
                var outline = _selection.GetComponent<Outline>();
                if (outline != null) outline.OutlineWidth = 10;
            }

        }
        


    }
}