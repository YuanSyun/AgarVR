using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingTableUsingController : MonoBehaviour {

	public Transform SettingPointer;
	public TableControl Table;

	private int checkingCount = 0;
	public Transform[] CheckingTablePoints;

	private const int TABLE_POINT_NUMBER = 3;
	private List<Vector3> TablePoints = new List<Vector3>();

	private SteamVR_Controller.Device left;
	private SteamVR_Controller.Device right;

	// Use this for initialization
	void Start () {
		
		left = SteamVR_Controller.Input((int)SteamVR_Controller.DeviceRelation.Leftmost);
		right = SteamVR_Controller.Input((int)SteamVR_Controller.DeviceRelation.Rightmost);

	}
	
	// Update is called once per frame
	void Update () {
		
		if(left.GetHairTriggerDown() || right.GetHairTriggerDown())
		{
			TablePoints.Add( SettingPointer.position );
			
			/* Clearing the checking table points */
			if(checkingCount == TABLE_POINT_NUMBER)
			{
				for(int i=0;i<CheckingTablePoints.Length;i++)
				{
					CheckingTablePoints[i].gameObject.SetActive(false);
				}
				checkingCount = 0;
			}

			/* Showing tha checking table points */
			Debug.LogFormat("Debug table point length is {0}, table points count is {1}", CheckingTablePoints.Length, TablePoints.Count);
			if(TablePoints.Count <= TABLE_POINT_NUMBER){
				CheckingTablePoints[TablePoints.Count-1].position = TablePoints[TablePoints.Count-1];
				CheckingTablePoints[TablePoints.Count-1].gameObject.SetActive(true);
				checkingCount++;
			}
			
			/* Scaling the table */
			if(TablePoints.Count == TABLE_POINT_NUMBER)
			{
				Table.SetTable(TablePoints[0], TablePoints[1], TablePoints[2]);
				
				TablePoints.Clear();
			}
		}
	}

	public void DisableThisFun()
	{
		for(int i=0;i<CheckingTablePoints.Length;i++)
		{
			CheckingTablePoints[i].gameObject.SetActive(false);
		}
		this.enabled = false;
	}


}
