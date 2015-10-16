using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPR.lab
{
    public enum Type { P=0, R=1, Q=2, Null=3, Diagonal=4, Full=5 };
    partial class Relationship
    {
        
        public Relationship(Type en)
        {
            switch((int)en)
            {
                case 0:
                    {
                        _binMatrix[0, 0] = 0;
                        _binMatrix[0, 1] = 1;
                        _binMatrix[0, 2] = 0;
                        _binMatrix[0, 3] = 1;
                        _binMatrix[0, 4] = 0;
                        _binMatrix[1, 0] = 0;
                        _binMatrix[1, 1] = 0;
                        _binMatrix[1, 2] = 0;
                        _binMatrix[1, 3] = 0;
                        _binMatrix[1, 4] = 1;
                        _binMatrix[2, 0] = 0;
                        _binMatrix[2, 1] = 1;
                        _binMatrix[2, 2] = 1;
                        _binMatrix[2, 3] = 1;
                        _binMatrix[2, 4] = 0;
                        _binMatrix[3, 0] = 1;
                        _binMatrix[3, 1] = 0;
                        _binMatrix[3, 2] = 0;
                        _binMatrix[3, 3] = 0;
                        _binMatrix[3, 4] = 0;
                        _binMatrix[4, 0] = 0;
                        _binMatrix[4, 1] = 0;
                        _binMatrix[4, 2] = 1;
                        _binMatrix[4, 3] = 0;
                        _binMatrix[4, 4] = 1;
                        break;
                    }
                case 1:
                    {
                        _binMatrix[0, 0] = 0;
                        _binMatrix[0, 1] = 0;
                        _binMatrix[0, 2] = 0;
                        _binMatrix[0, 3] = 1;
                        _binMatrix[0, 4] = 0;
                        _binMatrix[1, 0] = 1;
                        _binMatrix[1, 1] = 1;
                        _binMatrix[1, 2] = 0;
                        _binMatrix[1, 3] = 0;
                        _binMatrix[1, 4] = 0;
                        _binMatrix[2, 0] = 1;
                        _binMatrix[2, 1] = 0;
                        _binMatrix[2, 2] = 0;
                        _binMatrix[2, 3] = 1;
                        _binMatrix[2, 4] = 1;
                        _binMatrix[3, 0] = 1;
                        _binMatrix[3, 1] = 0;
                        _binMatrix[3, 2] = 0;
                        _binMatrix[3, 3] = 0;
                        _binMatrix[3, 4] = 0;
                        _binMatrix[4, 0] = 0;
                        _binMatrix[4, 1] = 1;
                        _binMatrix[4, 2] = 0;
                        _binMatrix[4, 3] = 0;
                        _binMatrix[4, 4] = 0;
                        break;
                    }
                case 2:
                    {
                        _binMatrix[0, 0] = 1;
                        _binMatrix[0, 1] = 0;
                        _binMatrix[0, 2] = 0;
                        _binMatrix[0, 3] = 0;
                        _binMatrix[0, 4] = 0;
                        _binMatrix[1, 0] = 1;
                        _binMatrix[1, 1] = 0;
                        _binMatrix[1, 2] = 1;
                        _binMatrix[1, 3] = 0;
                        _binMatrix[1, 4] = 0;
                        _binMatrix[2, 0] = 0;
                        _binMatrix[2, 1] = 0;
                        _binMatrix[2, 2] = 1;
                        _binMatrix[2, 3] = 0;
                        _binMatrix[2, 4] = 1;
                        _binMatrix[3, 0] = 0;
                        _binMatrix[3, 1] = 0;
                        _binMatrix[3, 2] = 1;
                        _binMatrix[3, 3] = 0;
                        _binMatrix[3, 4] = 0;
                        _binMatrix[4, 0] = 0;
                        _binMatrix[4, 1] = 1;
                        _binMatrix[4, 2] = 1;
                        _binMatrix[4, 3] = 0;
                        _binMatrix[4, 4] = 0;
                    }
                    break;
                case 3:
                    for (int i = 0; i < count; i++)
                        for (int j = 0; j < count; j++)
                            _binMatrix[i, j] = 0;
                    break;
                case 4:
                    for (int i = 0; i < count; i++)
                        for (int j = 0; j < count; j++)
                            _binMatrix[i,j] = i == j ? 1 : 0;
                    break;
                case 5:
                    for (int i = 0; i < count; i++)
                        for (int j = 0; j < count; j++)
                            _binMatrix[i, j] = 1;
                    break;

            }
        }

        public Relationship()
        {
        }

        private int[,] _binMatrix;
        private static int count = 5;
        public bool this[int i,int j]
        {
            get
            {
                return _binMatrix[i,j] == 0 ? false : true;
            }
            set
            {
                if (value)
                    _binMatrix[i, j] = 1;
                else
                    _binMatrix[i, j] = 0;
            }
        }

        public static Relationship oIntersection(Relationship A,Relationship B)
        {
            var rel = new Relationship();
            for (int i = 0; i < count; i++)
                for (int j=0;j<count;j++)
            {
                    rel[i, j] = A[i, j] & B[i, j];
            }
            return rel;
        }

        public static Relationship oUnion(Relationship A, Relationship B)
        {
            var rel = new Relationship();
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
            {
                    rel[i, j] = A[i, j] | B[i, j];
            }
            return rel;
        }

        public static Relationship oDifference(Relationship A, Relationship B)
        {
            var rel = new Relationship();
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
            {
                if (A[i, j])
                        rel[i, j] = B[i, j] ? false : true;
                else
                        rel[i, j] = false;
            }
            return rel;
        }

        
        public static Relationship oSymmetricDifference(Relationship A, Relationship B)
        {
            var rel = new Relationship();
            var c = new Relationship();
            var d = new Relationship();
            c=Relationship.oUnion(A, B);
            d=Relationship.oIntersection(A, B);
            return oDifference(c, d);
        }
        public static Relationship oAddition(Relationship A)
        {
            var rel = new Relationship();
            for (int i = 0; i<count;i++)
                for(int j=0;j<count;j++)
                {
                    rel[i, j] = A[i, j] ? false : true;
                }
            return rel;
        }

        public static Relationship oInverse(Relationship A)
        {
            var rel = new Relationship();
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    rel[i, j] = A[j, i];
                }
            return rel;
        }

        public static Relationship oComposition(Relationship A,Relationship B)
        {
            var rel = new Relationship();
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                {
                    for (int k = 0; k < count; k++)
                        rel[i,j] = rel[i,j] | (A[i, k] & B[k, j]);          
                }
            return rel;
        }
        public static bool operator != (Relationship A, Relationship B)
        {
            for (int i = 0; i < count; i++)
                for (int j = 0; j < count; j++)
                    if (A[i, j] != B[i, j])
                        continue;
                    else
                        return false;
            return true;
        }
        public  static bool operator == (Relationship A, Relationship B)
            {
            for(int i=0;i<count;i++)
                for(int j=0;j<count;j++)
                    if (A[i, j] == B[i, j])
                        continue;
                    else
                        return false;
            return true;
            }
    }
}
