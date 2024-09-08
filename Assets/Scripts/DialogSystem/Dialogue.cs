using UnityEngine;

[CreateAssetMenu(fileName = "Dialogue", menuName = "Dialogue/Dialogue", order = 0)]
public class Dialogue : ScriptableObject {
    public DialogueLine[] content;
}