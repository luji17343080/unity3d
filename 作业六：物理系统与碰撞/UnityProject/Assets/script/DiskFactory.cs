using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskFactory: MonoBehaviour {
	private int DNum = 0; //目前飞碟数量
	private List<diskInfo> pastdisk = new List<diskInfo>(); //被击中的飞碟链表 
	private List<diskInfo> free = new List<diskInfo>();

	public diskInfo getDisk(int le, bool ifPhysicManager){
		diskInfo Cu_disk = null; //当前飞碟链表信息 
		if (free.Count > 0) {
			Cu_disk = free [0];
			Cu_disk.reset(le);
			pastdisk.Add (free [0]);
			free.Remove (free [0]);

		} else {
			DNum++;
			Cu_disk = new diskInfo (DNum , le, ifPhysicManager);
			pastdisk.Add (Cu_disk);
		}
		return Cu_disk;
	}	

	public void reset(){
		foreach (diskInfo temp in pastdisk) {
			temp.disk.SetActive (false);
			free.Add (temp);
		}
		pastdisk.Clear ();
	}

	public int getUsedDisk(){ //获得已用的飞碟数量 
		return pastdisk.Count;
	}

	public void freeDisk(diskInfo diskinfo){ //将被击中的可用的disk添加到空闲链表中 
		if (pastdisk.Contains (diskinfo)) {
			diskinfo.disk.SetActive (false);
			pastdisk.Remove (diskinfo);
			free.Add (diskinfo);
		}

	}

	public diskInfo getHitDisk(GameObject disk){ //获得被击中的Disk的信息 
		foreach (diskInfo i in pastdisk) {
			if (i.disk == disk) {
				return i;
			}
		}
		return null;
	} 
}
