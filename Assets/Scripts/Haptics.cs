using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(SteamVR_TrackedObject))]
public class Haptics : MonoBehaviour {
    
    public enum Hand
    {
        Left,
        Right
    }

    public Hand hand;

    private static int leftIndex = -1;
    private static int rightIndex = -1;

    private SteamVR_TrackedObject tracker;
    private bool isRegistered = false;

    // Use this for initialization
    void Start () {
        tracker = GetComponent<SteamVR_TrackedObject>();

    }
	
	// Update is called once per frame
	void Update () {

        TryRegister();
	}

    private void TryRegister()
    {
        if (isRegistered) return;
        if (hand == Hand.Left)
        {
            leftIndex = (int)tracker.index;
            isRegistered = true;
        }
        else if (hand == Hand.Right)
        {
            rightIndex = (int)tracker.index;
            isRegistered = false;
        }
    }

    public static void ProvideHaptics(Hand hand, ushort hap = 500)
    {
        if(hand == Hand.Left && leftIndex != -1)
        {
            SteamVR_Controller.Input(leftIndex).TriggerHapticPulse(hap);
        } else if (hand == Hand.Right && rightIndex != -1)
        {
            SteamVR_Controller.Input(rightIndex).TriggerHapticPulse(hap);
        }

    }
}
