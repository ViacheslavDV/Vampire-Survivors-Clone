using UnityEngine;

public class Obtain : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Character character = collision.transform.parent.GetComponent<Character>();
        if (character != null)
        {
            GetComponent<IObtainable>().ObtainItem(character);
            Destroy(gameObject);
        }
    }
}
