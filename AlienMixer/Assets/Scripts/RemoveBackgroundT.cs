using UnityEngine;
using UnityEngine.UI;

public class RemoveBackgroundT : MonoBehaviour
{
    private Text textComponent;

    void Start()
    {
        textComponent = GetComponent<Text>();
        textComponent.supportRichText = false;
    }
}