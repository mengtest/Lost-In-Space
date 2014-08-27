﻿//#define SA_DEBUG_MODE
////////////////////////////////////////////////////////////////////////////////
//  
// @module IOS Native Plugin for Unity3D 
// @author Osipov Stanislav (Stan's Assets) 
// @support stans.assets@gmail.com 
//
////////////////////////////////////////////////////////////////////////////////




using UnityEngine;
using System.Collections;
#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
using System.Runtime.InteropServices;
#endif



public class IOSSharedApplication : ISN_Singleton<IOSSharedApplication> {


	public const string URL_SCHEME_EXISTS = "url_scheme_exists";
	public const string URL_SCHEME_NOT_FOUND  = "url_scheme_not_found";




	#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
	
	[DllImport ("__Internal")]
	private static extern void _ISN_checkUrl(string url);

	[DllImport ("__Internal")]
	private static extern void _ISN_openUrl(string url);
	
	#endif



	//--------------------------------------
	// Public Methods
	//--------------------------------------


	public void CheckUrl(string url) {
		#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
		_ISN_checkUrl(url);
		#endif
	}


	public void OpenUrl(string url) {
		#if (UNITY_IPHONE && !UNITY_EDITOR) || SA_DEBUG_MODE
		_ISN_openUrl(url);
		#endif
	}



	//--------------------------------------
	// Events
	//--------------------------------------


	private void UrlCheckSuccess(string url) {
		dispatch(URL_SCHEME_EXISTS, url);
	}


	private void UrlCheckFailed(string url) {
		dispatch(URL_SCHEME_NOT_FOUND, url);
	}


}
