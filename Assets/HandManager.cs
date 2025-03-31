using UnityEngine;
using TMPro;
using UnityEngine.XR;

public class HandManager : MonoBehaviour
{
    // Hand states (0: none, 1: fist)
    public int leftHandState = 0;
    public int rightHandState = 0;

    // Debugging UI (assign in Inspector)
    public TextMeshProUGUI leftHandText;
    public TextMeshProUGUI rightHandText;

    void Update()
    {
        // Get hand devices dynamically
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);

        // Update hand states
        leftHandState = DetectFist(leftHandDevice);
        rightHandState = DetectFist(rightHandDevice);

        // Update UI debug text
        leftHandText.text = $"Left Hand: {GetStateText(leftHandState)}";
        rightHandText.text = $"Right Hand: {GetStateText(rightHandState)}";
    }

    int DetectFist(InputDevice hand)
    {
        if (!hand.isValid) return 0; // No hand detected

        // If grip is pressed, set fist state
        if (hand.TryGetFeatureValue(CommonUsages.grip, out float gripValue) && gripValue > 0.5f)
            return 1;

        return 0; // Default: open hand
    }

    string GetStateText(int state)
    {
        return state == 1 ? "Fist ✊" : "Open Hand ✋";
    }
}
