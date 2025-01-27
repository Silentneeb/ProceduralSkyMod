﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

// OnPreCull used to override VR HMD tracking
// https://forum.unity.com/threads/how-to-disable-hmd-movement-for-second-camera.482468/#post-4282909
namespace ProceduralSkyMod
{
	public class SkyCamConstraint : MonoBehaviour
	{
		public Camera main;
		public Camera sky;
		public Camera clear;

		void OnPreCull()
		{
			clear.transform.rotation = sky.transform.parent.rotation = main.transform.rotation;
			sky.transform.localRotation = Quaternion.identity;
			clear.transform.position = main.transform.position;
			clear.fieldOfView = sky.fieldOfView = main.fieldOfView;
		}
	}

	public class PositionConstraintOnPreCull : MonoBehaviour
	{
		public Transform source = null;
		public Transform target = null;

		void OnPreCull ()
		{
			if (source == null) return;
			if (target == null) transform.position = source.transform.position;
			else target.transform.position = source.transform.position;
		}
	}

	public class PositionConstraintOnUpdate : MonoBehaviour
	{
		public Transform source = null;
		public Transform target = null;

		void Update ()
		{
			if (source == null) return;
			if (target == null) transform.position = source.transform.position;
			else target.transform.position = source.transform.position;
		}
	}

	public class LookAtConstraintOnPreCull : MonoBehaviour
    {
		public Transform actor = null;
		public Transform target = null;
		public Vector3 offset = Vector3.zero;
		//public Transform upSource = null;

		void OnPreCull ()
        {
			if (target == null) return;
			if (actor == null) transform.LookAt(target.position + offset, transform.up);
			else actor.transform.LookAt(target.position + offset, actor.transform.up);
        }
    }
}
