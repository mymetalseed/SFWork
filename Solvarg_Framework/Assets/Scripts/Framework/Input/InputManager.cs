using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameInput;
using UnityEngine.InputSystem;

public enum InputEvents
{
    None = 0b0000,
    Moving = 0b0001,
    Attack = 0b0010,
    Jump = 0b0100,
    Jumping = 0b1000,
}

public static class InputData
{
    public static InputEvents inputEvents { get; set; } = InputEvents.None;
    public static Vector2 axisValue { get; set; } = Vector2.zero;

    #region 功能性按键
    public static bool Confirm = false;
    public static bool SwitchWeapon = false;
    
    #endregion

    public static bool HasEvent(InputEvents e,bool fullMatch = false) 
    {
        return fullMatch ? ((inputEvents & e) == inputEvents) : ((inputEvents & e) != 0);
    }

    public static void Clear()
    {
        inputEvents = InputEvents.None;
        axisValue = Vector2.zero;
    }
}

public class InputManager : Singleton<InputManager>
{
    #region 参数
    public GameInput input;
    protected float logicTimer = 0f;
    protected const float logicDeltaTime = 1 / 30f;
    #endregion

    #region 功能函数
    public bool CheckInputEvents(InputEvents eventType)
    {
        if (eventType == InputEvents.Moving)
        {

        }else if(eventType == InputEvents.Jump)
        {

        }
        return false;
    }

    private void UpdateInput()
    {
        PlayerActions player = input.Player;
        Vector2 move = player.Move.ReadValue<Vector2>();

        InputData.axisValue = move;

        if (player.Move.phase == InputActionPhase.Started)
        {
            InputData.inputEvents |= InputEvents.Moving;
        }

        if (player.Attack.triggered)
        {
            InputData.inputEvents |= InputEvents.Attack;
        }

        if (player.Jump.triggered)
        {
            InputData.inputEvents |= InputEvents.Jump;
        }

        if (player.Jump.phase == InputActionPhase.Started)
        {
            InputData.inputEvents |= InputEvents.Jumping;
        }

        InputData.Confirm = player.Confirm.triggered;
        InputData.SwitchWeapon = player.SwitchWeapon.triggered;
    }

    #endregion

    #region Unity Callback
    public override void Awake()
    {
        base.Awake();
        input = new GameInput();
        input.Enable();

        Physics.autoSimulation = false;
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
        logicTimer += Time.deltaTime;
        if (logicTimer >= logicDeltaTime)
        {
            logicTimer -= logicDeltaTime;

            //更新物理
            Physics.Simulate(logicDeltaTime);

            //清理输入
            InputData.Clear();
        }

    }

    public override void LateUpdate()
    {
        base.LateUpdate();
    }

    public override void OnDestroy()
    {
        base.OnDestroy();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnGUI()
    {
        base.OnGUI();
    }

    public override void OnRelease()
    {
        base.OnRelease();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void Update(float elapseSeconds, float realElapseSeconds)
    {
        base.Update(elapseSeconds, realElapseSeconds);
        UpdateInput();
    }

    #endregion
}
