using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardGame : MonoBehaviour
{
    List<Note> notes = new List<Note>();
    GameObject player;
    Vector3 pos;

    void Start()
    {
        notes = GameObject.Find("Cat").GetComponent<Movement>().notes;
        player = GameObject.Find("Cat");
        pos = player.transform.position;
    }

    public List<GameObject> CreateNote(List<Note> notes)
    {   
        List<GameObject> blocks = new List<GameObject>();

        int lstLength = notes.Count; // 리스트 길이
        float halfLength = lstLength / 2; 
        for(int i = 0;i < lstLength;i++)
        {    
            GameObject block = GameObject.Find(notes[i].noteType); 
            float half = Mathf.Round( i / 2 );
            blocks.Add(block);

            if (i < Mathf.Round(halfLength))
            {
                Instantiate(block, new Vector3 (pos.x - i, pos.y +1, pos.z), Quaternion.identity);
            }
            if (i> Mathf.Round(halfLength))
            {
                Instantiate(block, new Vector3 (pos.x + half, pos.y +1, pos.z), Quaternion.identity);
            }
            else
            {
                Instantiate(block, new Vector3 (pos.x, pos.y +1, pos.z), Quaternion.identity);
            }
        }

        return blocks;
    }
    
    // 음악 출력 함수

    // 사용자의 입력이 맞는지 확인하는 함수


    public void CreateWall(List<Note> notes)
    {
        int lstLength = notes.Count;
        BlockPosition position = new BlockPosition();

        for (int i = 0; i < lstLength;i++)
        {
            GameObject wall = GameObject.Find(notes[i].noteType+"Block"+notes[i].length);
            Instantiate(wall, position.first_game[i], Quaternion.identity);
        }
    }

    public void DestroyBlock(List<GameObject> blocks)
    {
        foreach(GameObject block in blocks)
        {
            Destroy(block);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
