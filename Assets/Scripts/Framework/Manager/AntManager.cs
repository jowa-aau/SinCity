using System.Collections;
using System.Collections.Generic;
using Framework;
using Framework.Manager;
using UnityEngine;

public class AntManager : Singleton<AntManager>
{
	private GameManager gm;
	private AntGenerator generator;
	private float waitTime = 1.0f;
	private float timer = 0.0f;
	
	/// <summary>
	/// private constructor because singleton
	/// </summary>
	private AntManager() {}
	
	/// <summary>
	/// Used for initializion.
	/// Start is only called if the script component is enabled.
	/// It is also called after Awake
	/// </summary>
	protected void Start()
	{
		gm = GameManager.Instance;
		AntGenerator.Instance.Init(gm.GetAntPrefabs());
		generator = AntGenerator.Instance;
		
	}

	private void Update()
	{
		
		timer += Time.deltaTime;
		if (timer >= waitTime) {
			int toGenerate = gm.GetAntCounter() + gm.GetAntsPerSecond() <= gm.GetMaxAnts() ? gm.GetAntsPerSecond() : gm.GetMaxAnts() - gm.GetAntCounter();
			if (toGenerate > 0) {
				gm.addAnts(toGenerate);
				generator.GenerateAnts(0, 0, toGenerate);
				timer = 0.0f;
			}
		}
	}
}
