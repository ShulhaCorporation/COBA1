using UnityEngine;

public class HintController : MonoBehaviour {
    
    [SerializeField]
    private Hint hint;
    private void OnTriggerEnter2D(Collider2D other) {
        hint.Show();
    }

    private void OnTriggerExit2D(Collider2D other) {
        hint.Hide();
    }

}