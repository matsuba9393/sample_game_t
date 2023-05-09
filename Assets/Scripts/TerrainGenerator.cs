using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGenerator : MonoBehaviour
{
    int MAX_X = 30;
    int MAX_Y = 2;
    int MAX_Z = 30;

    public GameObject cube_tsuchi;
    public GameObject cube_kusa;
    List<GameObject> cubes　= new List<GameObject>();
    public List<TerrainData> data = new List<TerrainData>();
    
    

    void Start(){
        //RandomDataGenerator();
        SuperFlatDataGenerator();
        TerrainGenerate();
    }

    public void RandomDataGenerator(){
        int x;
        int rnd_x;
        int rnd_y;

        int loc_x = 0;
        int loc_z = 0;

        TerrainData data_each = new TerrainData();

        int z = MAX_Z;
        while(0<z){
            //Debug.Log(z);
            x = MAX_X;
            loc_x = 0;
            while(0<x){
                data_each = new TerrainData();
                rnd_x = Random.Range(1,3);
                rnd_y = Random.Range(1,MAX_Y+1);
                if(x<rnd_x){
                    rnd_x = x;
                }

                data_each.loc_x = loc_x;
                data_each.loc_z = loc_z;

                data_each.len_x = rnd_x;
                data_each.len_y = rnd_y;

                data.Add(data_each);

                loc_x += rnd_x;
                x -= rnd_x;
            } 
            z--;
            loc_z++;
        }
        
        
    }

    public void SuperFlatDataGenerator(){
        for(int i = 0;i<30;i++) {
            TerrainData ex = new TerrainData();
            ex.len_x = 30;
            ex.len_y = 3;
            ex.loc_z = i;
            data.Add(ex);
        }
    }

    //地形データから地形を生成
    public void TerrainGenerate(){
        for(int i = 0; i < data.Count; i++){ //地形データの数くりかえす
            for(int x = 0; x < data[i].len_x; x++){ //各地形のxの長さ分繰り返す
                for(int y = 0; y< data[i].len_y; y++){ //各地形のyの長さ分繰り返す
                    if(y == data[i].len_y-1){ //各地形の1番上
                        //草の生えたブロックを生成。
                        GameObject cube = Instantiate(cube_kusa, new Vector3(data[i].loc_x + x, y, data[i].loc_z),Quaternion.identity);
                        cube.transform.parent = this.gameObject.transform;
                    }else{ //それ以外
                        //土のブロックを生成。
                        GameObject cube = Instantiate(cube_tsuchi, new Vector3(data[i].loc_x + x, y, data[i].loc_z),Quaternion.identity);
                        cube.transform.parent = this.gameObject.transform;
                    }
                }
            }
            
        }
   
    }
}
