using System;
using System.Collections;
using KspHelper.Behavior;
using UnityEngine;

namespace AnimatedDecoupler
{
    public class DecoupleAnimator: KspBehavior
    {
        private Animation _currentAnimation;
        private string _animationName;
        private Func<string, Animation> _animationFunc;

        public void Initialize(Action decoupleAction, string animationName, Func<string,Animation> animFunc)
        {
            DecoupleAction = decoupleAction;
            _animationFunc = animFunc;
            AnimationName = animationName;
        }

        public Action DecoupleAction { get; private set; }

        public string AnimationName
        {
            get { return _animationName; }
            private set
            {
                {
                    _animationName = value;
                    if (!string.IsNullOrEmpty(_animationName) && _animationFunc != null)
                    {
                        _currentAnimation = _animationFunc(_animationName);
                    }
                }
            }
        }

        public void Execute()
        {
            if (_currentAnimation == null)
            {
                DecoupleAction();
                return;
            }

            this._currentAnimation.Play(AnimationName);
            StartCoroutine("PlayAnim");
        }

        public void Execute(KSPActionParam data)
        {
            if (data.type == KSPActionType.Activate)
            {
                Execute();
            }
        }

        IEnumerator PlayAnim()
        {
            while (_currentAnimation.isPlaying)
            {
                yield return new WaitForEndOfFrame();
            }

            DecoupleAction();
        }
    }
}