using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject leftPad;
    [SerializeField] GameObject rightPad;

    [SerializeField] float resetPosition = 0f;
    [SerializeField] float pressedPosition = 45f;
    [SerializeField] float hitStrength = 10000f;
    [SerializeField] float fipperDamper = 150f;
    [SerializeField] HingeJoint leftHinge;
    [SerializeField] HingeJoint rightHinge;

    

    void Start(){
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = fipperDamper;
        leftHinge.spring = spring;
        rightHinge.spring = spring;
    }
    public void OnLeftPadPress(InputAction.CallbackContext context)
    {

        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = fipperDamper;
        if(context.performed) spring.targetPosition = pressedPosition;
        if(context.canceled) spring.targetPosition = resetPosition;
        leftHinge.spring = spring;
        leftHinge.useLimits = true;
    }

    public void OnRightPadPress(InputAction.CallbackContext context)
    {
        JointSpring spring = new JointSpring();
        spring.spring = hitStrength;
        spring.damper = fipperDamper;
        if(context.performed) spring.targetPosition = -pressedPosition;
        if(context.canceled) spring.targetPosition = resetPosition;

        rightHinge.spring = spring;
        rightHinge.useLimits = true;

    }

    public void ExitGame(InputAction.CallbackContext context)
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();


    }
}
