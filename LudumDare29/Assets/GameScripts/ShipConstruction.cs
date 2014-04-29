using UnityEngine;
using System.Collections;

public class ShipConstruction : MonoBehaviour {

	public GameObject boatPart;
	public GameObject buttonRoom;

	int[,] rightRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0 
		{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //1 open
		{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //2 open
		{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 1}, //3
		{ 1, 1, 1, 1, 0, 0, 0, 0, 1, 1}, //4
		{ 1, 1, 0, 0, 0, 0, 1, 1, 1, 1}, //5
		{ 1, 1, 0, 0, 0, 0, 1, 1, 1, 1}, //6
		{ 1, 1, 1, 1, 0, 0, 0, 2, 2, 1}, //7
		{ 1, 1, 1, 1, 0, 0, 0, 2, 2, 1}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
									 };

	int[,] rightRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //1
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //2
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //3
		{ 0, 0, 0, 0, 0, 0, 0, 2, 2, 1}, //4 open
		{ 0, 0, 0, 0, 0, 0, 0, 2, 2, 1}, //5 open
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //6
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //7
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] rightRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1}, //1
		{ 0, 0, 0, 0, 1, 1, 1, 1, 1, 1}, //2
		{ 1, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //3 
		{ 1, 0, 0, 0, 0, 0, 0, 2, 2, 1}, //4
		{ 1, 0, 0, 0, 0, 0, 0, 2, 2, 1}, //5
		{ 1, 0, 0, 0, 0, 0, 1, 1, 1, 1}, //6
		{ 0, 0, 0, 0, 1, 1, 1, 1, 1, 1}, //7 open
		{ 0, 0, 1, 1, 1, 1, 1, 1, 1, 1}, //8 open 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] rightRoom4 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //1
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //2
		{ 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}, //3 close
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1}, //4
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1}, //5
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //7 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 1}, //8  
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] rightRoom5 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //0
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //1
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //2
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 1}, //4
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 1}, //5
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //6 close
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 1}, //7 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //8  
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom1 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //1
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //5
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //7
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom2 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //1
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //5
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //7
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom3 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //1
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //2
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //3 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //5
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //6 close
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //7
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom4 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //1
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //5
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1}, //6 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //7
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] midRoom5 = new int[10, 10] { 
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1}, //0
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //1
		{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0}, //2
		{ 1, 0, 0, 1, 0, 0, 1, 0, 0, 1}, //3 close
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //4
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, //5
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1}, //6 close
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0}, //7
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, //8
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, //9
	};

	int[,] leftRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0}, 
		{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 1, 0, 0, 1, 1},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 1, 0, 0, 1, 1},
		{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 0, 0, 1, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 0, 0, 1, 1},
		{ 1, 0, 0, 2, 2, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 2, 2, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 0, 0, 1, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0}, 
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 0, 0, 0, 1},
		{ 1, 1, 1, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 0, 0, 0, 0, 1},
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom4 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 0, 0, 0, 0, 1},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 1, 1, 0, 0, 1},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] leftRoom5 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0}, 
		{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 1},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 2, 2, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 1},
		{ 1, 1, 1, 0, 0, 0, 1, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1},
	};

	int[,] topRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	int[,] topRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 0, 1, 1, 1},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},	
	};

	int[,] topRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
		{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
		{ 1, 0, 0, 0, 0, 0, 0, 0, 0, 1},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	int[,] topRoom4 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 2, 2, 1, 0, 0, 1},
		{ 0, 0, 0, 1, 2, 2, 1, 0, 0, 0},
		{ 0, 0, 0, 0, 1, 1, 0, 0, 0, 0},
		{ 1, 0, 0, 0, 1, 1, 0, 0, 0, 1},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	int[,] topRoom5 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 0, 0, 0, 1, 1, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	int[,] topMidRoom1 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 1, 0, 0, 1, 1, 1, 1},
		{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 0, 0, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 0, 0, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};
	
	int[,] topMidRoom2 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 1, 1, 0, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},	
	};
	
	int[,] topMidRoom3 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0}, 
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};
	
	int[,] topMidRoom4 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 2, 2, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 0, 0, 0, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};
	
	int[,] topMidRoom5 = new int[10, 10] { 
		{ 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0}, 
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 1, 1, 1},
		{ 0, 2, 2, 1, 1, 1, 1, 0, 0, 0},
		{ 0, 2, 2, 1, 1, 1, 1, 0, 0, 0},
		{ 1, 1, 1, 1, 1, 1, 1, 0, 0, 1},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
		{ 1, 0, 0, 1, 1, 1, 1, 0, 0, 1},
	};

	void GenerateRightRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
	{

		switch (roomNumber)
		{
			case 1:
				if(rightRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom1[y, x] == 2 && terminalSelect[9] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 2:
				if(rightRoom2[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom2[y, x] == 2 && terminalSelect[9] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 3:
				if(rightRoom3[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom3[y, x] == 2 && terminalSelect[9] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 4:
				if(rightRoom4[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom4[y, x] == 2 && terminalSelect[9] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 5:
				if(rightRoom5[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(rightRoom5[y, x] == 2 && terminalSelect[9] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		}
	}

  void GenerateTopRightRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
  {
    
    switch (roomNumber)
    {
    case 1:
      if(rightRoom1[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
	  else if(rightRoom1[y, x] == 2 && terminalSelect[4] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 2:
      if(rightRoom2[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
	  else if(rightRoom2[y, x] == 2 && terminalSelect[4] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 3:
      if(rightRoom3[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
	  else if(rightRoom3[y, x] == 2 && terminalSelect[4] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 4:
      if(rightRoom4[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(rightRoom4[y, x] == 2  && terminalSelect[4] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 5:
      if(rightRoom5[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(rightRoom5[y, x] == 2  && terminalSelect[4] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    }
  }

	void GenerateLeftRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
	{
		switch (roomNumber)
		{
			case 1:
			if(leftRoom1[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom1[y, x] == 2 && terminalSelect[5] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 2:
			if(leftRoom2[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom2[y, x] == 2 && terminalSelect[5] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 3:
			if(leftRoom3[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom3[y, x] == 2 && terminalSelect[5] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 4:
			if(leftRoom4[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom4[y, x] == 2 && terminalSelect[5] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 5:
			if(leftRoom5[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(leftRoom5[y, x] == 2 && terminalSelect[5] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;

		}
	}

  void GenerateTopLeftRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
  {
    switch (roomNumber)
    {
    case 1:
      if(leftRoom1[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(leftRoom1[y, x] == 2 && terminalSelect[0] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 2:
      if(leftRoom2[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(leftRoom2[y, x] == 2 && terminalSelect[0] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 3:
      if(leftRoom3[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(leftRoom3[y, x] == 2 && terminalSelect[0] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 4:
      if(leftRoom4[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(leftRoom4[y, x] == 2 && terminalSelect[0] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 5:
      if(leftRoom5[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(leftRoom5[y, x] == 2 && terminalSelect[0] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 20, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
      
    }
  }

	void GenerateMidRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
	{
		switch (roomNumber)
		{
			case 1:
				if(midRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(midRoom1[y, x] == 2 && terminalSelect[7] == 1)
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
				else if(midRoom2[y, x] == 2 && terminalSelect[7] == 1)
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
				else if(midRoom3[y, x] == 2 && terminalSelect[7] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
		case 4:
			if(midRoom4[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(midRoom4[y, x] == 2 && terminalSelect[7] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 5:
			if(midRoom5[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(midRoom5[y, x] == 2 && terminalSelect[7] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		}
	}

  void GenerateMidLeftRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
  {
    switch (roomNumber)
    {
    case 1:
      if(midRoom1[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom1[y, x] == 2  && terminalSelect[6] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 2:
      if(midRoom2[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom2[y, x] == 2 && terminalSelect[6] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 3:
      if(midRoom3[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom3[y, x] == 2 && terminalSelect[6] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 4:
      if(midRoom4[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom4[y, x] == 2 && terminalSelect[6] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 5:
      if(midRoom5[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom5[y, x] == 2 && terminalSelect[6] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    }
  }
	
  void GenerateMidRightRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
  {
    switch (roomNumber)
    {
    case 1:
      if(midRoom1[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom1[y, x] == 2 && terminalSelect[8] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 2:
      if(midRoom2[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom2[y, x] == 2 && terminalSelect[8] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 3:
      if(midRoom3[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom3[y, x] == 2 && terminalSelect[8] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 4:
      if(midRoom4[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom4[y, x] == 2 && terminalSelect[8] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 5:
      if(midRoom5[y, x] == 1)
      {
        GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x + 10, newY, 0), transform.rotation);
        parts.transform.parent = this.transform;
      }
		else if(midRoom5[y, x] == 2 && terminalSelect[8] == 1)
      {
        GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x + 10, newY, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    }
  }

	void GenerateTopRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
	{
		switch(roomNumber)
		{
			case 1:
				if(topMidRoom1[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topMidRoom1[y, x] == 2 && terminalSelect[2] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 2:
				if(topMidRoom2[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topMidRoom2[y, x] == 2 && terminalSelect[2] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
			case 3:
				if(topMidRoom3[y, x] == 1)
				{
					GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
					parts.transform.parent = this.transform;
				}
				else if(topMidRoom3[y, x] == 2 && terminalSelect[2] == 1)
				{
					GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
					bRoom.transform.parent = this.transform;
				}
				break;
		case 4:
			if(topMidRoom4[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(topMidRoom4[y, x] == 2 && terminalSelect[2] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		case 5:
			if(topMidRoom5[y, x] == 1)
			{
				GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x, newY + 10, 0), transform.rotation);
				parts.transform.parent = this.transform;
			}
			else if(topMidRoom5[y, x] == 2 && terminalSelect[2] == 1)
			{
				GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x, newY + 10, 0), transform.rotation);
				bRoom.transform.parent = this.transform;
			}
			break;
		}
	}

  void GenerateTopMidRightRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
  {
    switch (roomNumber) {
    case 1:
      if (topRoom1 [y, x] == 1) {
        GameObject parts = (GameObject)Instantiate (boatPart, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
		} else if (topRoom1 [y, x] == 2 && terminalSelect[3] == 1) {
        GameObject bRoom = (GameObject)Instantiate (buttonRoom, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 2:
      if (topRoom2 [y, x] == 1) {
        GameObject parts = (GameObject)Instantiate (boatPart, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
			} else if (topRoom2 [y, x] == 2 && terminalSelect[3] == 1) {
        GameObject bRoom = (GameObject)Instantiate (buttonRoom, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 3:
      if (topRoom3 [y, x] == 1) {
        GameObject parts = (GameObject)Instantiate (boatPart, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
			} else if (topRoom3 [y, x] == 2 && terminalSelect[3] == 1) {
        GameObject bRoom = (GameObject)Instantiate (buttonRoom, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 4:
      if (topRoom4 [y, x] == 1) {
        GameObject parts = (GameObject)Instantiate (boatPart, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
			} else if (topRoom4 [y, x] == 2 && terminalSelect[3] == 1) {
        GameObject bRoom = (GameObject)Instantiate (buttonRoom, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    case 5:
      if (topRoom5 [y, x] == 1) {
        GameObject parts = (GameObject)Instantiate (boatPart, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        parts.transform.parent = this.transform;
			} else if (topRoom5 [y, x] == 2 && terminalSelect[3] == 1) {
        GameObject bRoom = (GameObject)Instantiate (buttonRoom, new Vector3 (x + 10, newY + 10, 0), transform.rotation);
        bRoom.transform.parent = this.transform;
      }
      break;
    }
   
  }

    void GenerateTopMidLeftRoom(int x, int y, int newY, int roomNumber, int [] terminalSelect)
    {
      switch(roomNumber)
      {
      case 1:
        if(topRoom1[y, x] == 1)
        {
          GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          parts.transform.parent = this.transform;
        }
			else if(topRoom1[y, x] == 2 && terminalSelect[1] == 1)
        {
          GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          bRoom.transform.parent = this.transform;
        }
        break;
      case 2:
        if(topRoom2[y, x] == 1)
        {
          GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          parts.transform.parent = this.transform;
        }
			else if(topRoom2[y, x] == 2 && terminalSelect[1] == 1)
        {
          GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          bRoom.transform.parent = this.transform;
        }
        break;
      case 3:
        if(topRoom3[y, x] == 1)
        {
          GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          parts.transform.parent = this.transform;
        }
			else if(topRoom3[y, x] == 2 && terminalSelect[1] == 1)
        {
          GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          bRoom.transform.parent = this.transform;
        }
        break;
      case 4:
        if(topRoom4[y, x] == 1)
        {
          GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          parts.transform.parent = this.transform;
        }
			else if(topRoom4[y, x] == 2 && terminalSelect[1] == 1)
        {
          GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          bRoom.transform.parent = this.transform;
        }
        break;
      case 5:
        if(topRoom5[y, x] == 1)
        {
          GameObject parts = (GameObject)Instantiate(boatPart, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          parts.transform.parent = this.transform;
        }
			else if(topRoom5[y, x] == 2 && terminalSelect[1] == 1)
        {
          GameObject bRoom = (GameObject)Instantiate(buttonRoom, new Vector3(x - 10, newY + 10, 0), transform.rotation);
          bRoom.transform.parent = this.transform;
        }
        break;
      }

    
  }

	
	// Use this for initialization
	void Start () {
		int [] terminalSelect = new int[10] {0,0,0,0,0,0,0,0,0,0};
		int terminalCount = 0;
		int terminalNumber;
		int lRoomNum;
		int tRoomNum;
		int mRoomNum;
    int mlRoomNum;
    int mrRoomNum;
    int tlRoomNum;
    int trRoomNum;
    int tmlRoomNum;
    int tmrRoomNum;
    //int mrrRoomNum;

		int rRoomNum = (int)Random.Range (1, 5);
		do
		{
			lRoomNum = (int)Random.Range (1, 5);
		} while(lRoomNum == rRoomNum);
		do
		{
			tRoomNum = (int)Random.Range (1, 5);
		} while(tRoomNum == lRoomNum);
		do
		{
			mRoomNum = (int)Random.Range (1, 5);
		} while(mRoomNum == tRoomNum);
    do
    {
      mlRoomNum = (int)Random.Range (1, 5);
    } while(mlRoomNum == mRoomNum);
    do
    {
      mrRoomNum = (int)Random.Range (1, 5);
    } while(mrRoomNum == mlRoomNum);
    do
    {
      tmrRoomNum = (int)Random.Range (1, 5);
    } while(tmrRoomNum == mrRoomNum);
    do
    {
      tmlRoomNum = (int)Random.Range (1, 5);
    } while(tmlRoomNum == tmrRoomNum);
    do
    {
      tlRoomNum = (int)Random.Range (1, 5);
    } while(tlRoomNum == lRoomNum);
    do
    {
      trRoomNum = (int)Random.Range (1, 5);
    } while(trRoomNum == rRoomNum);

		while(terminalCount < 4)
		{
			terminalNumber = (int) Random.Range(0, 9);
			if(terminalSelect[terminalNumber] == 0)
			{
				++terminalCount;
				terminalSelect[terminalNumber] = 1;
			}
		}


		//Loop through the room arrays
		for(int y = 9, newY = 0; y >= 0; --y, ++newY)
		{
			for(int x = 0; x < 10; ++x)
			{	
				//Right room generation
				GenerateRightRoom(x, y, newY, rRoomNum, terminalSelect);
        		//Mid room generation
				GenerateMidRoom(x, y, newY, mRoomNum, terminalSelect);
		        //Mid room generation
		        GenerateMidLeftRoom(x, y, newY, mlRoomNum, terminalSelect);
		        //Mid room generation
		        GenerateMidRightRoom(x, y, newY, mrRoomNum, terminalSelect);
				//Left room generation
				GenerateLeftRoom(x, y, newY, lRoomNum, terminalSelect);
				//Top room generation
				GenerateTopRoom(x, y, newY, tRoomNum, terminalSelect);
		        //Top-Mid-Left room generation
		        GenerateTopMidLeftRoom(x, y, newY, tmlRoomNum, terminalSelect);
		        //Top-Mid-Right room generation
		        GenerateTopMidRightRoom(x, y, newY, tmrRoomNum, terminalSelect);
		        //Top-Left room generation
		        GenerateTopLeftRoom(x, y, newY, tlRoomNum, terminalSelect);
		        //Top-Right room generation
		        GenerateTopRightRoom(x, y, newY, trRoomNum, terminalSelect);

			}
		}
	
	}
	
	// Update is called once per frame
	void Update () {
	
	

	}
}
