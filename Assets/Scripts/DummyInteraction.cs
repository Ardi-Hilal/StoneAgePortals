using UnityEngine;

public class DummyInteraction : Interactable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public override void Interact() {
        Debug.Log("Berhasil interact");
    }
}
