using UnityEngine;

public class LevelGenerator : MonoBehaviour {

	public Texture2D map;

	public ColorToPrefab[] colorMappings;

	// Use this for initialization
	void Start ()
    {
        if (map != null)
            GenerateLevel();
        else
            Debug.LogWarning("No level-map found");
	}

	void GenerateLevel ()
	{
		for (int x = 0; x < map.width; x++)
		{
			for (int y = 0; y < map.height; y++)
			{
				GenerateTile(x, y);
			}
		}
	}

	private void GenerateTile (int x, int y)
	{
		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0)
		{
			// The pixel is transparrent. Let's ignore it!
			return;
		}

		foreach (ColorToPrefab colorMapping in colorMappings)
		{
			if (colorMapping.color.Equals(pixelColor))
			{
				Vector2 position = new Vector2(x, y);
				Instantiate(colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}
	
}
