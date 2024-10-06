using UnityEngine;

public class RideSelector : MonoBehaviour
{
    // Material for selected object
    public Material selectedMaterial;

    private GameObject selectedObject = null;      // Currently selected object
    private Material[] originalMaterials = null;   // Store the original materials for all parts of the selected object

    void Update()
    {
        // Check for mouse click
        if (Input.GetMouseButtonDown(0))
        {
            SelectObject();
        }

        // Deselect the current object if the user presses "Escape"
        if (Input.GetKeyDown(KeyCode.Escape) && selectedObject != null)
        {
            DeselectObject();
        }
    }

    // Raycast to select object
    void SelectObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits any object with a collider
        if (Physics.Raycast(ray, out hit))
        {
            GameObject hitObject = hit.transform.gameObject;

            // If we clicked on a new object, select it
            if (selectedObject != hitObject)
            {
                // Deselect the previously selected object (if any)
                if (selectedObject != null)
                {
                    DeselectObject();
                }

                // Select the new object
                selectedObject = hitObject;

                // Check if the selected object is the platform named "Platform"
                if (selectedObject.name == "Platform")
                {
                    // Only apply material to the platform itself
                    Renderer platformRenderer = selectedObject.GetComponent<Renderer>();

                    if (platformRenderer != null)
                    {
                        originalMaterials = new Material[1];
                        originalMaterials[0] = platformRenderer.material;  // Store original material
                        platformRenderer.material = selectedMaterial;      // Apply selected material
                    }
                }
                else
                {
                    // Apply the selected material to all parts of the object (for non-platform objects)
                    Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();
                    originalMaterials = new Material[renderers.Length];

                    // Store the original materials for each part and apply the selected material
                    for (int i = 0; i < renderers.Length; i++)
                    {
                        originalMaterials[i] = renderers[i].material;  // Store original material
                        renderers[i].material = selectedMaterial;      // Apply selected material
                    }
                }
            }
        }
    }

    // Deselect the current object
    void DeselectObject()
    {
        if (selectedObject != null)
        {
            // Check if the selected object is the platform named "Platform"
            if (selectedObject.name == "Platform")
            {
                // Restore the platform's original material
                Renderer platformRenderer = selectedObject.GetComponent<Renderer>();

                if (platformRenderer != null && originalMaterials.Length > 0)
                {
                    platformRenderer.material = originalMaterials[0];  // Reapply the original material for the platform
                }
            }
            else
            {
                // Restore the original materials to all parts of the object (non-platform objects)
                Renderer[] renderers = selectedObject.GetComponentsInChildren<Renderer>();

                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].material = originalMaterials[i];  // Reapply the original material
                }
            }

            // Clear the selected object
            selectedObject = null;
        }
    }
}
