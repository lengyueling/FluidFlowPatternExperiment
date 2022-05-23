using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine.UI;
using UnityEngine;
using System.Net.Mime;
using System.Diagnostics;
using UnityEngine.SceneManagement;
public class PlayerTrigger : MonoBehaviour
{
	/*
	 * 计数器
		1、手开配电箱（无）
		2、手开电机开关
		3、手开下阀门+下补水管蓄水+水箱蓄水+右部水管回流
		4、手拧上阀门+主管道蓄水+左管道水回流
		5、手开示踪剂
		6、手拧上阀门

		7、手关（开）示踪剂
		8、手关下阀门+水箱放水（左没有）+左管道放水+右管道放水+主管道放水
		9、关闭电机
		10、关闭上阀门
		11、手关配电箱（无）
	 */
	bool[] procedure = new bool[10] {  false, false, false, false, false, false, false, false, false, false };
    
	//private int count = 0; 

	private GameObject motor_switch_hand;
	private GameObject lower_valve_rotate_hand;
	private GameObject tracer_switch_hand;
	private GameObject upper_valve_hand;
	private GameObject fuse_hand;


	/*
	 * 粒子系统
	 */
	private GameObject particle;



	/*
	 * 设备开关标志
	 */
	private bool isLeftDoorOpen = false;
	private bool isRightDoorOpen = false;
	private bool isCB_1_Left_Open = false;
	private bool isCB_1_Right_Open = false;
	private bool isCB_2_Left_Open = false;
	private bool isCB_2_Right_Open = false;
	private bool isSwitchOpen = true;
	private bool isFuseDoorOpen = false;
	private bool isMotorOpen = false;
	private bool isLowerValveOpen = false;
	private bool isUpperValveFirstOpen = false;
	private bool isFuseOpen = false;
	private bool isTracerOpen = false;
	private bool isMainDoorOpen = false;

	/*
	 * 屏幕中心所指向物体
	 */
	private Transform targetTransform;

	/*
	 * MainUI提示信息
	 */
	private Text ui_objectInformation;
	private Text ui_tips;

	/*
	 * MeshText提示信息
	 */
	private GameObject ui_mesh_fuse;
	private GameObject ui_mesh_motor;
	private GameObject ui_mesh_computer;
	private GameObject ui_mesh_lower_valve;
	private GameObject ui_mesh_upper_valve;
	private GameObject ui_mesh_tracer;

	/*
	 * 电视UI
	 */
	private GameObject ui_G_HintText;
	private GameObject ui_G_ParameterText;
	private TextMesh ui_units_text;
	private TextMesh ui_hint_text;
	private TextMesh ui_T_text;
	private TextMesh ui_u_text;
	private TextMesh ui_v_text;
	private TextMesh ui_Re_text;
	private TextMesh ui_ro_text;
	private TextMesh ui_pipe_r;

	/*
	 * 有交互的对象实例化
	 */
	private DoorRight m_MainDoorRight;
	private DoorLeft m_MainDoorLeft;
	private DoorRight m_DoorRight;
	private DoorLeft m_DoorLeft;
	private CupboardRight m_CupboardRight_1;
	private CupboardRight m_CupboardRight_2;
	private CupboardLeft m_CupboardLeft_1;
	private CupboardLeft m_CupboardLeft_2;
	private SwitchControl m_Switch;
	private ValveControl m_valve;
	private FlowControl m_flow;
	private RenaultAnimationsControl m_AnimationsControl;
	private RenaultAudioControl m_AudioControl;
	private SwitchToComputerInterface m_computer;
	private FuseControl m_fuse_door;

	/*
	 * 射线检测相关
	 */
	private Camera m_camera;
	private Vector3 mp;


	private HighlightableObject m_ho_Switch;
	//private HighlightableObject m_ho_CupboardRight_1;
	//private HighlightableObject m_ho_CupboardRight_2;
	//private HighlightableObject m_ho_CupboardLeft_1;
	//private HighlightableObject m_ho_CupboardRight_;
	//private HighlightableObject m_ho_DoorLeft;
	//private HighlightableObject m_ho_DoorRight;



	/*
	 * 雷诺实验参数
	 */
	private double T = 25;
	private double u = 0.00089;
	static double v = 0;
	static double Re = 0;
	private double ro = 997.05;
	private double pipe_R = 0.04;

    //输入标签
    int inputF = 0;

	private void Awake()
	{
		ui_mesh_fuse = GameObject.Find("FuseMeshText");
		ui_mesh_motor = GameObject.Find("MotorSwitchMeshText");
		ui_mesh_computer = GameObject.Find("ComputerMeshText");
		ui_mesh_lower_valve = GameObject.Find("LowerValveMeshText");
		ui_mesh_upper_valve = GameObject.Find("UpperValveMeshText");
		ui_mesh_tracer = GameObject.Find("TracerMeshText");


		motor_switch_hand = GameObject.Find("MotorSwitchAnimation");
		lower_valve_rotate_hand = GameObject.Find("LowerValveRotateAnimation");
		tracer_switch_hand = GameObject.Find("TracerSwitchAnimation");
		upper_valve_hand = GameObject.Find("UpperValveRotateAnimation");
		fuse_hand = GameObject.Find("DistributionBoxSwitchBoxAnimation");

		/*
		 * 实例化所有对象，为后续实现函数接口
		 */
		m_MainDoorLeft = GameObject.Find("MainDoorLeft").GetComponent<DoorLeft>();
		m_MainDoorRight = GameObject.Find("MainDoorRight").GetComponent<DoorRight>();
		m_DoorRight = GameObject.Find("Renault_Main_Door_Right").GetComponent<DoorRight>();
		m_DoorLeft = GameObject.Find("Renault_Main_Door_Left").GetComponent<DoorLeft>();
		//m_CupboardRight_1 = GameObject.Find("CupboardRight_1").GetComponent<CupboardRight>();
		//m_CupboardRight_2 = GameObject.Find("CupboardRight_2").GetComponent<CupboardRight>();
		//m_CupboardLeft_1 = GameObject.Find("CupboardLeft_1").GetComponent<CupboardLeft>();
		//m_CupboardLeft_2 = GameObject.Find("CupboardLeft_2").GetComponent<CupboardLeft>();
		//m_Switch = GameObject.Find("Switch_Button").GetComponent<SwitchControl>();
		m_valve = GameObject.Find("valve_rotate").GetComponent<ValveControl>();
		m_flow = GameObject.Find("particle_system").GetComponent<FlowControl>();
		m_AnimationsControl = GameObject.Find("RenaultAnimations").GetComponent<RenaultAnimationsControl>();
		m_AudioControl = GameObject.Find("RenaultAudios").GetComponent<RenaultAudioControl>();
		m_computer = GameObject.Find("ComputerScreen").GetComponent<SwitchToComputerInterface>();
		m_fuse_door = GameObject.Find("Fuse_Box_Door").GetComponent<FuseControl>();

		/*
		 * 实例化粒子系统
		 */
		particle = GameObject.Find("particle_system");

		/*
		 * 实例化MainUI部分
		 */
		ui_objectInformation = GameObject.Find("ObjectInformation").GetComponent<Text>();
		ui_tips = GameObject.Find("Tips").GetComponent<Text>();

		/*
		 * 实例化3DUI部分
		 */
		ui_G_HintText = GameObject.Find("HintText");
		ui_G_ParameterText = GameObject.Find("ParameterText");
		ui_units_text = GameObject.Find("UnitText").GetComponent<TextMesh>();
		ui_hint_text = GameObject.Find("Text_hint").GetComponent<TextMesh>();
		ui_T_text = GameObject.Find("Text_T").GetComponent<TextMesh>();
		ui_u_text = GameObject.Find("Text_u").GetComponent<TextMesh>();
		ui_v_text = GameObject.Find("Text_v").GetComponent<TextMesh>();
		ui_Re_text = GameObject.Find("Text_Re").GetComponent<TextMesh>();
		ui_ro_text = GameObject.Find("Text_ro").GetComponent<TextMesh>();
		ui_pipe_r = GameObject.Find("Text_pipe_r").GetComponent<TextMesh>();

		/*
		 * 实例化camera
		 */
		m_camera = GameObject.Find("FirstPersonCharacter").GetComponent<Camera>();

		//m_ho_Switch = GameObject.Find("Switch").GetComponent<HighlightableObject>();


	}
	void Start()
	{
		ParticleSystemUnit();
		TelevisionUiInit();

		motor_switch_hand.SetActive(false);
		lower_valve_rotate_hand.SetActive(false);
		tracer_switch_hand.SetActive(false);
		upper_valve_hand.SetActive(false);
		fuse_hand.SetActive(false);

		//ui_mesh_fuse.SetActive(false);
		ui_mesh_motor.SetActive(false);
		ui_mesh_computer.SetActive(false);
		ui_mesh_lower_valve.SetActive(false);
		ui_mesh_upper_valve.SetActive(false);
		ui_mesh_tracer.SetActive(false);
	}
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.F))
        {
            switch(inputF)
            {
                case 1:
                    {
                        FuseDoorControler();
                        break;
                    }
                case 2:
                    {
                        if (isFuseOpen == false && procedure[0] == false)
                        {
							ui_mesh_fuse.SetActive(false);
							ui_mesh_computer.SetActive(true);
							ui_hint_text.text = "步骤一：请移步到电脑旁了解本次实验有关信息。";
                            isFuseOpen = true;
                            procedure[0] = true;
                            FuseAnimationControler();
                        }
                        else if (isFuseOpen == true && procedure[9] == true)
                        {
                            isFuseOpen = false;
                            FuseAnimationControler();
                            for (int i = 0; i < 10; i++)
                            {
                                procedure[i] = false;
                            }
                        }
                        break;
                    }
                case 3:
                    {
						ui_mesh_computer.SetActive(false);
						ui_mesh_motor.SetActive(true);
						ui_hint_text.text = "步骤二：请打开电机开关";
                        ComputerControler();
                        break;
                    }
                case 4:
                    {
						ui_mesh_motor.SetActive(false);
						ui_mesh_lower_valve.SetActive(true);

						if (procedure[0] == true && procedure[1] == false)
                        {
                            CentrifugeControler();
                            ui_hint_text.text = "步骤三：请打开注水阀门。";
                            procedure[1] = true;
                        }
                        else if (procedure[7] == true && procedure[8] == false)
                        {
                            CentrifugeControler();
                            ui_hint_text.text = "结束步骤四：请关闭管道出口阀门。";
                            procedure[8] = true;
                        }
                        break;
                    }
                case 5:
                    {
						ui_mesh_lower_valve.SetActive(false);
						ui_mesh_upper_valve.SetActive(true);
						if (isLowerValveOpen == false && procedure[1] == true && procedure[2] == false)
                        {
                            LowerValveControllerOpen();
                            ui_hint_text.text = "步骤四：拧管道出口阀门。";
                            isLowerValveOpen = true;
                            procedure[2] = true;
                        }
                        else if (isLowerValveOpen == true && procedure[6] == true && procedure[7] == false)
                        {
                            LowerValveControllerClose();
                            ui_hint_text.text = "结束步骤三：请关闭电机。";
                            isLowerValveOpen = false;
                            procedure[7] = true;
                        }
                        break;
                    }
                case 6:
                    {
                        if (isTracerOpen == false && procedure[3] == true && procedure[4] == false)
                        {
                            TracerValveControler();
                            particle.SetActive(true);
                            ui_hint_text.text = "步骤六：请继续拧管道出口阀门。";
                            isTracerOpen = true;
                            procedure[4] = true;
                        }
                        else if (isTracerOpen == true && procedure[5] == true && procedure[6] == false)
                        {
                            ui_G_ParameterText.SetActive(false);
                            ui_G_HintText.SetActive(true);
                            ui_hint_text.text = "结束步骤二：请关闭溢流箱进水阀门。";
                            TracerValveControler();
                            particle.SetActive(false);
                            isTracerOpen = false;
                            procedure[6] = true;
                        }
                        break;
                    }
                case 7:
                    {
                        if (isUpperValveFirstOpen == false && procedure[2] == true && procedure[3] == false)
                        {
                            ui_hint_text.text = "步骤五：释放示踪剂盒。";
                            isUpperValveFirstOpen = true;
                            UpperValveControllerFirstOpen();
                            procedure[3] = true;
                        }
                        else if (isUpperValveFirstOpen == true && isTracerOpen == true && procedure[4] == true)
                        {
                            ui_G_ParameterText.SetActive(true);
                            ui_G_HintText.SetActive(false);
                            UpperValveControllerNormalOpen();
                            FlowController();
                            UiUpdate();
                            procedure[5] = true;
                        }
                        else if (procedure[8] == true && procedure[9] == false)
                        {
                            UpperValveControllerClose();
                            ui_hint_text.text = "结束步骤五：请关闭电闸。";
                            procedure[9] = true;
                        }
                        break;
                    }
                case 8:
                    {
                        DoorControler();
                        break;
                    }
                case 9:
                    {
                        //PipeOpertateControler();
                        break;
                    }
                default:
                    {
                        inputF = 0;
                        break;
                    }

            }
        }
	}
	/// <summary>
	/// 开门计时器
	/// </summary>
	/// <returns></returns>
	IEnumerator OpenDoorTimer() 
	{
		yield return new WaitForSeconds(1.0f);
		isLeftDoorOpen = true;
	}
	/// <summary>
	/// 关门计时器
	/// </summary>
	/// <returns></returns>
	IEnumerator CloseDoorTimer() 
	{
		yield return new WaitForSeconds(1.0f);
		isLeftDoorOpen = false;
	}

	/*
	 * 碰撞体状态检测模块
	 */
	private void OnTriggerStay(Collider other)
	{
		if (TarRaycast() && other.gameObject.name == targetTransform.name)
		{
			switch (other.gameObject.name)
			{
				case "Fuse_Box_Door":
					{
						ui_objectInformation.text = "电闸箱门";
						ui_tips.text = "按“F”打开/关闭箱门";
                        inputF = 1;
						break;
					}
				
				case "Fuse_Box_01":
					{
						ui_objectInformation.text = "电闸开关";
						ui_tips.text = "按“F”打开/关闭电闸";
                        inputF = 2;
						break;
					}
				/*
				* 实验室电脑
				*/
				case "ComputerScreen":
					{
						ui_objectInformation.text = "电脑";
						ui_tips.text = "按“F”进入交互";
                        inputF = 3;
						break;
					}
				//电机开关
				case "MotorSwitch ":
					{
						ui_objectInformation.text = "电机开关";
						ui_tips.text = "按“F”键打开/关闭";
                        inputF = 4;
						break;
					}

				//下阀门
				case "LowerValve":
					{
						ui_objectInformation.text = "溢流箱进水阀门";
						ui_tips.text = "按“F”键打开/关闭";
                        inputF = 5;
						break;
					}

				//示踪剂
				case "Tracer":
					{
						ui_objectInformation.text = "示踪剂盒";
						ui_tips.text = "按“F”键释放/关闭";
                        inputF = 6;
						break;
					}

				/*
				 * 上阀门
				 */
				case "valve_rotate":
					{
						ui_objectInformation.text = "管道出口阀门";
						ui_tips.text = "按“F”键打开/关闭阀门";
                        inputF = 7;
						break;
					}

				/*
				* 雷诺实验室大门
				*/
				case "Renault_Main_Door_Left":
				case "Renault_Main_Door_Right":
					{

						ui_objectInformation.text = "流体流型实验室大门";
						ui_tips.text = "按“F”键开门";
                        inputF = 8;
						break;
					}

				/*
			 * 灯光开关
			 */
				case "Switch":
					{
						ui_objectInformation.text = "灯控";
						ui_tips.text = "按“F”键打开/关闭灯光";
                        //m_ho_Switch.enabled = true;
                        //m_ho_Switch.ConstantOn(Color.yellow);
						if (Input.GetKeyDown(KeyCode.F))
						{
							//SwitchController();
						}

						break;
					}

			

				/*
				* 实验室仪器柜
				*/
				case "CupboardLeft_1":
				case "CupboardLeft_2":
				case "CupboardRight_1":
				case "CupboardRight_2":
					{
						ui_objectInformation.text = "柜门";
						ui_tips.text = "按“F”键开/关门";
						break;
					}


				//左柜子
				case "InstrumentCabinet_2":
					{
						ui_objectInformation.text = "柜子";
						break;
					}
				//右柜子
				case "InstrumentCabinet_1":
					{
						ui_objectInformation.text = "柜子";
						break;
					}
				//柜门
				case "Cupboard00":
				case "Cupboard01":
					{
						ui_objectInformation.text = "上柜门";
						ui_tips.text = "按“F”键打开/关闭柜门";
						if (Input.GetKeyDown(KeyCode.F))
						{
							//CBController();
						}
						break;
					}
				case "Cupboard10":
				case "Cupboard11":
					{
						ui_objectInformation.text = "下柜门";
						ui_tips.text = "按“F”键打开/关闭柜门";
						if (Input.GetKeyDown(KeyCode.F))
						{
							//CBController();
						}
						break;
					}
					//主大门
				case "MainDoorRight":
				case "MainDoorLeft":
					{
						ui_objectInformation.text = "主门口大门";
						ui_tips.text = "按“F”开启/关闭";
						MainDoorControler();
						break;
					}
				//电视
				case "LCD_2_1 (1)":
				case "LCD_2_1":
					{
						ui_objectInformation.text = "电视";
						ui_tips.text = "按“F”键查看数据";
						break;
					}


				//水箱
				case "Tank":
					{
						ui_objectInformation.text = "水箱";
						ui_tips.text = "";
						break;
					}
				//变径管
				case "Variable_Ddiameter_tube":
					{
						ui_objectInformation.text = "变径管";
						ui_tips.text = "按F拆卸/更换管道";
                        inputF = 9;
						break;
					}
				case "AdjustablePipeline_2_1":
					{
						ui_objectInformation.text = "变径管40cm";
						break;
					}
				//离心泵
				case "Centrifugal_pump":
					{
						ui_objectInformation.text = "离心泵";
						ui_tips.text = "";
						break;
					}
				//电机
				case "Motor":
					{
						ui_objectInformation.text = "电机";
						break;
					}




				//抽屉
				case "Drawer01":
				case "Drawer11":
				case "Drawer21":
					{
						ui_objectInformation.text = "最上层抽屉";
						ui_tips.text = "按“F”键打开";
						break;
					}
				case "Drawer02":
				case "Drawer12":
				case "Drawer22":
					{
						ui_objectInformation.text = "上层抽屉";
						ui_tips.text = "按“F”键打开";
						break;
					}
				case "Drawer03":
				case "Drawer13":
				case "Drawer23":
					{
						ui_objectInformation.text = "下层抽屉";
						ui_tips.text = "按“F”键打开";
						break;
					}
				case "Drawer04":
				case "Drawer14":
				case "Drawer24":
					{
						ui_objectInformation.text = "最下层抽屉";
						ui_tips.text = "按“F”键打开";
						break;
					}


				//椅子
				case "Chair_1":
				case "Chair_2":
				case "Chair_3":
					{
						ui_objectInformation.text = "椅子";
						break;
					}
				//桌子
				case "Desk_1":
				case "Desk_3":
				case "Desk_2":
					{
						ui_objectInformation.text = "桌子";
						ui_tips.text = "";
						break;
					}

				//窗户
				case "window":
				case "windo_open":
					{
						ui_objectInformation.text = "窗户";
						break;
					}
				/*
				case "window_Left":
				case "window_Right":
				{
					ui_objectInformation.text = "窗户";
					break;
				}
				*/


				//	m_objectInformation.text = "窗户";
				//	break;
				//case "Desk_1":
				//	m_objectInformation.text = "办公桌";
				//	break;
				//case "Desk_2":
				//	m_objectInformation.text = "办公桌";
				//	break;
				//case "Desk_3":
				//	m_objectInformation.text = "办公桌";
				//	break;
				//case "Chair_1":
				//	m_objectInformation.text = "办公椅";
				//	break;
				//case "Chair_2":
				//	m_objectInformation.text = "办公椅";
				//	break;
				//case "Chair_3":
				//	m_objectInformation.text = "办公椅";
				//	break;
				//case "LCD_1":
				//	m_objectInformation.text = "电脑";
				//	m_tips.text = "点击“鼠标左键”互动";
				//	break;
				//case "Switch":
				//	m_objectInformation.text = "灯开关";
				//	m_tips.text = "点击“鼠标左键”互动";
				//	m_ho_Switch.enabled = true;
				//	m_ho_Switch.ConstantOn(Color.yellow);
				//	break;
				default:
					ui_tips.text = null;
					ui_objectInformation.text = null;
					//m_ho_Switch.enabled = false;
					break;
			}
		}
	}



	private void ParticleSystemUnit()
	{
		particle.SetActive(false);
	}

	private void UiUpdate()
	{
		ui_T_text.text = T.ToString();
		ui_u_text.text = u.ToString("f5");
		ui_v_text.text = v.ToString("f3");
		ui_Re_text.text = Re.ToString("f2");
		ui_ro_text.text = ro.ToString("f2");
		ui_pipe_r.text = pipe_R.ToString();
	}
	/*
	 * 初始化UI
	 */
	private void TelevisionUiInit()
	{
		ui_G_ParameterText.SetActive(false);
	}

	private void PipeOpertateControler()
	{
		m_AnimationsControl.PipeOperateAnimationPlay();
	}
	/*
	 * 流型控制
	 */
	private void FlowController()
	{
		v += 0.001f;
		Re = pipe_R * v * ro / u;
		m_flow.Flow(Re);
	}

	public void FuseAnimationControler()
	{
		upper_valve_hand.SetActive(false);
		fuse_hand.SetActive(true);
		m_AnimationsControl.DistributionBoxSwitchBoxAnimationPlay();
	}
	/*
	 * 灯开关控制
	 */
	private void SwitchController()
	{
		if (isSwitchOpen)
		{
			m_Switch.TurnOffdLight();
			isSwitchOpen = false;
		}
		else
		{
			m_Switch.TurnOnLight();
			isSwitchOpen = true;
		}
	}
	/*
	 * 电闸门开关
	 */
	 private void FuseDoorControler()
	{
		if (isFuseDoorOpen == false)
		{
			m_fuse_door.OpenDoor();
			isFuseDoorOpen = true;
		}
		else
		{
			isFuseDoorOpen = false;
			m_fuse_door.CloseDoor();
		}
		
	}

	/*
	 * 下阀门控制->蓄水控制
	 */
	private void LowerValveControllerOpen()
	{
		motor_switch_hand.SetActive(false);
		lower_valve_rotate_hand.SetActive(true);
		m_AnimationsControl.LowerValveRotateAnimation();
	}

	private void LowerValveControllerClose()
	{
		tracer_switch_hand.SetActive(false);
		motor_switch_hand.SetActive(false);
		lower_valve_rotate_hand.SetActive(true);
		m_AnimationsControl.LowerValveRotateCloseAnimation();
	}
	/*
	 * 上阀门控制->流速控制
	 */
	private void UpperValveControllerFirstOpen()
	{
		upper_valve_hand.SetActive(true);
		tracer_switch_hand.SetActive(false);
		m_valve.OpenValve();
		m_AnimationsControl.UpperValveRotateFirstAnimation();
	}

	private void UpperValveControllerNormalOpen()
	{
		upper_valve_hand.SetActive(true);
		tracer_switch_hand.SetActive(false);
		m_valve.OpenValve();
		m_AnimationsControl.UpperValveRotateNormalAnimation();
	}

	private void UpperValveControllerClose()
	{
		upper_valve_hand.SetActive(true);
		tracer_switch_hand.SetActive(false);
		m_valve.OpenValve();
		m_AnimationsControl.UpperValveRotateAnimationCloseAnimation();
	}
	/*
	 * 仪器柜控制
	 */
	private void CBController()
	{
		switch (targetTransform.name)
		{

			case "CupboardLeft_1":
				{
					if (isCB_1_Left_Open == false)
					{
						m_CupboardLeft_1.OpenCupboardLeft();
						isCB_1_Left_Open = true;
					}
					else
					{
						m_CupboardLeft_1.CloseCupboardLeft();
						isCB_1_Left_Open = false;
					}
					break;
				}
			case "CupboardRight_1":
				{
					if (isCB_1_Right_Open == false)
					{
						m_CupboardRight_1.OpenCupboardRight();
						isCB_1_Right_Open = true;
					}
					else
					{
						m_CupboardRight_1.CloseCupboardRight();
						isCB_1_Right_Open = false;
					}
					break;
				}
			case "CupboardLeft_2":
				{
					if (isCB_2_Left_Open == false)
					{
						m_CupboardLeft_2.OpenCupboardLeft();
						isCB_2_Left_Open = true;
					}
					else
					{
						m_CupboardLeft_2.CloseCupboardLeft();
						isCB_2_Left_Open = false;
					}
					break;
				}
			case "CupboardRight_2":
				{
					if (isCB_2_Right_Open == false)
					{
						m_CupboardRight_2.OpenCupboardRight();
						isCB_2_Right_Open = true;
					}
					else
					{
						m_CupboardRight_2.CloseCupboardRight();
						isCB_2_Right_Open = false;
					}
					break;
				}
		}
	}

	/*
	 * 雷诺实验室门控制
	 */
	private void DoorControler()
	{
		if (isLeftDoorOpen == false)
		{
			m_DoorRight.OpenRightDoor();
			m_DoorLeft.OpenLeftDoor();
			StartCoroutine(OpenDoorTimer());
			
			
		}
		else
		{
			m_DoorLeft.CloseLeftDoor();
			m_DoorRight.CloseRightDoor();
			StartCoroutine(CloseDoorTimer());
		}
	}

	/*
	 * 建筑物大门控制
	 */
	private void MainDoorControler()
	{
		if (isMainDoorOpen == false)
		{
			m_MainDoorRight.OpenRightDoor();
			m_MainDoorLeft.OpenLeftDoor();
			StartCoroutine(OpenDoorTimer());
			isMainDoorOpen = true;

		}
		else
		{
			m_MainDoorLeft.CloseLeftDoor();
			m_MainDoorRight.CloseRightDoor();
			StartCoroutine(CloseDoorTimer());
			isMainDoorOpen = false;
		}
	}

	/*
	 * 示踪剂阀门控制
	 */
	private void TracerValveControler()
	{
		upper_valve_hand.SetActive(false);
		lower_valve_rotate_hand.SetActive(false);
		tracer_switch_hand.SetActive(true);
		m_AnimationsControl.TracerSwitchOpenAnimation();
	}

	/*
	 * 离心机开关控制
	 */
	private void CentrifugeControler()
	{
		fuse_hand.SetActive(false);
		lower_valve_rotate_hand.SetActive(false);
		motor_switch_hand.SetActive(true);
		m_AnimationsControl.MotorSwitchOpenAnimation();
		if(isMotorOpen==false)
		{
			m_AudioControl.MotorAudioPlay();
		}
		else
		{
			m_AudioControl.MotorAudioStop();
		}
	}
	/*
	 * 电脑切换场景控制
	 */
	private void ComputerControler()
	{
		m_computer.SwitchToComputerUI();
	}


	/*
	 * 射线检测模块
	 */
	public bool TarRaycast()
	{
		mp = Input.mousePosition;
		targetTransform = null;
		if (m_camera != null)
		{
			RaycastHit hitInfo;
			Ray ray = m_camera.ScreenPointToRay(new Vector3(mp.x, mp.y, 0f));
			if (Physics.Raycast(ray.origin, ray.direction, out hitInfo))
			{
				targetTransform = hitInfo.collider.transform;
				return true;
			}
		}
		return false;
	}

}