using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PowerUps {

	public const string RAPIDFIRE ="rf";
	public const string DOUBLE ="db";
	public const string ROCKET ="mb";
	public const string BOMB ="sb";
	public const string SLOWDOWN ="sd";
	public const string MULTIPLIER ="mu";

	private List<PowerUp> powerUps = null;

	public List<PowerUp> getPowerUps() { return this.powerUps; }

	public PowerUps(){
		powerUps=new List<PowerUp>();
		//PowerUp 1
		powerUps.Add(new PowerUp (RAPIDFIRE, "Rapidfire","Shoots extra fast.",900) ); //DONE
		//PowerUp 3
		powerUps.Add(new PowerUp (DOUBLE, "Double cannon","Shoot double smiles.",100) ); //DONE
		//PowerUp 4
		powerUps.Add(new PowerUp (ROCKET, "Rocket","Defeats a block of squares.",150) ); //DONE
		//PowerUp 5
		powerUps.Add(new PowerUp (BOMB, "Smile Bomb","Defeats everithing in the screen.",400) ); //DONE
		//PowerUp 6
		powerUps.Add(new PowerUp (SLOWDOWN, "Freeze", "Freeze a wave of squares.",800) ); //DONE
		//PowerUp 2
		powerUps.Add(new PowerUp (MULTIPLIER, "Gem Multiplier","Mutiplies Gems X2.",1500)); //DONE

	}
}
