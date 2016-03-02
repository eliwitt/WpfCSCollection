using System;
using System.Collections.Generic;
using System.Text;
/// <summary>
/// General class that implements the ICollectionEx 
/// </summary>
    [Serializable]
    public class Player : ICollectionEx
    {
/// <summary>
/// Initial the class and set the org fields for the reset method.
/// </summary>
/// <param name="Name"></param>
/// <param name="Average"></param>
/// <param name="Slugging"></param>
/// <param name="AtBats"></param>
        public Player(String Name, Double Average, Double Slugging, Int32 AtBats)
        {
            _Name = Name;
            _Average = Average;
            _slugging = Slugging;
            _atbats = AtBats;
            // the following are the variables that we will use in the reset method.
            _org_atbats = _atbats;
            _org_Average = _Average;
        }
// the following are the class properties
        private Double _slugging;
        private String _Name;
        private Double _Average;
        private Int32 _atbats;
// the follow properties are used in the resetting of the dirty object
        private Double _org_Average=0.0;
        private Int32 _org_atbats=0;
        /// <summary>
        /// the players AtBats property
        /// </summary>
        public Int32 AtBats
        {
            get { return _atbats; }
            set 
            { 
                _atbats = value;
                _isDirty = true;
            }
        }
	    /// <summary>
	    /// the players batting Average property
	    /// </summary>
        public Double Average
        {
            get { return _Average; }
            set { 
                _Average = value;
                _isDirty = true;
            }
        }
	    /// <summary>
	    /// The players last name
	    /// </summary>
        public String LastName
        {
            get { return _Name; }
            set 
            { 
                _Name = value;
                _isDirty = true;
            }
        }
        /// <summary>
        /// the players slugging percentage
        /// </summary>
        public Double SluggingPercentage
        {
            get { return _slugging; }
            set 
            { 
                _slugging = value;
                _isDirty = true;
            }
        }

#region ICollectionEx Implementation
        /// <summary>
        /// The following are the Interface fields and methods we have to provide the
        /// detail for.
        /// </summary>
        private Boolean _isDirty = false;
        private Boolean _isNew = false;
        private Boolean _isDeleted = false;

        public Boolean IsDirty
        {
            get { return _isDirty; }
            set { _isDirty = value; }
        }
        public Boolean IsNew
        {
            get { return _isNew; }
            set { _isNew = value; }
        }
        public Boolean IsDeleted
        {
            get { return _isDeleted; }
            set { _isDeleted = value; }
        }

        public void Reset()
        {
            this._atbats = this._org_atbats;
            this._Average = this._org_Average;
            this.IsDirty = false;
        }

        public bool CompareValues(Object valueOfX, Object ValueToFind, FindRange constraint) 
        { 
            //
            // the comparing that goes on here is for types from the Player object
            // and is customized for this method.  Every type you have must be addressed
            // here.
            //
            int valCompare = 0;
            if (valueOfX is string)
            {
                IComparable comp = valueOfX as IComparable;
                valCompare = comp.CompareTo(ValueToFind);
            }
            else
            {
                if (valueOfX is Double)
                {
                    double myDbl;
                    Double.TryParse(ValueToFind.ToString(), out myDbl);
                    IComparable comp = valueOfX as IComparable;
                    valCompare = comp.CompareTo(myDbl);
                }
                else
                {
                    if (valueOfX is Int32)
                    {
                        Int32 myInt;
                        Int32.TryParse(ValueToFind.ToString(), out myInt);
                        IComparable comp = valueOfX as IComparable;
                        valCompare = comp.CompareTo(myInt);
                    }
                    else
                    {
                        return false;
                    }
                }
            }
                
            switch (constraint)
            {
                case FindRange.Equal:
                    if (valCompare == 0)
                        return true;
                    break;
                case FindRange.GreaterThan:
                    if (valCompare == 1)
                        return true;
                    break;
                case FindRange.LessThan:
                    if (valCompare == -1)
                        return true;
                    break;
                default:
                    return false;
            }
            return false;
        }

#endregion
    }
