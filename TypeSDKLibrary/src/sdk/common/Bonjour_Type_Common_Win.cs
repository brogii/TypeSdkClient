using UnityEngine;
using System.Collections;
/* 
 * Bonjour_Type_Common_Win为Unity Windows编译环境下使用，仅为了编译不报错，故无具体实现。
 * 具体Ａｎｄｒｏｉｄ、ＩＯＳ有相关实现，接入方无需过多关注，如有疑问请联系提供方。
 * 
 */
#if UNITY_STANDALONE_WIN||UNITY_EDITOR||UNITY_WEBPLAYER
public class Bonjour_Type_Common_Win : Bonjour_Type_Base
{

	private U3DTypeBaseData _win_userInfo = null;
	private U3DTypeBaseData _win_plaform = null;
        public override void initSDK()
        {
            Debug.Log("CallInitSDK");    
			U3DTypeSDK.Instance.NotifyInitFinish ((new U3DTypeBaseData()).DataToString());	
        }

        public override void ShowLogin()
        {
            Debug.Log("CallLogin");
			
		U3DTypeBaseData data = new U3DTypeBaseData ();
		data.SetData(U3DTypeAttName.USER_ID,"testUserID");
		data.SetData(U3DTypeAttName.USER_TOKEN,"testUserToken");

		U3DTypeSDK.Instance.NotifyLogin (data.DataToString ());
           
        }
        public override void ShowLogin(string loginType)
        {
            Debug.Log("CallYSDKLogin");
		U3DTypeBaseData data = new U3DTypeBaseData ();
		data.SetData(U3DTypeAttName.USER_ID,"testUserID");
		data.SetData(U3DTypeAttName.USER_TOKEN,"testUserToken");
		
		U3DTypeSDK.Instance.NotifyLogin (data.DataToString ());
        }

        public override void ShowLogout()


        {
            Debug.Log("CallLogout");
		U3DTypeBaseData data = new U3DTypeBaseData ();
		data.SetData(U3DTypeAttName.USER_ID,"testUserID");
		data.SetData(U3DTypeAttName.USER_TOKEN,"testUserToken");
		
		U3DTypeSDK.Instance.NotifyLogout (data.DataToString ());
        }
        public override void ShowPersonCenter()
        {
            Debug.Log("CallPersonCenter");

           
        }
        public override void HidePersonCenter()
        {
            Debug.Log("CallHidePersonCenter");

           
        }
        public override void ShowToolBar()
        {
            Debug.Log("CallToolBar");

           
        }
        public override void HideToolBar()
        {
            Debug.Log("CallHideToolBar");

            
        }
        public override string PayItem(U3DTypeBaseData _in_pay)
        {
            Debug.Log("CallPayItem" + "data: " + _in_pay.DataToString());
           
		U3DTypeBaseData data = new U3DTypeBaseData ();
		data.SetData(U3DTypeAttName.PAY_RESULT,"1");
		data.SetData(U3DTypeAttName.PAY_RESULT_DATA,"testSuccess");
		
		U3DTypeSDK.Instance.NotifyPayResult (data.DataToString ());

            return "test return billno";
        }
        public override int LoginState()
        {
            Debug.Log("CallLoginState");            
            return 0;
        }
        public override void ShowShare(U3DTypeBaseData _in_data)
        {
            Debug.Log("CallShare" + "data: " + _in_data.DataToString());

        }
        public override void SetPlayerInfo(U3DTypeBaseData _in_data)
        {
            Debug.Log("CallSetPlayerInfo" + " data :" + _in_data.DataToString());
            
			_win_userInfo = _in_data;
        }
        public override U3DTypeBaseData GetUserData()
        {
            Debug.Log("CallUserData");
			if (_win_userInfo == null) 
		{
			_win_userInfo = new U3DTypeBaseData();
			_win_userInfo.SetData(U3DTypeAttName.SDK_NAME,"test");
			_win_userInfo.SetData(U3DTypeAttName.USER_ID,"testUserID_default");
			_win_userInfo.SetData(U3DTypeAttName.USER_TOKEN,"testUserToken_default");
		}

            return _win_userInfo;
        }
        public override U3DTypeBaseData GetPlatformData()
        {
            Debug.Log("CallPlatformData");

          	if (null == _win_plaform) 
		{
			_win_plaform = new U3DTypeBaseData();
			_win_plaform.SetData(U3DTypeAttName.SDK_NAME,"test");
			_win_plaform.SetData(U3DTypeAttName.CHANNEL_ID,"1234567");
			_win_plaform.SetData(U3DTypeAttName.CP_ID,"123");

		}
            return _win_plaform;

        }

        public override void CopyClipboard(U3DTypeBaseData _in_data)
        {
            Debug.Log("CallLogout" + " data: " + _in_data.DataToString());

            
        }
        public override bool IsHasRequest(string requestType)
        {
            Debug.Log("IsHasRequest" + " type " + requestType);           
            return true;
        }
        public override void Destory()
        {
            Debug.Log("CallDestory");

            
        }
        public override void ExitGame()
        {
            Debug.Log("ExitGame");
        }

        /**call any undefine function if success or return error*/
        public override string DoAnyFunction(string funcName, U3DTypeBaseData _in_data)
        {
            Debug.Log("DoAnyFunction");
            return "";
        }

        public override string DoPhoneInfo()
        {
            Debug.Log("DoPhoneInfo");

            return "";
        }

        public override void AddLocalPush(U3DTypeBaseData _push_data)
        {
            Debug.Log("AddLocalPush");

        }
        public override void RemoveLocalPush(string pushid)
        {
            Debug.Log("RemoveLocalPush");

        }
        public override void RemoveAllLocalPush()
        {
            Debug.Log("RemoveLocalPush");
          
        }
        public override void GetUserFriends()
        {
            Debug.Log("GetUserFriends");
           
        }

}
#endif
