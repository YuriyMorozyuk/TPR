using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPR.lab
{
    partial class Relationship
    {
        public bool IsReflexive()
        {
            for (int i = 0; i < count; i++)
                if (this[i, i] == true)
                    continue;
                else
                    return false;
            return true;
        }

        public bool IsAntiReflective()
        {
            for (int i = 0; i < count; i++)
                if (this[i, i] == false)
                    continue;
                else
                    return false;
            return true;
        }
        public bool IsSymmetrical()
        {
            var temp = Relationship.oInverse(this);
            return this == temp;
        }
        public bool IsASymmetrical()
        {
            var temp = Relationship.oInverse(this);
            return this != temp;
        }
        public bool IsAntiSymmetrical()
        {
            var temp = Relationship.oInverse(this);
            temp = Relationship.oIntersection(this, temp);
            bool result = false;
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    if (i == j && temp[i, j])
                        result = result | true;
                    else
                        if (temp[i, j])
                        return false;
            return result;

        }
    }
}
