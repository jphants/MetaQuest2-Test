using UnityEngine;
using TMPro; // Import TextMeshPro namespace

public class MessageReceiver : MonoBehaviour
{
    public TextMeshProUGUI textproLeft;  // Reference to TextMeshPro for left hand
    public TextMeshProUGUI textproRight; // Reference to TextMeshPro for right hand

    private int leftState;
    private int rightState;

    // Define hand states
    private bool isLeftNone => leftState == 0;
    private bool isLeftFist => leftState == 1;
    private bool isLeftThumbsUp => leftState == 2;

    private bool isRightNone => rightState == 0;
    private bool isRightFist => rightState == 1;
    private bool isRightThumbsUp => rightState == 2;

    void Start()
    {
        Debug.Log("MessageReceiver started");
    }

    void Update()
    {
        UpdateText();
    }

    public void SetLeftState(int state)
    {
        leftState = state;
        Debug.Log("LeftStateChange");
    }

    public void SetRightState(int state)
    {
        rightState = state;
        Debug.Log("RightStateChange");
    }

    private void UpdateText()
    {
        if (textproLeft != null)
        {
            if (isLeftNone) textproLeft.text = "Left Hand: None";
            else if (isLeftFist) textproLeft.text = "Left Hand: Fist";
            else if (isLeftThumbsUp) textproLeft.text = "Left Hand: Thumbs Up";
            else textproLeft.text = "Left Hand: Unknown";
        }

        if (textproRight != null)
        {
            if (isRightNone) textproRight.text = "Right Hand: None";
            else if (isRightFist) textproRight.text = "Right Hand: Fist";
            else if (isRightThumbsUp) textproRight.text = "Right Hand: Thumbs Up";
            else textproRight.text = "Right Hand: Unknown";
        }
    }
}
