using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStyle {

    protected int id;
    public int Id
    {
        get { return id; }
        set
        {
            id = value;
        }
    }

    protected string name;
    public string Name
    {
        get { return name; }
        set
        {
            name = value;
        }
    }

    protected Texture texture;
    public Texture Texture
    {
        get { return texture; }
        set
        {
            texture = value;
        }
    }

    public CharacterStyle(int i, string n, Texture t) {
        id = i;
        name = n;
        texture = t;
	}

}
