using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenaultAnimationsControl : MonoBehaviour
{
   // private Animation animation;

    private Animation distribution_box_switch_box;//手开配电箱
    private Animation motor_switch_hand_open;//手开电机开关
    private Animation lower_valve_hand_rotate;//手开下阀门
    private Animation lower_pipe_flow_1;//下部水管蓄水
    private Animation lower_pipe_flow_2;
    private Animation lower_pipe_flow_3;
    private Animation lower_pipe_flow_4;
    private Animation lower_pipe_flow_5;
    private Animation left_pipe_flow_1;//左部水管回流
    private Animation left_pipe_flow_2;
    private Animation left_pipe_flow_3;
    private Animation left_pipe_flow_4;
    private Animation left_pipe_flow_5;
    private Animation left_pipe_flow_6;
    private Animation left_pipe_flow_7;
    private Animation right_pipe_flow_1;//右部水管回流
    private Animation right_pipe_flow_2;
    private Animation right_pipe_flow_3;
    private Animation right_pipe_flow_4;
    private Animation right_pipe_flow_5;
    private Animation right_pipe_flow_6;
    private Animation right_pipe_flow_7;
    private Animation tank_left;//水箱蓄水
    private Animation tank_right;
    private Animation main_water_tube;//主管道注水
    private Animation tank_falls;//小瀑布
    private Animation tracer_switch_hand_open;//手开示踪器
    private Animation upper_valve_hand_rotate;//手开上阀门

    private Animation pipe_operate_animation;//安装管道


    // Start is called before the first frame update



    private void Awake()
    {


        motor_switch_hand_open = GameObject.Find("MotorSwitchAnimation").GetComponent<Animation>();
        lower_valve_hand_rotate = GameObject.Find("LowerValveRotateAnimation").GetComponent<Animation>();
        lower_pipe_flow_1 = GameObject.Find("LowerPipeFlowAnimation_1").GetComponent<Animation>();
        lower_pipe_flow_2 = GameObject.Find("LowerPipeFlowAnimation_2").GetComponent<Animation>();
        lower_pipe_flow_3 = GameObject.Find("LowerPipeFlowAnimation_3").GetComponent<Animation>();
        lower_pipe_flow_4 = GameObject.Find("LowerPipeFlowAnimation_4").GetComponent<Animation>();
        lower_pipe_flow_5 = GameObject.Find("LowerPipeFlowAnimation_5").GetComponent<Animation>();
        left_pipe_flow_1 = GameObject.Find("LeftPipeFlowAnimation_1").GetComponent<Animation>();
        left_pipe_flow_2 = GameObject.Find("LeftPipeFlowAnimation_2").GetComponent<Animation>();
        left_pipe_flow_3 = GameObject.Find("LeftPipeFlowAnimation_3").GetComponent<Animation>();
        left_pipe_flow_4 = GameObject.Find("LeftPipeFlowAnimation_4").GetComponent<Animation>();
        left_pipe_flow_5 = GameObject.Find("LeftPipeFlowAnimation_5").GetComponent<Animation>();
        left_pipe_flow_6 = GameObject.Find("LeftPipeFlowAnimation_6").GetComponent<Animation>();
        left_pipe_flow_7 = GameObject.Find("LeftPipeFlowAnimation_7").GetComponent<Animation>();
        right_pipe_flow_1 = GameObject.Find("RightPipeFlowAnimation_1").GetComponent<Animation>();
        right_pipe_flow_2 = GameObject.Find("RightPipeFlowAnimation_2").GetComponent<Animation>();
        right_pipe_flow_3 = GameObject.Find("RightPipeFlowAnimation_3").GetComponent<Animation>();
        right_pipe_flow_4 = GameObject.Find("RightPipeFlowAnimation_4").GetComponent<Animation>();
        right_pipe_flow_5 = GameObject.Find("RightPipeFlowAnimation_5").GetComponent<Animation>();
        right_pipe_flow_6 = GameObject.Find("RightPipeFlowAnimation_6").GetComponent<Animation>();
        right_pipe_flow_7 = GameObject.Find("RightPipeFlowAnimation_7").GetComponent<Animation>();
        tank_left = GameObject.Find("WaterTankLeftAnimation").GetComponent<Animation>();
        tank_right = GameObject.Find("WaterTankRightAnimation").GetComponent<Animation>();
        tank_falls = GameObject.Find("TankFallsAnimation").GetComponent<Animation>();
        main_water_tube = GameObject.Find("MainWaterTubeAnimation").GetComponent<Animation>();
        tracer_switch_hand_open = GameObject.Find("TracerSwitchAnimation").GetComponent<Animation>();
        upper_valve_hand_rotate = GameObject.Find("UpperValveRotateAnimation").GetComponent<Animation>();

        pipe_operate_animation = GameObject.Find("Variable_Ddiameter_tube").GetComponent<Animation>();
        distribution_box_switch_box = GameObject.Find("DistributionBoxSwitchBoxAnimation").GetComponent<Animation>();
    }

    private void Start()
    {
       // animation = GetComponent<Animation>();//找到Animation组件   
    }

    public void DistributionBoxSwitchBoxAnimationPlay()//手开(关)配电箱
    {
        distribution_box_switch_box.Play("DistributionBoxSwitchBox    Animation");
    }

    public void PipeOperateAnimationPlay()//安装管道
    {
        pipe_operate_animation.Play();
    }

    public void MotorSwitchOpenAnimation()//手开(关)电机开关
    {
        motor_switch_hand_open.Play();
        //Debug.Log(1);

    }

    public void LowerValveRotateAnimation()//手开下阀门+下补水管蓄水+水箱蓄水+右部水管回流+主管道蓄水
    {
        lower_valve_hand_rotate.Play();//手开下阀门
        lower_pipe_flow_1.Play();//下部管道蓄水
        lower_pipe_flow_2.Play();
        lower_pipe_flow_3.Play();
        lower_pipe_flow_4.Play();
        lower_pipe_flow_5.Play();
        tank_left.Play();//水箱蓄水
        tank_right.Play();
        
        tank_falls.Play();
        right_pipe_flow_1.Play();//右部管道回流
        right_pipe_flow_2.Play();
        right_pipe_flow_3.Play();
        right_pipe_flow_4.Play();
        right_pipe_flow_5.Play();
        right_pipe_flow_6.Play();
        right_pipe_flow_7.Play();
    }

    public void UpperValveRotateFirstAnimation()//手拧上阀门+左管道水回流
    {
        main_water_tube.Play();//主管道蓄水
        upper_valve_hand_rotate.Play();//手开上阀门
        left_pipe_flow_1.Play();//左管道水回流
        left_pipe_flow_2.Play();
        left_pipe_flow_3.Play();
        left_pipe_flow_4.Play();
        left_pipe_flow_5.Play();
        left_pipe_flow_6.Play();
        left_pipe_flow_7.Play();
    }

    public void UpperValveRotateNormalAnimation()//手拧上阀门
    {
        upper_valve_hand_rotate.Play();//手开上阀门
    }

    public void TracerSwitchOpenAnimation()//手开(关)示踪器
    {
        print(123);
        tracer_switch_hand_open.Play();
    }

    public void UpperValveRotateAnimationCloseAnimation()//手关上阀门
    {
        upper_valve_hand_rotate.Play("UpperValveRotateAnimation(Close)");
    }

    public void LowerValveRotateCloseAnimation()//手关下阀门+水箱放水+左管道放水+右管道放水+主管道放水
    {
        lower_valve_hand_rotate.Play("LowerValveRotateAnimation(Close)");//手关下阀门
        tank_right.Play("WaterTankRightAnimationDisappear");//右边水箱放水
        tank_left.Play("WaterTankLeftAnimationDisapper");//左边水箱放水
        right_pipe_flow_1.Play("RightPipeFlowAnimation_1 Disappear");//右边管道放水
        right_pipe_flow_2.Play("RightPipeFlowAnimation_2 Disappear");
        right_pipe_flow_3.Play("RightPipeFlowAnimation_3 Disappear");
        right_pipe_flow_4.Play("RightPipeFlowAnimation_4 Disappear");
        right_pipe_flow_5.Play("RightPipeFlowAnimation_5 Disappear");
        right_pipe_flow_6.Play("RightPipeFlowAnimation_6 Disappear");
        right_pipe_flow_7.Play("RightPipeFlowAnimation_7 Disappear");
        left_pipe_flow_1.Play("LefttPipeFlowAnimation_1 Disappear");//左边管道放水
        left_pipe_flow_2.Play("LefttPipeFlowAnimation_2 Disappear");
        left_pipe_flow_3.Play("LefttPipeFlowAnimation_3Disappear");
        left_pipe_flow_4.Play("LefttPipeFlowAnimation_4Disappear");
        left_pipe_flow_5.Play("LefttPipeFlowAnimation_5Disappear");
        left_pipe_flow_6.Play("LefttPipeFlowAnimation_6Disappear");
        left_pipe_flow_7.Play("LefttPipeFlowAnimation_7Disappear");
        main_water_tube.Play("MainWaterTube AnimationDisapper");//主管道放水 
    }

}
