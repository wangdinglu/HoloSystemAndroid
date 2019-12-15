using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MixOne
{
    public class SpaceCalculation : SpaceSettings
    {
        public int[] GetUpBounds(int position,int width)
        {
            int[] bounds = new int[2];
            
            bounds[0] = position - (width - 1) / 2;
            bounds[1] = position + width / 2;
            if (bounds[0] < 0)
            {
                bounds[1] += 0 - bounds[0];
                bounds[0] = 0;
            }
            if (bounds[1] > verticalHeight - 1)
            {
                bounds[1] = verticalHeight - 1;
                bounds[0] -= bounds[1] - (verticalHeight - 1);
            }
            return bounds;
        }

        public int[] GetDownBounds(int position, int width)
        {
            int[] bounds = new int[2];

            bounds[0] = position - (width - 1) / 2;
            bounds[1] = position + width / 2;
            if (bounds[0] < 0)
            {
                bounds[1] += 0 - bounds[0];
                bounds[0] = 0;                
            }
            if (bounds[1] > verticalHeight - 1)
            {
                bounds[1] = verticalHeight - 1;
                bounds[0] -= bounds[1] - (verticalHeight - 1);
            }
            return bounds;
        }

        public int[] GetHorizonFreeBounds(int position, int width)
        {
            int[] bounds = new int[2];

            bounds[0] = position - (width-1) / 2;
            bounds[1] = position + width / 2;
            if (bounds[0] < 0)
            {
                bounds[1] += 0 - bounds[0];
                bounds[0] = 0;                
            }
            if (bounds[1] > horizonWidth - 1)
            {                
                bounds[0] -= bounds[1] - (horizonWidth - 1);
                bounds[1] = horizonWidth - 1;
            }
            return bounds;
        }

        public int[] GetHorizonLockBounds(int position, int width)
        {
            int[] bounds = new int[2];

            bounds[0] = position - (width-1) / 2;
            bounds[1] = position + width / 2;
            Debug.Log(bounds[0].ToString() + "  " + bounds[1].ToString());
            if (bounds[0] < 0)
            {
                bounds[1] += 0 - bounds[0];
                bounds[0] = 0;
            }
            if (bounds[1] >= (horizonWidth - verticalWidth) / 2 && position < (horizonWidth - verticalWidth) / 2)
            {
                bounds[0] = (horizonWidth - verticalWidth) / 2 - 1 - (width - 1);
                bounds[1] = (horizonWidth - verticalWidth) / 2 - 1;
            }
            if (bounds[0] <= horizonWidth - (horizonWidth - verticalWidth) / 2 - 1 && position > horizonWidth - (horizonWidth - verticalWidth) / 2 - 1)
            {
                bounds[0] = horizonWidth - (horizonWidth - verticalWidth) / 2;
                bounds[1] = horizonWidth - (horizonWidth - verticalWidth) / 2 + width - 1;
            }
            if (bounds[1] > horizonWidth - 1)
            {
                bounds[0] -= bounds[1] - (horizonWidth - 1);
                bounds[1] = horizonWidth - 1;
            }
            Debug.Log(bounds[0].ToString() + "  " + bounds[1].ToString());
            return bounds;
        }
    }
}

