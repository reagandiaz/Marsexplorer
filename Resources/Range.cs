
using System;
using System.Collections.Generic;
using System.Linq;

namespace Marsexplorer.Resources
{
    public class Range
    {
        public int Min;
        public int Max;

        public override string ToString()
        {
            return $"{Min}:{Max}";
        }
    }

    public class Ranges : List<Range>
    {
        public int Explored()
        {
            int cnt = 0;

            this.ForEach(s =>
            {
                if (s.Min == s.Max)
                    cnt++;
                else
                    cnt += (s.Max - s.Min + 1);
            });
            return cnt;
        }

        public void Store(int y1, int y2)
        {
            var nrange = new Range() { Min = Math.Min(y1, y2), Max = Math.Max(y1, y2) };
            var match = this.Find(s => nrange.Min <= s.Min);

            if (match == null)
            {
                var below = this.FindLast(s => s.Min < nrange.Min);
                if (below != null)
                {
                    //this cannot merge
                    if (below.Max + 1 < nrange.Min)
                    {
                        this.Add(nrange);
                        MergeAtIndex(this.IndexOf(nrange));
                        return;
                    }


                    below.Max = nrange.Max;
                    MergeAtIndex(this.IndexOf(below));
                    return;
                }
                this.Add(nrange);
                return;
            }




            //same min
            if (match.Min == nrange.Min)
            {
                match.Max = Math.Max(match.Max, nrange.Max);
                MergeAtIndex(this.IndexOf(match));
                return;
            }

            //overlap
            if (match.Min <= nrange.Max && nrange.Max <= match.Max)
            {
                match.Min = nrange.Min;
                match.Max = Math.Max(nrange.Max, match.Max);
                MergeAtIndex(this.IndexOf(match));
                return;
            }

            //match within bounds new
            if (nrange.Min <= match.Min && match.Max <= nrange.Max)
            {
                match.Min = nrange.Min;
                match.Max = nrange.Max;
                MergeAtIndex(this.IndexOf(match));
                return;
            }

            this.Insert(this.IndexOf(match), nrange);
        }

        public bool Merge(Range below, Range above)
        {
            bool next = false;
            if (above.Min <= below.Max && below.Max <= above.Max)
            {
                below.Max = Math.Max(below.Max, above.Max);
                this.Remove(above);
                next = true;
            }
            return next;
        }

        public void MergeAtIndex(int ndx)
        {
            while (ndx + 1 < this.Count)
            {
                //check next
                if (Merge(this[ndx], this[ndx + 1]))
                    ndx++;
                else
                    break;
            }
        }
    }
}
