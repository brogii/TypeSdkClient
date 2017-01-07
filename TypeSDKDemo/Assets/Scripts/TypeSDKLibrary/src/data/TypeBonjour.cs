using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class TypeBonjour :
#if UNITY_ANDROID
		Bonjour_Type_Common
#elif UNITY_IOS
		Bonjour_Type_Common_IOS
#elif UNITY_STANDALONE_WIN
    Bonjour_Type_Common_Win
#else
	Bonjour_Type_Common_Win
#endif
{
}