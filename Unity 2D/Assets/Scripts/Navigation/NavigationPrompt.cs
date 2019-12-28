using Navigation;
using UnityEngine;

public class NavigationPrompt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (NavigationManager.CanNavigate(this.tag))
        {
            Debug.Log("Attempting to exit via "+tag);
            NavigationManager.NavigateTo(this.tag);
        }
    }
}
