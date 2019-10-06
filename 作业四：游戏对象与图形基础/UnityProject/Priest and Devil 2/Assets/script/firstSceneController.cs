using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using baseCode;


public class firstSceneController : MonoBehaviour , sceneController , firstScenceUserAction{
	public CCActionManager actionManager;
	public Judge judge;

	environmentController environment;  //环境事物：岸边和河 
	boatController myBoat ;	//船 
	const int numOfPirestOrDevil = 3;
	peopleController[] peopleCtrl  = new peopleController[numOfPirestOrDevil * 2]; //恶魔牧师 
	string oriSize = "right";
	FirstSceneGuiCtrl guiCtrl;
	/*环境位置*/ 
	Vector3 environmentPos = Vector3.zero; 
	Vector3 leftShorePos = new Vector3 (-6f, 2f, 0f);
	Vector3 rightShorePos = new Vector3 (6f, 2f, 0f);
	string gameStatus = "playing";
	void Awake(){ //预制实例化 
		Director.getInstance ().currentSceneController = this;
		guiCtrl = gameObject.AddComponent <FirstSceneGuiCtrl>() as FirstSceneGuiCtrl;
		loadResources();

	}
	// Use this for initialization
	void Start () {

	}

	void Update(){ //游戏状态设置 
		int leftDevil = 0, leftPriest = 0, rightDevil = 0, rightPriest = 0 , leftShorePeople = 0;
		for (int loop = 0; loop < numOfPirestOrDevil * 2; loop++) {
			if (peopleCtrl [loop].getStatus() == "shore" && peopleCtrl [loop].size == "left") {
				leftShorePeople++;
			} 
			if (peopleCtrl [loop].getName()[0] == 'd' && peopleCtrl [loop].size == "left") {
				leftDevil++;
			} else if (peopleCtrl [loop].getName()[0] == 'd' && peopleCtrl [loop].size == "right") {
				rightDevil++;
			} else if (peopleCtrl [loop].getName()[0] == 'p' && peopleCtrl [loop].size == "left") {
				leftPriest++;
			} else {
				rightPriest++;
			}
		}
		if ((leftDevil > leftPriest && leftPriest != 0) || (rightPriest != 0 && rightDevil > rightPriest)) {
			judge.setStatus("lost");
		}
		else if (leftShorePeople == 6) {
			judge.setStatus("win");
		}
	}

	public string getStatus(){
		return judge.getStatus();
	}

	public void reset(){ //游戏重置 
		gameStatus = "playing";
		for (int loop = 0; loop < numOfPirestOrDevil * 2; loop++) {
			peopleCtrl [loop].reset(environment, actionManager);
		}
		myBoat.reset (actionManager);
	}


	public void loadResources(){ //加载预制 
		environment = new environmentController();
		myBoat = new boatController ( oriSize );

		for (int loop = 0; loop < numOfPirestOrDevil; loop++) {
			peopleCtrl [loop] = new peopleController ("devil" , loop , environment.getPosVec(oriSize , loop) , "shore" , oriSize);
		}

		for (int loop = numOfPirestOrDevil; loop < 2 * numOfPirestOrDevil; loop++) {
			peopleCtrl [loop] = new peopleController ("priest" , loop , environment.getPosVec(oriSize , loop) , "shore" , oriSize );
		}
	}

	public void boatMove(){ //船体移动 
		if (!myBoat.ifEmpty () && myBoat.getRunningState() != "running") {
			string toSize;
			string[] passengers = myBoat.getPassengerName();
			if (myBoat.size == "left") {
				toSize = "right";
			}
			else {
				toSize = "left";
			}

			for (int loop = 0; loop < 2; loop++) {
				for (int loop1 = 0; loop1 < numOfPirestOrDevil * 2; loop1++) {
					if (peopleCtrl [loop1].getName () == passengers [loop]) {
						peopleCtrl [loop1].size = toSize;
					}
				}
			}
			myBoat.move (actionManager);
		}

	}

	public void getBoatOrGetShore(string name){ //恶魔或牧师上船或上岸的条件设置 
		if (myBoat.getRunningState()!= "waiting") {
			return;
		}
		int numberOfPeople = name [name.Length - 1] - '0';
		if (peopleCtrl [numberOfPeople].getStatus () == "shore") {
			if (myBoat.ifHaveSeat () && myBoat.size == peopleCtrl [numberOfPeople].size ) {
				peopleCtrl [numberOfPeople].getOnBoat (myBoat, actionManager);
			}
		}
		else {
			if ( myBoat.size == peopleCtrl [numberOfPeople].size) {
				peopleCtrl [numberOfPeople].getOffBoat (environment, actionManager);
				myBoat.outBoat (peopleCtrl [numberOfPeople].getName() );
			}
		}

	}
}


public class boatController{
	GameObject boat;
	//readonly boatMoveBeahave updateBoatMove;
	readonly firstScenceSolveClick toSolveClick;
	Vector3 leftPos = new Vector3 (-4f, 0.7f, 0f);
	Vector3 rightPos = new Vector3 (4f, 0.7f, 0f);
	string []nameOfPeopleOnBoat = {"" , ""}; //船上每个位置的角色名字 
	Vector3 []boatPos = { new Vector3( -0.25f , 1.5f , 0f ) , new Vector3( 0.25f , 1.5f , 0f ) };
	public string size ; //船在河中的位置 
	private string defaultSize ; 

	public boatController(string size){ //将boat预制实例化 
		boat = Object.Instantiate (Resources.Load ("prefabs/boat", typeof(GameObject))
			, rightPos , Quaternion.identity, null) as GameObject ;
		boat.name = "boat";
		toSolveClick = boat.AddComponent (typeof(firstScenceSolveClick)) as firstScenceSolveClick;
		toSolveClick.setName (boat.name);
		//updateBoatMove = boat.AddComponent (typeof(boatMoveBeahave)) as boatMoveBeahave;
		defaultSize = size;
		this.size = defaultSize;
	}

	public bool ifEmpty(){ //判断船是否为空 
		return nameOfPeopleOnBoat[0] == "" && nameOfPeopleOnBoat[1] == "";
	}
	public bool ifHaveSeat(){ //判断船是否有空位 
		return nameOfPeopleOnBoat[0] == "" || nameOfPeopleOnBoat[1] == "";
	}

	public void move(CCActionManager actionManager){ // 船移动函数：从一端移动到另一端 
		CCBoatMoveing boatMove = CCBoatMoveing.GetSSAction (50f);
		if (size == "right") {
			boatMove.aim = leftPos;
			size = "left";
		} 
		else {
			boatMove.aim = rightPos;
			size = "right";
		}
		actionManager.RunAction (boat , boatMove , null );
	}

	public string getRunningState(){ //获得当前船的状态 
		if (boat.transform.position == rightPos || boat.transform.position == leftPos)
			return "waiting";
		else
			return "running";
	}

	public string[] getPassengerName(){ //获得船上的事物信息（牧师或者恶魔） 
		return nameOfPeopleOnBoat;
	}

	public GameObject getBoat(){ //得到事物船 
		return boat;
	}

	public void outBoat(string name){ //离开船的函数，将船上相应位置的name变为空 
		if (nameOfPeopleOnBoat [0] == name) {
			nameOfPeopleOnBoat [0] = "";
		} 
		else if (nameOfPeopleOnBoat [1] == name) {
			nameOfPeopleOnBoat [1] = "";
		}
	}

	public Vector3 getBoatPos(string name ){ //获取船的位置 
		Vector3 result =  Vector3.zero;
		for (int loop = 0; loop < 2; loop++) {
			if (nameOfPeopleOnBoat [loop].Length == 0) {
				nameOfPeopleOnBoat [loop] = name;
				result = boatPos [loop];
				break;
			}
		}
		return result;
	}
	//船信息重置：包括船上位置的角色名字信息nameOfPeopleOnBoat，船处于河的位置size，以及船的初始位置设为河右边 
	public void reset(CCActionManager actionManager){  
		nameOfPeopleOnBoat [0] = nameOfPeopleOnBoat [1] = "";
		size = defaultSize;
		CCBoatMoveing boatMove = CCBoatMoveing.GetSSAction (50f);
		boatMove.aim = rightPos;
		actionManager.RunAction (boat , boatMove , null );
		size = "right";
	}
}


/*public class boatMoveBeahave: MonoBehaviour{
	Vector3 aim = new Vector3 (4f, 0.7f, 0f);
	float speed = 20.0f;
	string status = "waiting" ; //船的初始状态 

	void Update(){ //传移动position以及speed设置 
		if (this.transform.position == aim) {
			status = "waiting";
		}
		else {
			this.transform.position = Vector3.MoveTowards (this.transform.position, aim , speed * Time.deltaTime);	
		}
	}

	public void setAim(Vector3 aim){ //设置船的目的地 
		this.aim = aim;
		status = "running"; 
	}

	public string getState(){ //获得当前船的状态 
		return status;
	}
}*/

public class environmentController{
	GameObject environment;
	Vector3 environmentPos =  Vector3.zero ;
	Vector3 leftShorePos = new Vector3 (-6f, 2f, 0f);
	Vector3 rightShorePos = new Vector3 (6f, 2f, 0f);
	public environmentController(){ //预制实例化 
		environment = Object.Instantiate (Resources.Load ("prefabs/environment", typeof(GameObject))
			, environmentPos, Quaternion.identity, null) as GameObject;
	}

	public Vector3 getPosVec(string size , int number){ //河和岸的位置设置 

		Vector3 result = new Vector3(0 , 0 , 0);
		if (size == "right") {
			result = rightShorePos + number * Vector3.right;		
		}
		else {
			result = leftShorePos + number * Vector3.left;
		}
		return result;
	}

}


public class peopleController{ //角色控制类 

	GameObject people;
	private string status;
	public string size ;
	private string defaultSize ; 
	firstScenceSolveClick solveClick;
	int number ;

	public peopleController(string name , int number , Vector3 pos , string status , string size){ //预制实例化，变量设置 
		people = Object.Instantiate (Resources.Load ("prefabs/" + name, typeof(GameObject))
			, pos, Quaternion.identity, null) as GameObject;
		people.name = name + number.ToString() ;
		solveClick = people.AddComponent (typeof(firstScenceSolveClick)) as firstScenceSolveClick;
		solveClick.setName (people.name);
		this.number = number;
		this.status = status;
		defaultSize = size;
		this.size = size;
	}



	public string getName(){ //获得角色名字 
		return people.name;
	}

	public string getStatus(){ //获得角色的状态 
		return status;
	}


	public void getOnBoat(boatController boatCtrl, CCActionManager actionManager){ //上船，状态设置为“boat” 
		status = "boat";
		people.transform.parent = boatCtrl.getBoat().transform ;
		Vector3 aim = boatCtrl.getBoatPos (getName() );
		CCPeopleMoveing peopleMove = CCPeopleMoveing.GetSSAction ( aim );
		actionManager.RunAction (people , peopleMove , null );
	}

	public void getOffBoat(environmentController envCtrl, CCActionManager actionManager){ //离开船（上岸），状态设置为“shore” 
		status = "shore";
		people.transform.parent = null;
		Vector3 aim = envCtrl.getPosVec (size, number);
		CCPeopleMoveing peopleMove = CCPeopleMoveing.GetSSAction (aim );
		actionManager.RunAction (people , peopleMove , null );
	}

	public void reset( environmentController envCtrl, CCActionManager actionManager ){ //角色重置：状态设置为“shore”，位置设置为默认的岸上位置 
		status = "shore";
		size = defaultSize;
		people.transform.parent = null;
		CCPeopleMoveing peopleMove = CCPeopleMoveing.GetSSAction ( envCtrl.getPosVec(size , number ) );
		actionManager.RunAction (people , peopleMove , null );
	}

}

