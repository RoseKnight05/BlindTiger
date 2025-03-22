YAML 1.1
 %TAG !u! tag:unity3d.com,2011:
 --- !u!1101 &-8519697843662017518
 AnimatorStateTransition:
   m_ObjectHideFlags: 1
   m_CorrespondingSourceObject: {fileID: 0}
   m_PrefabInstance: {fileID: 0}
   m_PrefabAsset: {fileID: 0}
   m_Name: 
   m_Conditions:
   - m_ConditionMode: 1
     m_ConditionEvent: IsClose
     m_EventTreshold: 0
   m_DstStateMachine: {fileID: 0}
   m_DstState: {fileID: 2694129080543642497}
   m_Solo: 0
   m_Mute: 0
   m_IsExit: 0
   serializedVersion: 3
   m_TransitionDuration: 0.2
   m_TransitionOffset: 0
   m_ExitTime: 0.75
   m_HasExitTime: 0
   m_HasFixedDuration: 1
   m_InterruptionSource: 0
   m_OrderedInterruption: 1
   m_CanTransitionToSelf: 1
 --- !u!1101 &-2797734875423620464
 AnimatorStateTransition:
   m_ObjectHideFlags: 1
   m_CorrespondingSourceObject: {fileID: 0}
   m_PrefabInstance: {fileID: 0}
   m_PrefabAsset: {fileID: 0}
   m_Name: 
   m_Conditions:
   - m_ConditionMode: 2
     m_ConditionEvent: IsWalking
     m_EventTreshold: 0
   - m_ConditionMode: 2
     m_ConditionEvent: IsClose
     m_EventTreshold: 0
   m_DstStateMachine: {fileID: 0}
   m_DstState: {fileID: -2526053963659473367}
   m_Solo: 0
   m_Mute: 0
   m_IsExit: 0
   serializedVersion: 3
   m_TransitionDuration: 0.5
   m_TransitionOffset: 0
   m_ExitTime: 0.2
   m_HasExitTime: 1
   m_HasFixedDuration: 1
   m_InterruptionSource: 0
   m_OrderedInterruption: 1
   m_CanTransitionToSelf: 1
 --- !u!1102 &-2526053963659473367
 AnimatorState:
   serializedVersion: 6
 @@ -52,6 +105,34 @@ AnimatorStateTransition:
   m_InterruptionSource: 0
   m_OrderedInterruption: 1
   m_CanTransitionToSelf: 1
 --- !u!1101 &-1850632196649481644
 AnimatorStateTransition:
   m_ObjectHideFlags: 1
   m_CorrespondingSourceObject: {fileID: 0}
   m_PrefabInstance: {fileID: 0}
   m_PrefabAsset: {fileID: 0}
   m_Name: 
   m_Conditions:
   - m_ConditionMode: 1
     m_ConditionEvent: IsWalking
     m_EventTreshold: 0
   - m_ConditionMode: 2
     m_ConditionEvent: IsClose
     m_EventTreshold: 0
   m_DstStateMachine: {fileID: 0}
   m_DstState: {fileID: 6819272093602387292}
   m_Solo: 0
   m_Mute: 0
   m_IsExit: 0
   serializedVersion: 3
   m_TransitionDuration: 0.25
   m_TransitionOffset: 0
   m_ExitTime: 0.8125
   m_HasExitTime: 0
   m_HasFixedDuration: 1
   m_InterruptionSource: 0
   m_OrderedInterruption: 1
   m_CanTransitionToSelf: 1
 --- !u!91 &9100000
 AnimatorController:
   m_ObjectHideFlags: 0
 @@ -67,6 +148,12 @@ AnimatorController:
     m_DefaultInt: 0
     m_DefaultBool: 0
     m_Controller: {fileID: 0}
   - m_Name: IsClose
     m_Type: 4
     m_DefaultFloat: 0
     m_DefaultInt: 0
     m_DefaultBool: 0
     m_Controller: {fileID: 0}
   m_AnimatorLayers:
   - serializedVersion: 5
     m_Name: Base Layer
 @@ -158,6 +245,34 @@ AnimatorStateTransition:
   m_InterruptionSource: 0
   m_OrderedInterruption: 1
   m_CanTransitionToSelf: 1
 --- !u!1102 &2694129080543642497
 AnimatorState:
   serializedVersion: 6
   m_ObjectHideFlags: 1
   m_CorrespondingSourceObject: {fileID: 0}
   m_PrefabInstance: {fileID: 0}
   m_PrefabAsset: {fileID: 0}
   m_Name: pistol_aim
   m_Speed: 1
   m_CycleOffset: 0
   m_Transitions:
   - {fileID: -1850632196649481644}
   - {fileID: -2797734875423620464}
   m_StateMachineBehaviours: []
   m_Position: {x: 50, y: 50, z: 0}
   m_IKOnFeet: 0
   m_WriteDefaultValues: 1
   m_Mirror: 0
   m_SpeedParameterActive: 0
   m_MirrorParameterActive: 0
   m_CycleOffsetParameterActive: 0
   m_TimeParameterActive: 0
   m_Motion: {fileID: 7400000, guid: d6da10c4669c09942830efa63dbc5db4, type: 2}
   m_Tag: 
   m_SpeedParameter: 
   m_MirrorParameter: 
   m_CycleOffsetParameter: 
   m_TimeParameter: 
 --- !u!1101 &4676189278461272785
 AnimatorStateTransition:
   m_ObjectHideFlags: 1
 @@ -201,8 +316,12 @@ AnimatorStateMachine:
   - serializedVersion: 1
     m_State: {fileID: 1131959174274857372}
     m_Position: {x: 610, y: 80, z: 0}
   - serializedVersion: 1
     m_State: {fileID: 2694129080543642497}
     m_Position: {x: 30, y: -80, z: 0}
   m_ChildStateMachines: []
   m_AnyStateTransitions: []
   m_AnyStateTransitions:
   - {fileID: -8519697843662017518}
   m_EntryTransitions: []
   m_StateMachineTransitions: {}
   m_StateMachineBehaviours: []