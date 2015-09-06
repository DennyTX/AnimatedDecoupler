Animated Decouplers
==================
it just add an animation possibility BEFORE decoupling. 
Also, it can catch following: event (Right mouse click and select item from context menu), from action (predefined action group), and while staging.  
It should be used instead of stock moduleDecoupler, with same  cfg config, just add animation name. If animation name will be missed - will work like regular moduleDecouple.

For example:

MODULE
{
  name = ModuleAnimatedDecoupler//ModuleAnimatedAnchoredDecoupler
  ejectionForce = 200
  explosiveNodeID = top
  staged = false
  animationName = YourAnimationName
}
	

