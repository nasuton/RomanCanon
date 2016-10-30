using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap;
using Leap.Unity;

public class CreateAim : MonoBehaviour
{
    Controller controller;


    public GameObject[] FingerObjects;


    void Start()
    {
        controller = new Controller();
    }

    void OnApplicationQuit()
    {
        if (controller != null)
        {
            controller.StopConnection();
            controller.Dispose();
            controller = null;
        }
    }


    void Update()
    {
        Frame frame = controller.Frame();
        List<Hand> hands = frame.Hands;

        if (0 < hands.Count)
        {
            Hand firstHand = hands[0];
            List<Finger> fingers = firstHand.Fingers;

            for (int ii = 0; ii < fingers.Count; ++ii)
            {
                Finger finger = fingers[ii];
                var fingerObj = FingerObjects[ii];
                Vector v = finger.TipPosition;

                fingerObj.transform.position = UnityVectorExtension.ToVector3(v) / 10;
            }
        }
    }
}