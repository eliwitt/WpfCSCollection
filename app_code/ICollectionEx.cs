using System;
using System.Collections.Generic;
using System.Text;

    public interface ICollectionEx
    {
        bool IsDeleted
        { get;set;    }
        bool IsDirty
        { get;set;    }
        bool IsNew
        { get;set;    }
        void Reset();
        bool CompareValues(Object valueOfX, Object ValueToFind, FindRange constraint);
    }
