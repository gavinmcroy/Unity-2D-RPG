using UnityEngine;

public class NavigationPrompt : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Borders"))
        {
            Debug.Log("Leaving Town");
        }
    }
}
