using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace Test
{
    public class Test
    {
        private static Dictionary<string, bool> wordSet = new Dictionary<string, bool>();//假定wordSet是字典
        private static List<string> wordSet2 = new List<string>();//假定无序排列情况下，wordSet是数组

        //第一题
        public static bool wordSetCheck(string str)
        {
            StringBuilder tempStr = new StringBuilder();
            for(int i = 0; i < str.Length; i++)
            {
                tempStr.Append(str[i]);
                for (int j = i + 1; j < str.Length; j++)
                {
                    tempStr.Append(str[j]);
                    if (wordSet.ContainsKey(tempStr.ToString()))
                    {
                        tempStr.Clear();
                        break;
                    }
                }
                if (tempStr.Length > 0)
                {
                    return false;
                }
            }
            return true;
        }

        //第一题
        public static bool wordSetCheckWithNoSeris(string str)
        {
            List<int> charPos = new List<int>();
            int tempPos = 0;
            for(int i = 0; i < wordSet2.Count; i++)
            {
                charPos.Clear();

                for (int j = 0; j < wordSet2[i].Length; j++)
                {
                    tempPos = str.IndexOf(wordSet2[i][j]);
                    if(tempPos>=0)
                        charPos.Add(tempPos);
                }

                if (charPos.Count == wordSet2[i].Length)
                {
                    foreach(int pos in charPos)
                    {
                        str.Remove(pos, 1);
                    }
                }
            }
            return str.Length <= 0;
        }


        //第二题
        public static int getOverlapNums()
        {
            List<Rect> rects = new List<Rect>();//给定的矩形列表
            Dictionary<int, int> overlapIndexes = new Dictionary<int, int>();//重叠的矩形索引

            for(int i = 0; i < rects.Count; i++)
            {
                if (overlapIndexes.ContainsKey(i))
                    continue;

                for(int j = i + 1; j < rects.Count; j++)
                {
                    if (!(rects[i].xMin > rects[j].xMax || rects[i].xMax < rects[j].xMin
                    || rects[i].yMin > rects[j].yMax || rects[i].yMax < rects[j].yMin))
                    {
                        overlapIndexes.Add(i, 1);
                        overlapIndexes.Add(j, 1);
                    }
                }
            }


            return overlapIndexes.Count;
        }

        //第三题
        public static void delOverlapRects()
        {
            //思路：将矩形与与其相交的矩形构成一个以这个矩形为根的树，与之相交的矩形为其子节；若其子节点再没有与其他的矩形相交则此节点为叶子节点；
            //否则为非叶子节点。选出其中叶子节点最多的前10个矩形进行删除，删除一个节点将减少其叶子节点数量的相交矩阵。
        }

        //第四题
        //以圆形来进行圈地，因为战马一天跑的长度是固定的，周长相等圆形占用的面积最大。


    }
}
