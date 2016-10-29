using UnityEngine;
using System.Collections;
/* 
 * Bonjour_Type_Common_Win为Unity Windows编译环境下使用，仅为了编译不报错，故无具体实现。
 * 具体Ａｎｄｒｏｉｄ、ＩＯＳ有相关实现，接入方无需过多关注，如有疑问请联系提供方。
 * 
 */
#if UNITY_STANDALONE_WIN||UNITY_EDITOR
public class Bonjour_Type_Common_Win : Bonjour_Type_Base
{


        public override void initSDK()
        {
            Debug.Log("CallInitSDK");            
        }

        public override void ShowLogin()
        {
            Debug.Log("CallLogin");
           
        }
        public override void ShowLogin(string loginType)
        {
            Debug.Log("CallYSDKLogin");

        }

        public override void ShowLogout()
        {
            Debug.Log("CallLogout");
           
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
           
            return "";
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
            
        }
        public override U3DTypeBaseData GetUserData()
        {
            Debug.Log("CallUserData");
            U3DTypeBaseData outData = new U3DTypeBaseData();
            return outData;
        }
        public override U3DTypeBaseData GetPlatformData()
        {
            Debug.Log("CallPlatformData");

           
            U3DTypeBaseData outData = new U3DTypeBaseData();
            return outData;

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
