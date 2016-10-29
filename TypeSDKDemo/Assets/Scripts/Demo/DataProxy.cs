using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TypeSDKTool;

namespace TypeDataModel
{
   	public class DataProxy: MonoBehaviour
    {
        private static volatile DataProxy _instance;
        private static object syncRoot = new object();
        private static GameObject _container;

		private  ServerDataExchange _ServerLogic;
		private LocalDataLogic _LocalLogic;

        public static DataProxy Ins
        {
            get
            {
                if (null == _instance)
                {
                    _container = new GameObject();
                    _container.name = "DataProxy";
                    UnityEngine.Object.DontDestroyOnLoad(_container);
                    lock (syncRoot)
                    {
                        if (null == _instance)
                        {
                            _instance = _container.AddComponent(typeof(DataProxy)) as DataProxy;
                        }
                    }
                }

                return _instance;
            }
        }
		

		public ServerDataExchange ServerLogic
		{
			get
			{
				if(null == _instance. _ServerLogic)
				{
					_instance._ServerLogic = new ServerDataExchange();
				}
				return _ServerLogic;
			}
		}
		public LocalDataLogic LocalLogic
		{
			get
			{
				if(null == _instance._LocalLogic)
				{
					_instance._LocalLogic = new LocalDataLogic();
				}
				return _LocalLogic;
			}
		}
		public 	string changeBaseDataToHttpData(U3DTypeBaseData _in_data)
		{
			Dictionary<string, object> attMap = _in_data.attMap ();
			string outString  = "";
			foreach (string key in attMap.Keys)
			{
				if ("data_ins_key" == key)
					continue;
				
				outString += "&"+key+"="+attMap[key].ToString();
			}
			outString = "?" + outString.Substring (1);
			return outString;
			
		}
    }

	public class LocalDataLogic:MonoBehaviour
	{
		private U3DTypeBaseData _platform = null;
		private U3DTypeBaseData _userInfo = null;

		public U3DTypeBaseData platform()
		{
			if (null ==_platform) 
			{
				_platform = U3DTypeSDK.Instance.GetPlatformData();
			}
			return _platform;
		}
		public U3DTypeBaseData userInfo()
		{
			if (null == _userInfo) 
			{
				_userInfo = U3DTypeSDK.Instance.GetUserData();
			}
			return _userInfo;
		}
	}
	public class ServerDataExchange : MonoBehaviour
    {
		private const string REQUEST_ADDRESS = "http://120.27.201.22:40001/game";
		


		public void RequestLogin(MonoBehaviour mono, string  data,TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/login";
			Debug.Log("RequestLogin " + url);
				
			mono.StartCoroutine( HttpGet(url+data, cbkdelegate, crossData) );
		}
		public void RequestCreateOrder(MonoBehaviour mono, string data,TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/create_order";
            Debug.Log("RequestCreateOrder " + url);
            mono.StartCoroutine(HttpGet(url+ data, cbkdelegate, crossData));
		}
		public void RequestClinetPayCancel(MonoBehaviour mono, string data, TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/client_pay_cancel";
            mono.StartCoroutine(HttpGet(url + data, cbkdelegate, crossData));
        }
		public void RequestClientPayComplete(MonoBehaviour mono, string data,TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/client_pay_complete";
            mono.StartCoroutine(HttpGet(url + data, cbkdelegate, crossData));
        }
		public void RequestGetAccount(MonoBehaviour mono, string data,TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/get_account";
            mono.StartCoroutine(HttpGet(url + data, cbkdelegate, crossData));
        }
		public void RequestCreateAccount(MonoBehaviour mono, string data,TypeHttpCBKDelegate cbkdelegate,UnityEngine.Object crossData)
		{
			string url = REQUEST_ADDRESS+"/create_account";
            mono.StartCoroutine(HttpGet(url + data, cbkdelegate, crossData));
        }


		public void LoginCBK(string cbkTxt,UnityEngine.Object crossData)
        {
			 
        }
		public void CreateOrderCBK(string cbkTxt, UnityEngine.Object crossData)
        {

        }
		public void ClinetPayCancelCBK(string cbkTxt, UnityEngine.Object crossData)
        {

        }
		public void ClientPayCompleteCBK(string cbkTxt, UnityEngine.Object crossData)
        {

        }
		public void GetAccountCBK(string cbkTxt, UnityEngine.Object crossData)
        {

        }
		public void CreateAccountCBK(string cbkTxt, UnityEngine.Object crossData)
        {

        }


		//GET请求
		public IEnumerator HttpGet(string url, TypeHttpCBKDelegate cbkFunc, UnityEngine.Object crossData )
		{
            Debug.Log("Http Get URL " + url);
			
			WWW getData = new WWW (url);
			yield return getData;
			
			if (getData.error != null)
			{
				//GET请求失败
				Debug.Log("error is :"+ getData.error);
				cbkFunc(getData.error, crossData);
				
			} else
			{
				//GET请求成功
				Debug.Log("request ok : " + getData.text);
				cbkFunc(getData.text, crossData);
			}
		}

		public IEnumerator HttpPost(string url,Dictionary<string,string> postData,TypeHttpCBKDelegate cbkFunc, UnityEngine.Object crossData)
		{
			Debug.Log("create wwwform");
			WWWForm form = new WWWForm();
		
			foreach(string key in postData.Keys)
			{
				Debug.Log("read post data add "+postData[key]);
				form.AddField(key, postData[key]);
			}
			Debug.Log("create form finish");

			Debug.Log("start httppost :"+ url);
			WWW getData = new WWW(url, form);
			
			yield return getData;
			
			if (getData.error != null)
			{
				//GET请求失败
				Debug.Log("error is :" + getData.error);
				cbkFunc(getData.error, crossData);
			}
			else
			{
				//GET请求成功
				Debug.Log("request ok : " + getData.text);
				cbkFunc(getData.text, crossData);
			}
		}

    }

}
