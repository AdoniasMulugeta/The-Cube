using UnityEngine;
using System.Collections;

public class LevelGenerator : MonoBehaviour {
	public Texture2D levelMap;
	public ColorPrefab[] colorMappings;
	void Start () {
		generateLevel();
	}
	void generateLevel(){
		for(int x=0;x<levelMap.height;x++){
			for(int y=0;y<levelMap.width;y++){
				generateTile(x,y); 
			}
		}
	}
	void generateTile(int x,int y){
		Color pixelColor = levelMap.GetPixel(x,y);
		if(pixelColor.a==0){
			return;
		}
		foreach(ColorPrefab colorMapping in colorMappings){
			if(colorMapping.color.Equals(pixelColor)){
				Vector3 position = new Vector3(x,0.5f,y);
				Instantiate(colorMapping.prefab,position,transform.rotation);
			}
		}

	}
}
