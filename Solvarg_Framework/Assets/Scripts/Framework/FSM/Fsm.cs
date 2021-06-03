using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fsm<T> : FsmBase,IFsm<T> where T:class
{
    private T m_Owner;

    private readonly Dictionary<Type, FsmState<T>> m_States;
    private Dictionary<string, Variable> m_Datas;
    private FsmState<T> m_CurrentState;
    private float m_CurrentStateTime;
    private bool m_IsDestroyed;

    /// <summary>
    /// 初始化有限状态机的新实例
    /// </summary>
    public Fsm()
    {
        m_Owner = null;
        m_States = new Dictionary<Type, FsmState<T>>();
        m_Datas = null;
        m_CurrentState = null;
        m_CurrentStateTime = 0f;
        m_IsDestroyed = true;

    }

    public T Owner => (m_Owner);

    /// <summary>
    /// 获取有限状态机持有者类型。
    /// </summary>
    public override Type OwnerType
    {
        get
        {
            return typeof(T);
        }
    }

    /// <summary>
    /// 获取有限状态机中状态的数量。
    /// </summary>
    public override int FsmStateCount
    {
        get
        {
            return m_States.Count;
        }
    }


    /// <summary>
    /// 获取有限状态机是否正在运行。
    /// </summary>
    public override bool IsRunning
    {
        get
        {
            return m_CurrentState != null;
        }
    }


    /// <summary>
    /// 获取有限状态机是否被销毁。
    /// </summary>
    public override bool IsDestroyed
    {
        get
        {
            return m_IsDestroyed;
        }
    }


    /// <summary>
    /// 获取当前有限状态机状态。
    /// </summary>
    public FsmState<T> CurrentState
    {
        get
        {
            return m_CurrentState;
        }
    }


    /// <summary>
    /// 获取当前有限状态机状态名称。
    /// </summary>
    public override string CurrentStateName
    {
        get
        {
            return m_CurrentState != null ? m_CurrentState.GetType().FullName : null;
        }
    }
    /// <summary>
    /// 获取当前有限状态机状态持续时间。
    /// </summary>
    public override float CurrentStateTime
    {
        get
        {
            return m_CurrentStateTime;
        }
    }

    /// <summary>
    /// 创建有限状态机
    /// </summary>
    /// <param name="name">有限状态机名称。</param>
    /// <param name="owner">有限状态机持有者。</param>
    /// <param name="states">有限状态机状态集合。</param>
    /// <returns>创建的有限状态机。</returns>
    public static Fsm<T> Create(string name,T owner,params FsmState<T>[] states)
    {
        if(owner == null)
        {
            Debuger.LogError("FSM owner is invalid.");
            throw new Exception("FSM owner is invalid.");
        }
        if (states == null)
        {
            Debuger.LogError("FSM states is invalid.");
            throw new Exception("FSM states is invalid.");
        }

        Fsm<T> fsm = new Fsm<T>();
        fsm.Name = name;
        fsm.m_Owner = owner;
        fsm.m_IsDestroyed = false;
        foreach (FsmState<T> state in states)
        {
            if(state == null)
            {
                Debuger.LogError("FSM states is invalid.");
                throw new Exception("FSM states is invalid.");
            }
            Type stateType = state.GetType();
            if (fsm.m_States.ContainsKey(stateType))
            {
                Debuger.LogError(string.Format("FSM '{0}' state '{1}' is already exist.", new TypeNamePair(typeof(T), name).ToString(), stateType));
                throw new Exception(string.Format("FSM '{0}' state '{1}' is already exist.", new TypeNamePair(typeof(T), name).ToString(), stateType));
            }

            fsm.m_States.Add(stateType, state);
            state.OnInit(fsm);
        }
        return fsm;
    }

    public FsmState<T>[] GetAllStates()
    {
        throw new NotImplementedException();
    }

    public void GetAllStates(List<FsmState<T>> results)
    {
        throw new NotImplementedException();
    }

    public TData GetData<TData>(string name) where TData : Variable
    {
        throw new NotImplementedException();
    }

    public Variable GetData(string name)
    {
        throw new NotImplementedException();
    }

    public TState GetState<TState>() where TState : FsmState<T>
    {
        throw new NotImplementedException();
    }

    public FsmState<T> GetState(Type stateType)
    {
        throw new NotImplementedException();
    }

    public bool HasData(string name)
    {
        throw new NotImplementedException();
    }

    public bool HasState<TState>() where TState : FsmState<T>
    {
        throw new NotImplementedException();
    }

    public bool RemoveData(string name)
    {
        throw new NotImplementedException();
    }

    public void SetData<TData>(string name, TData data) where TData : Variable
    {
        throw new NotImplementedException();
    }

    public void SetData(string name, Variable data)
    {
        throw new NotImplementedException();
    }

    public void Start<TState>() where TState : FsmState<T>
    {
        throw new NotImplementedException();
    }

    public void Start(Type stateType)
    {
        throw new NotImplementedException();
    }

    internal override void Shutdown()
    {
        throw new NotImplementedException();
    }

    internal override void Update(float elapseSeconds, float realElapseSeconds)
    {
        throw new NotImplementedException();
    }
}
