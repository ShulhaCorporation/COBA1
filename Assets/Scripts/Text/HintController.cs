   using UnityEngine;

public class HintController : MonoBehaviour {
    
    [SerializeField]
    private Hint hint;
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hint.Show();
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player")
        {
            hint.Hide();
        }
    }

}