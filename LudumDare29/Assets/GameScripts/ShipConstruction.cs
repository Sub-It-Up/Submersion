using UnityEngine;
using System.Collections;

public class ShipConstruction : MonoBehaviour {

	public GameObject boatPart;
	public GameObject buttonRoom;

	int[,] rightRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //1 open
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //2 open
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1}, //3
		{ 1, 1, 1, 1, 1, 1, 0, 0, 1, 1}, //4
		{ 1, 1, 1, 1, 1, 2, 2, 2, 2, 1}, //5
		{ 1, 1, 1, 1, 1, 2, 2, 2, 2, 1}, //6
		{ 1, 1, 1, 1, 1, 2, 2, 2, 2, 1}, //7
		{ 1, 1, 1, 1, 1, 2, 2, 2, 2, 1}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
									 };

	int[,] rightRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 1, 1, 1, 1, 1, 1, 2, 2, 2, 1}, //1
		{ 1, 1, 1, 1, 1, 1, 2, 2, 2, 1}, //2
		{ 1, 1, 1, 1, 1, 1, 2, 2, 1, 1}, //3
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //4 open
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //5 open
		{ 1, 1, 1, 1, 1, 1, 2, 2, 1, 1}, //6
		{ 1, 1, 1, 1, 1, 1, 2, 2, 2, 1}, //7
		{ 1, 1, 1, 1, 1, 1, 2, 2, 2, 1}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] rightRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 1, 2, 2, 1, 0, 0, 1, 2, 2, 1}, //1
		{ 1, 2, 2, 2, 0, 0, 2, 2, 2, 1}, //2
		{ 1, 2, 2, 2, 0, 0, 2, 2, 2, 1}, //3 
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //4
		{ 1, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //5
		{ 1, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //6
		{ 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}, //7 open
		{ 0, 0, 0, 1, 1, 1, 1, 1, 1, 1}, //8 open 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom1 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //1
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 2, 2, 2, 2, 0, 0, 0}, //4
		{ 0, 0, 0, 2, 2, 2, 2, 0, 0, 0}, //5
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //7
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom2 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //1
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 2, 2, 2, 2, 0, 0, 0}, //4
		{ 0, 0, 0, 2, 2, 2, 2, 0, 0, 0}, //5
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0}, //7
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom3 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 2, 2, 0, 0, 0, 0, 2, 2, 0}, //1
		{ 0, 2, 2, 0, 0, 0, 0, 2, 2, 0}, //2
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //3 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //5
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //6 close
		{ 0, 2, 2, 0, 0, 0, 0, 2, 2, 0}, //7
		{ 0, 2, 2, 0, 0, 0, 0, 2, 2, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] leftRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 2, 0, 1, 0, 0, 0, 0}, 
		{ 1, 2, 2, 2, 0, 1, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 1, 0, 0, 1, 1},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 1, 0, 0, 1, 1},
		{ 1, 2, 2, 2, 0, 1, 0, 0, 0, 0},
		{ 1, 2, 2, 2, 0, 1, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 2, 2, 1, 0, 0, 0, 0}, 
		{ 1, 2, 2, 2, 2, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 0, 0, 1, 1},
		{ 1, 0, 0, 2, 2, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 2, 2, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 0, 0, 1, 1},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 0, 0, 2, 2, 0, 0, 0}, 
		{ 1, 2, 2, 0, 0, 2, 2, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 1, 1, 0, 0, 1},
		{ 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 1, 1, 0, 0, 1},
		{ 1, 2, 2, 0, 0, 2, 2, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 2, 2, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] topRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 2, 0, 0, 2, 2, 2, 1}, 
		{ 1, 2, 2, 2, 0, 0, 2, 2, 2, 1},
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1},
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	int[,] topRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 0, 0, 0, 0, 2, 2, 1}, 
		{ 1, 2, 2, 0, 0, 0, 0, 2, 2, 1},
		{ 1, 1, 1, 0, 0, 0, 0, 1, 1, 1},
		{ 1, 0, 0, 2, 2, 2, 2, 0, 0, 1},
		{ 1, 0, 0, 2, 2, 2, 2, 0, 0, 1},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},	
	};

	int[,] topRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 0, 0, 0, 0, 2, 2, 1}, 
		{ 1, 2, 2, 0, 0, 0, 0, 2, 2, 1},
		{ 1, 2, 2, 1, 0, 0, 1, 2, 2, 1},
		{ 1, 2, 2, 1, 0, 0, 1, 2, 2, 1},
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	void GenerateRightRoom(int x, int y, int newY, int roomNumber)
	{

		switch (roomNumber)
		{
			case 1:
				if(rightRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom1[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 2:
				if(rightRoom2[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom2[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 3:
				if(rightRoom3[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom3[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
		}
	}

	void GenerateLeftRoom(int x, int y, int newY, int roomNumber)
	{
		switch (roomNumber)
		{
			case 1:
			if(leftRoom1[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom1[y, x] == 2)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 2:
			if(leftRoom2[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom2[y, x] == 2)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 3:
			if(leftRoom3[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom3[y, x] == 2)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		}
	}
	
	void GenerateMidRoom(int x, int y, int newY, int roomNumber)
	{
		switch (roomNumber)
		{
			case 1:
				if(midRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(midRoom1[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 2:
				if(midRoom2[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(midRoom2[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 3:
				if(midRoom3[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(midRoom3[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
		}
	}
	
	void GenerateTopRoom(int x, int y, int newY, int roomNumber)
	{
		switch(roomNumber)
		{
			case 1:
				if(topRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topRoom1[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 2:
				if(topRoom2[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topRoom2[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 3:
				if(topRoom3[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topRoom3[y, x] == 2)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
		}


	}
	
	// Use this for initialization
	void Start () {
		int lRoomNum;
		int tRoomNum;
		int mRoomNum;
		int rRoomNum = (int)Random.Range (1, 3);
		do
		{
			lRoomNum = (int)Random.Range (1, 3);
		} while(lRoomNum != rRoomNum);
		do
		{
			tRoomNum = (int)Random.Range (1, 3);
		} while(tRoomNum != lRoomNum);
		do
		{
			mRoomNum = (int)Random.Range (1, 3);
		} while(mRoomNum != tRoomNum);
	
		//Loop through the room arrays
		for(int y = 9, newY = 0; y >= 0; --y, ++newY)
		{
			for(int x = 0; x < 10; ++x)
			{	
				//Right room generation
				GenerateRightRoom(x, y, newY, rRoomNum);
				//Mid room generation
				GenerateMidRoom(x, y, newY, mRoomNum);
				//Left room generation
				GenerateLeftRoom(x, y, newY, lRoomNum);
				//Top room generation
				GenerateTopRoom(x, y, newY, tRoomNum);

			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	

	}
}
