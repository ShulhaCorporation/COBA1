using UnityEngine;

[CreateAssetMenu(fileName = "DialogueLine", menuName = "Dialogue/DialogueLine", order = 0)]
public class DialogueLine : ScriptableObject {
    public string speakerName;
    public string line;
}