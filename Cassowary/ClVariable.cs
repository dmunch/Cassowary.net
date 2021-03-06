/*
  Cassowary.net: an incremental constraint solver for .NET
  (http://lumumba.uhasselt.be/jo/projects/cassowary.net/)
  
  Copyright (C) 2005-2006  Jo Vermeulen (jo.vermeulen@uhasselt.be)
  
  This program is free software; you can redistribute it and/or
  modify it under the terms of the GNU Lesser General Public License
  as published by the Free Software Foundation; either version 2.1
  of  the License, or (at your option) any later version.

  This program is distributed in the hope that it will be useful,
  but WITHOUT ANY WARRANTY; without even the implied warranty of
  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
  GNU Lesser General Public License for more details.

  You should have received a copy of the GNU Lesser General Public License
  along with this program; if not, write to the Free Software
  Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
*/

namespace Cassowary
{
    public class ClVariable : ClAbstractVariable
    {
        public ClVariable(string name, double value)
            : base(name)
        {
            Value = value;
        }

        public ClVariable(string name)
            : base(name)
        {
            Value = 0.0;
        }

        public ClVariable(double value)
        {
            Value = value;
        }

        public ClVariable(long number, string prefix, double value)
            : base(number, prefix)
        {
            Value = value;
        }

        public ClVariable(long number, string prefix)
            : base(number, prefix)
        {
            Value = 0.0;
        }

        public override bool IsDummy
        {
            get { return false; }
        }

        public override bool IsExternal
        {
            get { return true; }
        }

        public override bool IsPivotable
        {
            get { return false; }
        }

        public override bool IsRestricted
        {
            get { return false; }
        }

        public override string ToString()
        {
            return "[" + Name + ":" + Value + "]";
        }

        /// <remarks>
        /// Change the value held -- should *not* use this if the variable is 
        /// in a solver -- instead use AddEditVar() and SuggestValue() interface
        /// </remarks>
        public double Value { get; private set; }

        /// <remarks>
        /// Permit overriding in subclasses in case something needs to be
        /// done when the value is changed by the solver
        /// may be called when the value hasn't actually changed -- just
        /// means the solver is setting the external variable
        /// </remarks>
        public virtual void ChangeValue(double value)
        {
            Value = value;
        }
    }
}