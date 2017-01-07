using UnityEngine;
using System.Collections;
using TypeSDKTool;
using TypeDataModel;
using System.Collections.Generic;
//using System.Web;

using System.Linq;

public class MainScene : MonoBehaviour
{
    private const int UI_DEFAULT = 0;
    private const int UI_LOGIN = 1;
    private const int UI_PAYMENT = 2;
    private const int UI_USERCENTER = 3;
//    private const int UI_SYSTEM_TOOLS = 4;
//    private const int UI_SHARE = 5;
    private const int UI_MENU = 6;
//    private const int UI_PAYMENT_ORDER = 7;//订单创建
	private const int UI_INIT_LOADING = 8;
	private const int UI_IN_LINE = 9;
    private const int INDEX_MESSAGE_LOCATION = 5;

    private int current_ui_model;
    private int att_fontsize;
    private Rect [] arr_LOCATION  ;

	private string messageStr = @"message";

//    private string input_str_order_pirce;
//    private string input_str_order_item_id;
    
    private U3DTypeBaseData localPayData;
    private U3DTypeBaseData localUserData;
    //等待支付到账
    private int userBalance;
	private int datalock_pay_progress;
    MainScene()
    {
        current_ui_model =UI_INIT_LOADING;
//        input_str_order_item_id = "购买商品ID";
//        input_str_order_pirce = "商品价格（分）";

        localPayData = new U3DTypeBaseData(); ;
        localUserData = new U3DTypeBaseData();
		datalock_pay_progress = 0;
        userBalance = 0;
		att_fontsize = 10;


    }
    
	void Start()
	{
		//设置屏幕自动旋转， 并置支持的方向
		
		Screen . orientation = ScreenOrientation . AutoRotation ;
		
		Screen . autorotateToLandscapeLeft = true ;
		
		Screen . autorotateToLandscapeRight = true ;
		
		Screen . autorotateToPortrait = false ;
		
		Screen . autorotateToPortraitUpsideDown = false ;


		#if UNITY_STANDALONE_WIN
		return;
		#endif

		RegistCallBackFunctions ();

		U3DTypeSDK.Instance.InitSDK();


	}
	void Update()
	{
		ActionKeyBoardEvent ();
	}
	void modifyArrlocation()
	{
        
		float btnW = Screen.width / 3;
		float btnH = Screen.height / 8;

        
		if (btnH > btnW / 3)
			btnH = btnW / 3;

		float startX = Screen.width /2 -Screen.width/6;
		float startY = Screen.height / 60;
		arr_LOCATION = new Rect[11] ;
		
		for (int i = 0; i<6; ++i) 
		{
			arr_LOCATION[i].x =  startX;
			arr_LOCATION[i].y = btnH + (startY + btnH)*i;
			arr_LOCATION[i].width = btnW;
			arr_LOCATION[i].height = btnH;
		}
        arr_LOCATION[INDEX_MESSAGE_LOCATION].width = btnW * 3;
        arr_LOCATION[INDEX_MESSAGE_LOCATION].x = 0;

        att_fontsize = (int)(btnH * 0.8);
	}
    void OnGUI()
    {
		modifyArrlocation ();

        switch(current_ui_model)
        {
			case UI_INIT_LOADING:
				RenderInitLoading();
			break;
            case UI_MENU:
                RenderMenu();
                break;
            case UI_LOGIN:
                RendeLogin();
                break;
            case UI_PAYMENT:
                RenderPayment();
                break;

            case UI_USERCENTER:
                RenderUserCenter();
                break;
			case UI_IN_LINE:
				RenderInline();
				break;
            default:
                RenderMenu();
                break;
              

        }
        return;

    }


	/// <summary>
	////render functions.
	/// </summary>
	void RenderInitLoading()
	{
		GUI.skin.button.fontSize = att_fontsize;
		//调用登录
		GUI.Button (arr_LOCATION [2], "Loading");
	}
    void RenderDefault()
    {
        RenderMenu();
    }
    void RenderMenu()
    {
        messageStr = "msg is null";
        GUI.skin.button.fontSize = att_fontsize;
//        //调用登录
//		if (GUI.Button(arr_LOCATION[1], "登录"))
//        {
//            current_ui_model = UI_LOGIN;
//        }
	
		if (GUI.Button(arr_LOCATION[1], "购买商品"))
		{
			current_ui_model = UI_PAYMENT;
		}
	    //调用登录
		if (GUI.Button(arr_LOCATION[2], "用户信息"))
	    {
	        current_ui_model = UI_USERCENTER;
	    }
		if (GUI.Button(arr_LOCATION[3], "登出"))
		{
			U3DTypeSDK.Instance.Logout();
		}


    }
    void RendeLogin()
    {

        GUI.skin.button.fontSize = att_fontsize;
        GUI.skin.textField.fontSize = att_fontsize;

        //调用登录
        if (GUI.Button(arr_LOCATION[2],"登录"))
        {
			U3DTypeSDK.Instance.RemoveEventDelegate(TypeEventType.EVENT_LOGIN_SUCCESS);
			U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_LOGIN_SUCCESS,LoginResult);

            U3DTypeSDK.Instance.Login();
        }



    }
    void RenderPayment()
    {
        GUI.skin.button.fontSize = att_fontsize;
        GUI.skin.textField.fontSize = att_fontsize;

        int i = 0;

		if (GUI.Button(arr_LOCATION[i++], "支付1元"))
        {
			ActionCreatePayOrder("1","100");
        }

		if (GUI.Button(arr_LOCATION[i++], "支付2元"))
		{
			ActionCreatePayOrder("2","200");
		}
		if (GUI.Button(arr_LOCATION[i++], "支付3元"))
		{
			ActionCreatePayOrder("3","300");
		}

        //返回菜单
        if (GUI.Button(arr_LOCATION[i++],">>>返回主菜单<<<"))
        {
            current_ui_model = UI_MENU;
        }

        GUI.TextField(arr_LOCATION[INDEX_MESSAGE_LOCATION], messageStr, 300);
    }

	int inline_i_a = 0;

    void RenderUserCenter()
    {
        GUI.skin.button.fontSize = att_fontsize;
        GUI.skin.textField.fontSize = att_fontsize;

        int i = 1;
        if (GUI.Button(arr_LOCATION[i++], "获取用户信息"))
        {
			inline_i_a++;
			if(inline_i_a>=5)
			{
				inline_i_a = 0;
				current_ui_model = UI_IN_LINE;
				return;
			}

            ActionGetAccount();

        }
        //返回菜单
        if (GUI.Button(arr_LOCATION[i++], ">>>返回主菜单<<<"))
        {
            current_ui_model = UI_MENU;
        }


        GUI.TextField(arr_LOCATION[INDEX_MESSAGE_LOCATION], messageStr, 300);
    }
	string inline_s_a ="";
	string inline_s_b ="{}";
	void RenderInline()
	{
		int i = 1;
		inline_s_a =  GUI.TextField(arr_LOCATION[i++], inline_s_a, 300);
		inline_s_b =  GUI.TextField(arr_LOCATION[i++], inline_s_b, 300);

		if (GUI.Button(arr_LOCATION[i++], ">>>inline<<<"))
		{
			U3DTypeBaseData data = new U3DTypeBaseData();
			data.StringToData(inline_s_b);
			U3DTypeSDK.Instance.DoAnyFunction(inline_s_a,data);
		}

		if (GUI.Button(arr_LOCATION[i++], ">>>返回主菜单<<<"))
		{
			current_ui_model = UI_MENU;
		}

	}
//    void RenderPaymentOrder()
//    {
//        GUI.skin.button.fontSize = att_fontsize;
//        GUI.skin.textField.fontSize = att_fontsize;
//
//        //创建商品价格
////        input_str_order_pirce = GUI.TextField(arr_LOCATION[0], input_str_order_pirce, 30);//30为最大字符串长度  
//        //商品ID
////        input_str_order_item_id = GUI.TextField(arr_LOCATION[1], input_str_order_item_id, 30);//30为最大字符串长度  
//        //调用登录
//
////        if (GUI.Button(arr_LOCATION[2], "创建订单"))
////        {
////            U3DTypeBaseData data = DataProxy.Ins.LocalLogic.userInfo();
////
////
////            string userName = data.GetData(U3DTypeAttName.USER_NAME);
////            string userID = data.GetData(U3DTypeAttName.USER_ID);
////            string userToken = data.GetData(U3DTypeAttName.USER_TOKEN);
////
////
////            U3DTypeBaseData platform = DataProxy.Ins.LocalLogic.platform();
////            U3DTypeBaseData baseData = new U3DTypeBaseData();
////            baseData.SetData("uid", userID);
////            baseData.SetData("pid", input_str_order_item_id);
////            baseData.SetData("sid", "1");
////            baseData.SetData("cid", platform.GetData(U3DTypeAttName.CHANNEL_ID));
////            baseData.freshSign();
////
////			string dataArr = changeBaseDataToHttpData (baseData);
////
////            localPayData.SetData(U3DTypeAttName.USER_ID, userID);
////            localPayData.SetData(U3DTypeAttName.ITEM_SERVER_ID, input_str_order_item_id);
////            localPayData.SetData(U3DTypeAttName.REAL_PRICE, input_str_order_pirce);
////
////            Debug.Log("local pay data change to "+ localPayData.DataToString());
////            Debug.Log("login sent to server data " + baseData.DataToString());
////            DataProxy.Ins.ServerLogic.RequestCreateOrder(this, dataArr, ServerCBK_createOrder, null);
////        }
//        //返回菜单
//        if (GUI.Button(arr_LOCATION[3], ">>>返回上级菜单<<<"))
//        {
//
//            current_ui_model = UI_PAYMENT;
//        }
//
//        GUI.TextField(arr_LOCATION[INDEX_MESSAGE_LOCATION], messageStr, 50);
//    }

    void RegistCallBackFunctions()
    {
		U3DTypeSDK.Instance.AddEventDelegate (TypeEventType.EVENT_INIT_FINISH, InitFinishResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_LOGIN_SUCCESS, LoginResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_PAY_RESULT, PayResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_LOGOUT, LogoutResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.EVENT_RELOGIN, LoginResult);
        U3DTypeSDK.Instance.AddEventDelegate(TypeEventType.Event_EXTRA_FUNCTION, Extrafunction);
    }
    
	/// <summary>
	/// 单独的小功能
	/// </summary>
    void ActionGetAccount()
    {
        U3DTypeBaseData data = DataProxy.Ins.LocalLogic.userInfo();

        string userID = data.GetData(U3DTypeAttName.USER_ID);
        U3DTypeBaseData platform = DataProxy.Ins.LocalLogic.platform();
        U3DTypeBaseData baseData = new U3DTypeBaseData();
        baseData.SetData("uid", userID);
        baseData.SetData("sid", "1");
        baseData.SetData("cid", platform.GetData(U3DTypeAttName.CHANNEL_ID));
//        baseData.freshSign();

		string dataArr = changeBaseDataToHttpData (baseData);;
        DataProxy.Ins.ServerLogic.RequestGetAccount(this, dataArr, ServerCBK_getAccount, null);
    }
    void AcitonCreatAccount()
    {
        U3DTypeBaseData userInfo = DataProxy.Ins.LocalLogic.userInfo();
        string userID = userInfo.GetData(U3DTypeAttName.USER_ID);
        U3DTypeBaseData platform = DataProxy.Ins.LocalLogic.platform();
        U3DTypeBaseData baseData = new U3DTypeBaseData();
        baseData.SetData("uid", userID);
        baseData.SetData("sid", "1");
        baseData.SetData("cid", platform.GetData(U3DTypeAttName.CHANNEL_ID));
//        baseData.freshSign();

		string dataArr = changeBaseDataToHttpData (baseData);
        DataProxy.Ins.ServerLogic.RequestCreateAccount(this, dataArr, ServerCBK_createAccount, null);
    }
	void ActionCreatePayOrder(string _in_item_id,string _in_item_price)
	{

		U3DTypeBaseData data = DataProxy.Ins.LocalLogic.userInfo();

//		string userName = data.GetData(U3DTypeAttName.USER_NAME);
		string userID = data.GetData(U3DTypeAttName.USER_ID);
//		string userToken = data.GetData(U3DTypeAttName.USER_TOKEN);
		
		
		U3DTypeBaseData platform = DataProxy.Ins.LocalLogic.platform();
		U3DTypeBaseData baseData = new U3DTypeBaseData();
		baseData.SetData("uid", userID);
		baseData.SetData("pid", _in_item_id);
		baseData.SetData("sid", "1");
		baseData.SetData("cid", platform.GetData(U3DTypeAttName.CHANNEL_ID));
//		baseData.freshSign();
		
		string dataArr = changeBaseDataToHttpData (baseData);
		
		localPayData.SetData(U3DTypeAttName.USER_ID, userID);
		localPayData.SetData(U3DTypeAttName.ITEM_SERVER_ID, _in_item_id);
		localPayData.SetData(U3DTypeAttName.REAL_PRICE, _in_item_price);
		
		Debug.Log("local pay data change to "+ localPayData.DataToString());
		Debug.Log("login sent to server data " + baseData.DataToString());
		DataProxy.Ins.ServerLogic.RequestCreateOrder(this, dataArr, ServerCBK_createOrder, null);

	}
	void ActionPayCurrentOrder()
	{
		if (0 != datalock_pay_progress) 
		{
			Debug.Log("wait pay finish");
			return;
		}
		U3DTypeBaseData userInfo = U3DTypeSDK.Instance.GetUserData();
		U3DTypeBaseData payData = localPayData;
		//用户ID，渠道返回，没有填空
		
		//商品支付价格（单位：分）
		
		//商品名称
		payData.SetData(U3DTypeAttName.ITEM_NAME, "TwinkleItem");
		//商品数量
		payData.SetData(U3DTypeAttName.ITEM_COUNT, "1");
		//所在服务器id（如果没有填“0”）
		
		//所在服务器名字（如果没有填“sever_name”）
		payData.SetData(U3DTypeAttName.SERVER_NAME, "安卓一区");
		//内部订单号（如果没有填“0”）
		
		//商品在渠道上的id（如果没有填“0”）如果大于0 认为是购买商品 
		//has setted by function:ActionCreate ActionCreatePayOrder
		
		//商品描述
		payData.SetData(U3DTypeAttName.ITEM_DESC, "desc");
		//玩家在游戏中的角色ID
		payData.SetData(U3DTypeAttName.ROLE_ID, "role_1234");
		//玩家在游戏中的角色名字
		payData.SetData(U3DTypeAttName.ROLE_NAME, "玩家编号001");
		//传递的额外参数（建议传入需要用来做订单标识的信息）
		payData.SetData(U3DTypeAttName.EXTRA, "extra");
		
		payData.SetData(U3DTypeAttName.USER_ID,userInfo.GetData(U3DTypeAttName.USER_ID));
		U3DTypeSDK.Instance.PayItem(payData);

		datalock_pay_progress = 1;

	}
	void ActionKeyBoardEvent()
	{
		// 返回键
		
//		if ( Application.platform == RuntimePlatform.Android)
		{
			if(Input.GetKeyDown(KeyCode.Escape))
			{
			//....
				Debug.Log("key down escape");
				U3DTypeSDK.Instance.ExitGame();
			}
			else if(Input.GetKeyDown(KeyCode.Return))
			{
				Debug.Log("key down Return");
				U3DTypeSDK.Instance.ExitGame();
			}
		
			else if(Input.GetKeyDown(KeyCode.Home))
			{
				Debug.Log("key down home");
			}

		}
	}

	string changeBaseDataToHttpData(U3DTypeBaseData _in_data)
	{
		Dictionary<string, object> attMap = _in_data.attMap ();
		string outString  = "";
		foreach (string key in attMap.Keys)
		{
			if ("data_ins_key" == key)
				continue;
			
			outString += "&"+key+"="+attMap[key].ToString();
		}
		outString = "?" + outString.Substring (1)+"&sign=sign" ;
		return outString;

	}

	//
    //cbk functions
	//
	void InitFinishResult(U3DTypeEvent evt)
	{
		Debug.Log("receive u3d init finish");
		current_ui_model = UI_LOGIN;
	}
    void LoginResult(U3DTypeEvent evt)
    {
		Debug.Log("LoginResult");

        U3DTypeBaseData data = evt.evtData;

	
        //string userName = data.GetData(U3DTypeAttName.USER_NAME);
        string userID = data.GetData(U3DTypeAttName.USER_ID);
        string userToken = data.GetData(U3DTypeAttName.USER_TOKEN);

//		Dictionary<string,string> dataArr = new Dictionary<string,string> ();

		U3DTypeBaseData platform = U3DTypeSDK.Instance.GetPlatformData();

		U3DTypeBaseData baseData = new U3DTypeBaseData ();
		baseData.SetData ("id", userID);
		baseData.SetData ("token", userToken);
		baseData.SetData ("data", "");
		baseData.SetData("cid",platform.GetData(U3DTypeAttName.CHANNEL_ID));
//		baseData.SetData ("sign", userID + "|" + userToken + "|" + ""+"|"+platform.GetData(U3DTypeAttName.CHANNEL_ID));

		string dataArr = changeBaseDataToHttpData (baseData);
		Debug.Log ("login sent to server data " + dataArr);

		DataProxy.Ins.ServerLogic.RequestLogin (this,dataArr, ServerCBK_login, null);
        //send user info to server and exchange playerinfo;
    }
    void ReloginResult(U3DTypeEvent evt)
    {
        Debug.Log("ReLoginResult");
        LoginResult(evt);
    }
    void PayResult(U3DTypeEvent evt)
    {
        U3DTypeBaseData data = evt.evtData;

		datalock_pay_progress = 0;

        bool paySuccess = data.GetBool(U3DTypeAttName.PAY_RESULT);
        if(paySuccess)
        {
            StartRepeatRequestIntoAccount();
        }
    }
    void LogoutResult(U3DTypeEvent evt)
    {
        current_ui_model = UI_LOGIN;
    }
    void Extrafunction(U3DTypeEvent evt)
    {
		Debug.Log ("unityr receive 额外函数" +evt.evtData.DataToString ());
        TypeSDKTool.AlartMessage.ShowMessage("额外函数", evt.evtData.DataToString());
		U3DTypeBaseData evtData = evt.evtData;
		string func_key = evtData.GetData (U3DTypeAttName.EXTERN_FUNCTION_KEY);
		string data_1 = evtData.GetData (U3DTypeAttName.EXTERN_FUNCTION_VALUE);
//		string data_2 = evtData.GetData (U3DTypeAttName.EXTERN_FUNCTION_VALUE_2);
		switch (func_key) 
		{
		case "http_get":
			{
			this.StartCoroutine(DataProxy.Ins.ServerLogic.HttpGet(data_1,ServerCBK_CommonShowMSG,null));
			}
			break;
		case "http_post":
			{
			DataProxy.Ins.ServerLogic.HttpPost(data_1,new Dictionary<string, object>(),ServerCBK_CommonShowMSG,null);
			break;
			}
		}
    }

    void StartRepeatRequestIntoAccount()
    {
        if (IsInvoking("RepeatRequestIntoAccountFunction"))
            return;

        InvokeRepeating("RepeatRequestIntoAccountFunction", 1.0f,1000);
        Debug.Log("InvokeRepeating");
    }
    void StopRepeatRequestIntoAccount()
    {
        CancelInvoke("RepeatRequestIntoAccountFunction");
        Debug.Log("CancelInvoke");
    }
    void RepeatRequestIntoAccountFunction()
    {
        ActionGetAccount();
        Debug.Log("do ActionGetAccount");
    }
    Dictionary<string,object> getUserDataMap()
    {
        Dictionary<string, object> dataMap = (Dictionary<string, object>)localUserData.attMap()["data"];
        return dataMap;
    }
    int getUserBalance()
    {
        Dictionary<string, object> dataMap = getUserDataMap();
        if (dataMap.ContainsKey("balance"))
        {
            return int.Parse((string)dataMap["balance"]);
        }
        else
        {
            return 0;
        }
    }

	//
    /////server logic///////
	/// ;
    void ServerCBK_login(string data,UnityEngine.Object crossData)
	{
        U3DTypeBaseData result = new U3DTypeBaseData();
        result.StringToData(data);
		if (null == result.attMap()) 
		{
			Debug.Log("error string to data in server cbk login");
		}
		if (null != result && "" != result.GetData("uid"))
        {
            U3DTypeBaseData userinfo = U3DTypeSDK.Instance.GetUserData();
            userinfo.SetData(U3DTypeAttName.USER_ID, result.GetData("uid"));
			userinfo.SetData(U3DTypeAttName.USER_TOKEN, result.GetData("token"));
            U3DTypeSDK.Instance.UpdatePlayerInfo();
            ActionGetAccount();
        }
		current_ui_model = UI_MENU; // go to menu 
        messageStr = data;
	}
    void ServerCBK_getAccount(string data, UnityEngine.Object crossData)
    {
        U3DTypeBaseData result = new U3DTypeBaseData();
        result.StringToData(data);
        if (null != result )
        {
            if(0 != result.GetInt("code"))
            {
                AcitonCreatAccount();
            }
            else
            {
                localUserData.SetData(U3DTypeAttName.USER_ID, result.GetData("uid"));
				localUserData.SetData(U3DTypeAttName.USER_TOKEN, result.GetData("token"));

				//以下内容请开发者如实填写实际内容，demo仅供参考
				//如果没有该内容，请填"0"
				localUserData.SetData(U3DTypeAttName.ROLE_TYPE,"createRole");
				localUserData.SetData(U3DTypeAttName.SAVED_BALANCE,"0");
				localUserData.SetData(U3DTypeAttName.USER_NAME,"qudaoyonghu_001");
				localUserData.SetData(U3DTypeAttName.USER_HEAD_ID,"head_001");
				localUserData.SetData(U3DTypeAttName.USER_HEAD_URL,"head_url_001");
				localUserData.SetData(U3DTypeAttName.VIP_LEVEL,"v10");
				localUserData.SetData(U3DTypeAttName.PARTY_NAME,"gonghui");
				localUserData.SetData(U3DTypeAttName.ROLE_ID,"role_001");
				localUserData.SetData(U3DTypeAttName.ROLE_NAME,"role_name_001");
				localUserData.SetData(U3DTypeAttName.ROLE_LEVEL,"99");
				localUserData.SetData(U3DTypeAttName.ROLE_CREATE_TIME,"1234567890");
				localUserData.SetData(U3DTypeAttName.ROLE_LEVELUP_TIME,"2345678901");
				localUserData.SetData(U3DTypeAttName.ZONE_ID,"zone_1");
				localUserData.SetData(U3DTypeAttName.SERVER_ID,"server_1");
				localUserData.SetData(U3DTypeAttName.SERVER_NAME,"server_name");
				localUserData.SetData(U3DTypeAttName.EXTRA,"1");
				//end

				localUserData.attMap()["data"] = result.attMap()["data"];

                int tempBalance = getUserBalance();
                if(userBalance != tempBalance)
                {
                    StopRepeatRequestIntoAccount();
                    userBalance = tempBalance;
                }
                messageStr = "id " + result.GetData("uid") + "update余额 " + userBalance;
            }
        }
    }
    void ServerCBK_createAccount(string data, UnityEngine.Object crossData)
    {
        messageStr = "create account success";
    }
    void ServerCBK_createOrder(string data, UnityEngine.Object crossData)
    {
        U3DTypeBaseData result = new U3DTypeBaseData();
        result.StringToData(data); 
        if(null != result && ""!=result.GetData("oid"))
        {
            localPayData.SetData(U3DTypeAttName.BILL_NUMBER, result.GetData("oid"));
        }
        
        messageStr = data;

		//pay bill
		this.ActionPayCurrentOrder ();
    }
    void ServerCBK_payResult(string data, UnityEngine.Object crossData)
    {

    }
    void ServerCBK_CommonShowMSG(string data, UnityEngine.Object crossData)
    {
        messageStr = data;
    }



}
