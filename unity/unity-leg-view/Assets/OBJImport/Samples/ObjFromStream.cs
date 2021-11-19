using Dummiesman;
using System.IO;
using System.Text;
using UnityEngine;

public class ObjFromStream : MonoBehaviour {


	public void LoadObjModel(string name)
	{
		
	}
	
	void Start () {
#pragma warning disable 618
		var www = new WWW(
#pragma warning restore 618
			"https://beta-api.fittin.ru/fit-data/permanent/foot_objs/50476_1_b78ff94c34b24174974659ca0f48_10leg.obj");
        while (!www.isDone)
            System.Threading.Thread.Sleep(1);
        
        //create stream and load
        var textStream = new MemoryStream(Encoding.UTF8.GetBytes(www.text));
        var loadedObj = new OBJLoader().Load(textStream);
        loadedObj.transform.localScale *= .005f;
	}
}
