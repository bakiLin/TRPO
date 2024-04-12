using System;
using UnityEngine;

namespace ES3Types
{
	[UnityEngine.Scripting.Preserve]
	[ES3PropertiesAttribute("m_YAxis", "m_XAxis")]
	public class ES3UserType_CinemachineFreeLook : ES3ComponentType
	{
		public static ES3Type Instance = null;

		public ES3UserType_CinemachineFreeLook() : base(typeof(Cinemachine.CinemachineFreeLook)){ Instance = this; priority = 1;}


		protected override void WriteComponent(object obj, ES3Writer writer)
		{
			var instance = (Cinemachine.CinemachineFreeLook)obj;
			
			writer.WriteProperty("m_YAxis", instance.m_YAxis, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Cinemachine.AxisState)));
			writer.WriteProperty("m_XAxis", instance.m_XAxis, ES3Internal.ES3TypeMgr.GetOrCreateES3Type(typeof(Cinemachine.AxisState)));
		}

		protected override void ReadComponent<T>(ES3Reader reader, object obj)
		{
			var instance = (Cinemachine.CinemachineFreeLook)obj;
			foreach(string propertyName in reader.Properties)
			{
				switch(propertyName)
				{
					
					case "m_YAxis":
						instance.m_YAxis = reader.Read<Cinemachine.AxisState>();
						break;
					case "m_XAxis":
						instance.m_XAxis = reader.Read<Cinemachine.AxisState>();
						break;
					default:
						reader.Skip();
						break;
				}
			}
		}
	}


	public class ES3UserType_CinemachineFreeLookArray : ES3ArrayType
	{
		public static ES3Type Instance;

		public ES3UserType_CinemachineFreeLookArray() : base(typeof(Cinemachine.CinemachineFreeLook[]), ES3UserType_CinemachineFreeLook.Instance)
		{
			Instance = this;
		}
	}
}