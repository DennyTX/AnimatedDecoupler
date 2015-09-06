using System.Linq;
using AnimatedDecoupler;
using KspHelper.Actions;
using KspHelper.Events;

namespace AnimatedDecouplers
{
    public class ModuleAnimatedAnchoredDecoupler : ModuleAnchoredDecoupler
    {
        //animation name from model
        [KSPField]
        public string AnimationName;

        private DecoupleAnimator _animator;

        public override void OnStart(StartState state)
        {
            base.OnStart(state);

            if ((state & StartState.Flying) != StartState.Flying) return;

            _animator = gameObject.AddComponent<DecoupleAnimator>();
            _animator.Initialize(this.OnDecouple, AnimationName, s => part.FindModelAnimators(AnimationName).FirstOrDefault());

            this.ReplaceEvent("Decouple", _animator.Execute);
            this.ReplaceAction("DecoupleAction", _animator.Execute);
        }

        public override void OnActive()
        {
            if (staged)
            {
                _animator.Execute();
            }
        }
    }
}
