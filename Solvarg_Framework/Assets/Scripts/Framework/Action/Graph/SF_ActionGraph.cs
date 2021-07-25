using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;
namespace SolvargAction
{
    [CreateAssetMenu(menuName = "Solvarg/Action/New Action Graph", order = 0)]
    public class SF_ActionGraph : NodeGraph
    {
        public string roleId;
        [HideInInspector]
        public BaseRole owner;
        public SFAction_StateNode startState;

        #region 运行时
        [HideInInspector]
        public ActionController controller;
        public SFAction_StateNode _currentState;
        private SFAction_StateNode currentState
        {
            set
            {
                _currentState = value;
            }
            get
            {
                return _currentState;
            }
        }
        private bool isRunning=false;
        private Dictionary<string, SFAction_StateNode> stateDict;

        /// <summary>
        /// 首次进入Action图初始化
        /// </summary>
        public void InitGraph()
        {
            stateDict = new Dictionary<string, SFAction_StateNode>();
            foreach (Node node in nodes)
            {
                if (node is SFAction_StateNode)
                {
                    SFAction_StateNode cur = node as SFAction_StateNode;
                    stateDict.Add(cur.stateName, cur);
                }
            }
            owner = SingletonManager.Instance.GeRole(roleId);
        }

        public bool ForceChangeState(SFAction_StateNode oldState,SFAction_StateNode newState = null)
        {
            if(Time.time - oldState.startTime < oldState.coolDownTime)
            {
                //当前状态冷却时间未达到
                return false;
            }
            this.currentState = null;
            newState = newState ? newState : startState;
            oldState.ExitState();
            newState.StartState();
            this.currentState = newState;
            return true;
        }

        /// <summary>
        /// 开始Action图
        /// </summary>
        public void StartActionGraph()
        {
            currentState = startState;
            currentState.StartState();//第一次进入要初始化首结点
            isRunning = true;
        }

        /// <summary>
        /// 停止Action图
        /// </summary>
        public void StopActionGraph()
        {
            isRunning = false;
            currentState.ExitState();
        }

        public void Release()
        {
            Destroy(this);
        }
        #region Unity CallBack 由Controller和Manager回调注册

        public void Update()
        {
            if (!isRunning) return;
            //帧执行当前状态
            currentState?.Execute();
        }
        #endregion
        #endregion
    }
}