﻿using UnityEngine;

namespace Chinchillada.Foundation
{
    public static class BoundsExtensions
    {
        /// <summary>
        /// Generates a random point within the <paramref name="bounds"/>.
        /// </summary>
        public static Vector3 RandomPoint(this Bounds bounds)
        {
            var min = bounds.center - bounds.size;
            var max = bounds.center + bounds.size;

            return new Vector3
            {
                x = Random.Range(min.x, max.x),
                y = Random.Range(min.y, max.y),
                z = Random.Range(min.z, max.z)
            };
        }

        public static BoundsInt ToBoundsInt(this Bounds bounds)
        {
            var min = bounds.min;
            var max = bounds.max;

            var minInt = new Vector3Int
            {
                x = Mathf.FloorToInt(min.x),
                y = Mathf.FloorToInt(min.y),
                z = Mathf.FloorToInt(min.z),
            };

            var maxInt = new Vector3Int
            {
                x = Mathf.CeilToInt(max.x),
                y = Mathf.CeilToInt(max.y),
                z = Mathf.CeilToInt(max.z),
            };

            var size = maxInt - minInt;
            return new BoundsInt(minInt.x, minInt.y, minInt.z, size.x, size.y, size.z);
        }
        
        /// <summary>
        /// Gets the center point of the <paramref name="bounds"/>.
        /// </summary>
        public static Vector3Int GetCenterInt(this BoundsInt bounds)
        {
            var size = bounds.size;
            var halfSize = new Vector3Int
            {
                x = size.x / 2,
                y = size.y / 2,
                z = size.z / 2
            };
            
            return bounds.position + halfSize;
        }
        
        
        public static bool Contains2D(this BoundsInt bounds, Vector2Int vector)
        {
            return vector.x >= bounds.xMin && vector.x < bounds.xMax &&
                   vector.y >= bounds.yMin && vector.y < bounds.yMax;
        }

    }
}