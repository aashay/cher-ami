﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ally : MonoBehaviour {
    public bool AlreadyTouchedPigeon = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void touchPigeon(pigeon p)
    {
        if (this.AlreadyTouchedPigeon)
        {
            return; // nothing to do if we already touched the pigeon
        }
        game.getInstance().AddScore(game.SCORE_PER_MESSAGE);
        // Else, we drop the message from our hand and we heal the pigeon
        dropMessage();
        this.AlreadyTouchedPigeon = true;
        p.Health = Mathf.Min(pigeon.PIGEON_ALLY_HEALTH_BOOST + p.Health, pigeon.PIGEON_STARTING_HEALTH);
        healthUI.getInstance().blink();
    }

    void dropMessage()
    {
        var message = game.getChildGameObject(this.gameObject, "letter");
        Destroy(message);
    }
}
